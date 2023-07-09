using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Tick
{
    public class WaitingToStartState : State
    {
        public WaitingToStartState(Attention attention) : base(attention)
        {
        }

        public override void OnGameStart()
        {
            _attention.SetState(new WanningState(_attention));
        }
    }
}
