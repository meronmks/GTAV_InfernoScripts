using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using GTA.Math;

namespace Inferno.InfernoScripts.Parupunte.Scripts
{
    [ParupunteDebug(true)]
    class CitizenGetDown : ParupunteScript
    {
        private ReduceCounter reduceCounter;
        private HashSet<int> pedHndles = new HashSet<int>();
        private List<uint> coroutineIds = new List<uint>();
        public CitizenGetDown(ParupunteCore core) : base(core)
        {
        }

        public override string Name => "みなｗｗｗぎっｗｗｗてｗｗｗきたｗｗｗｗ";
        public override void OnStart()
        {
            reduceCounter = new ReduceCounter(30000);
            AddProgressBar(reduceCounter);

            this.UpdateAsObservable
                .Subscribe(_ =>
                {
                    foreach (var ped in core.CachedPeds.Where(x => x.IsSafeExist() && x.IsInRangeOf(core.PlayerPed.Position, 100) && !pedHndles.Contains(x.Handle)))
                    {
                        pedHndles.Add(ped.Handle);
                        var id = StartCoroutine(GetDownCoroutine(ped));
                        coroutineIds.Add(id);
                    }
                });
            
            reduceCounter.OnFinishedAsync.Subscribe(_ =>
            {
                ParupunteEnd();
            });
        }

        protected override void OnFinished()
        {
            reduceCounter.Finish();
            foreach (var id in coroutineIds)
            {
                StopCoroutine(id);
            }
            coroutineIds.Clear();
        }

        IEnumerable<object> GetDownCoroutine(Ped ped)
        {
            Random random = new Random();
            while (!reduceCounter.IsCompleted)
            {
                if(!ped.IsSafeExist()) yield break;
                var randomVector = Utilities.InfernoUtilities.CreateRandomVector();
                ped.Quaternion = Quaternion.RotationAxis(randomVector, random.Next(0, 300)/100.0f)*ped.Quaternion;
                yield return null;
            }
        } 
    }
}
