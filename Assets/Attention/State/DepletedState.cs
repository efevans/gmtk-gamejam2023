using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Tick
{
    public class DepletedState : State
    {
        public DepletedState(Attention attention) : base(attention)
        {
        }

        public override void Start()
        {
            _attention.OnDepleted();
        }
    }

}