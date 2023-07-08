using UnityEngine;
using Unity.Mathematics;

namespace FrugalTime.Tick
{
    public class WanningState : State
    {
        public WanningState(Attention attention) : base(attention)
        {
        }

        public override void Tick(float delta)
        {
            _attention.Amount = math.max(0, _attention.Amount - (delta * _attention.MySettings.DecaySpeed));

            if (_attention.Amount <= 0)
            {
                _attention.SetState(new DepletedState(_attention));
            }
        }
    }
}