﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;
using GTA.Native;

namespace Inferno.InfernoScripts.Parupunte.Scripts
{
    class ArmorRegen : ParupunteScript
    {
        private ReduceCounter reduceCounter;
        public ArmorRegen(ParupunteCore core) : base(core)
        {
        }

        public override string Name => "自動回復アーマー";

        private uint coroutineId = 0;
        public override void OnStart()
        {
            reduceCounter = new ReduceCounter(30000);
            reduceCounter.OnFinishedAsync.Subscribe(_ => ParupunteEnd());
            coroutineId = StartCoroutine(ArmorRegenCoroutine());
            AddProgressBar(reduceCounter);
        }

        public override void OnFinished()
        {
            reduceCounter.Finish();
            StopCoroutine(coroutineId);
        }

        IEnumerable<object> ArmorRegenCoroutine()
        {
            while (!reduceCounter.IsCompleted)
            {
                core.PlayerPed.Armor += 14;
                yield return WaitForSeconds(3);
            }
        }

    }
}