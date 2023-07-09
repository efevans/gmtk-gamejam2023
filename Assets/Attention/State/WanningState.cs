using UnityEngine;
using Unity.Mathematics;

namespace FrugalTime.Tick
{
    public class WanningState : State
    {
        public WanningState(Attention attention) : base(attention)
        {
        }

        public override void Start()
        {
            _attention.Desire.DisplayInfoText("Something cute would be nice...");
        }

        public override void Tick(float delta)
        {
            _attention.Amount = Mathf.Max(0, _attention.Amount - (delta * _attention.DecayRate));

            if (_attention.Amount <= 0)
            {
                _attention.Desire.MoveBack();
                _attention.SetState(new DepletedState(_attention));
            }
        }

        public override void DesireFulfilled()
        {
            _attention.Desire.MoveBack();
            _attention.Amount = Mathf.Min(1, _attention.Amount + _attention.MySettings.SatisfyRecover);
            _attention.SetState(new SatisfiedState(_attention));
        }
    }
}