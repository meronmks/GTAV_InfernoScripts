﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using GTA;

namespace Inferno
{
    /// <summary>
    /// インフェルノスクリプトの基底
    /// </summary>
    public abstract class InfernoScript : Script
    {
        protected Random Random = new Random();

        protected bool IsActive = false;

        /// <summary>
        /// プレイヤのped
        /// </summary>
        protected Ped playerPed { get; private set; }

        private Ped[] _cachedPeds = new Ped[0];
        /// <summary>
        /// キャッシュされたプレイヤ周辺の市民
        /// </summary>
        public ReadOnlyCollection<Ped> CachedPeds => Array.AsReadOnly(_cachedPeds??new Ped[0]);

        private Vehicle[] _cachedVehicles = new Vehicle[0];
        /// <summary>
        /// キャッシュされたプレイヤ周辺の車両
        /// </summary>
        public ReadOnlyCollection<Vehicle> CachedVehicles => Array.AsReadOnly(_cachedVehicles ?? new Vehicle[0]);

        /// <summary>
        /// 一定間隔のTickイベント
        /// </summary>
        public IObservable<Unit> OnTickAsObservable { get; private set; }

        /// <summary>
        /// 描画用のTickイベント
        /// </summary>
        public IObservable<Unit> OnDrawingTickAsObservable { get; private set; }

        public IObservable<KeyEventArgs> OnKeyDownAsObservable => InfernoCore.OnKeyDownAsObservable;

        /// <summary>
        /// スクリプトのTickイベントの実行頻度[ms]
        /// コルーチンの実行間隔も影響を受けるので注意
        /// </summary>
        protected  virtual int TickInterval => 100;

        public IObservable<Unit> OnAllOnCommandObservable { get; private set; }

        private CoroutineSystem coroutineSystem;

        /// <summary>
        /// テキスト表示
        /// </summary>
        /// <param name="text">表示したい文字列</param>
        /// <param name="time">時間[s]</param>
        public void DrawText(string text, float time)
        {
            ToastTextDrawing.Instance.DrawDebugText(text, time);
        }

        /// <summary>
        /// プログレスバーの表示
        /// </summary>
        /// <param name="pos">表示させたい座標</param>
        /// <param name="time">ゲージが満タンor0になるまでの時間[s]</param>
        /// <param name="barColor">ゲージ本体の色</param>
        /// <param name="backgroundColor">ゲージ背景色</param>
        /// <param name="progressBarType">増加or減少するゲージの指定</param>
        public void DrawProgressBar(Point pos, float time, Color barColor, Color backgroundColor, ProgressBarType progressBarType)
        {
            ProgressBarDrawing.Instance.DrawProgressBar(pos, time, barColor, backgroundColor, progressBarType);
        }

        /// <summary>
        /// すべてのプログレスバーを削除
        /// </summary>
        public void StopAllProcessBar()
        {
            ProgressBarDrawing.Instance.StopAllProgressBarCoroutine();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        protected InfernoScript()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(1))
                .Where(_ => InfernoCore.Instance != null)
                .Take(1)
                .Subscribe(_ =>
                {
                    InfernoCore.Instance.PedsNearPlayer.Subscribe(x => _cachedPeds = x);
                    InfernoCore.Instance.VehicleNearPlayer.Subscribe(x => _cachedVehicles = x);
                    InfernoCore.Instance.PlayerPed.Subscribe(x => playerPed = x);
                });
            
            //TickイベントをObservable化しておく
            Interval = TickInterval;
            OnTickAsObservable =
                Observable.FromEventPattern<EventHandler, EventArgs>(h => h.Invoke, h => Tick += h, h => Tick -= h)
                    .Select(_ => Unit.Default).Publish().RefCount(); //Subscribeされたらイベントハンドラを登録する

            OnDrawingTickAsObservable = DrawingCore.OnDrawingTickAsObservable;

            OnAllOnCommandObservable = CreateInputKeywordAsObservable("allon");

            coroutineSystem = new CoroutineSystem();

            Observable.Timer(TimeSpan.FromMilliseconds(Random.Next(0, 10)*10))
                .Take(1)
                .Subscribe(_ =>
                {
                    ////コルーチンの実行
                    OnTickAsObservable
                        .Subscribe(x => coroutineSystem.CoroutineLoop());
                });

            try
            {
                Setup();
            }
            catch (Exception e)
            {
                LogWrite(e.ToString());
            }
        }

        /// <summary>
        /// 初期化処理はここに書く
        /// </summary>
        protected abstract void Setup();

        /// <summary>
        /// 入力文字列に応じて反応するIObservableを生成する
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        protected IObservable<Unit> CreateInputKeywordAsObservable(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                throw new Exception("Keyword is empty.");
            }

            return InfernoCore.OnKeyDownAsObservable
                .Select(e => e.KeyCode.ToString())
                .Buffer(keyword.Length, 1)
                .Select(x => x.Aggregate((p, c) => p + c))
                .Where(x => x == keyword.ToUpper()) //入力文字列を比較
                .Select(_=>Unit.Default)
                .Take(1).Repeat() //1回動作したらBufferをクリア
                .Publish()
                .RefCount();
        }

        /// <summary>
        /// 100ms単位でのTickイベントをOnTickAsObservableから生成する
        /// </summary>
        /// <param name="millsecond">ミリ秒(100ミリ秒以上で指定）</param>
        /// <returns></returns>
        protected IObservable<Unit> CreateTickAsObservable(int millsecond)
        {
            var skipCount = (millsecond/TickInterval) - 1;

            if (skipCount <= 0)
            {
                return OnTickAsObservable;
            }

            return OnTickAsObservable
                .Skip(skipCount)
                .Take(1)
                .Repeat()
                .Publish().RefCount();
        }

        protected uint StartCoroutine(IEnumerable<Object> coroutine)
        {
            return coroutineSystem.AddCrotoutine(coroutine);
        }

        protected void StopCoroutine(uint id)
        {
            if (coroutineSystem != null)
            {
                coroutineSystem.RemoveCoroutine(id);
            }
        }

        /// <summary>
        /// 指定秒数待機するIEnumerable
        /// </summary>
        /// <param name="secound">秒</param>
        /// <returns></returns>
        protected IEnumerable WaitForSeconds(float secound)
        {
            var tick = TickInterval > 0 ? TickInterval : 10;
            var waitLoopCount = (int) (secound*1000/tick);
            for (var i = 0; i < waitLoopCount; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        /// 0-10回待機してコルーチンの処理を分散する
        /// </summary>
        /// <returns></returns>
        protected IEnumerable RandomWait()
        {
            var waitLoopCount = Random.Next(0, 10);
            for (var i = 0; i < waitLoopCount; i++)
            {
                yield return i;
            }
        } 


        /// <summary>
        /// ログをTCPSocker経由で吐く
        /// </summary>
        /// <param name="message">ログメッセージ</param>
        public void LogWrite(string message)
        {
#if DEBUG
            InfernoCore.Instance.LogWrite(message + "\n");
#endif
        }
    }
}
