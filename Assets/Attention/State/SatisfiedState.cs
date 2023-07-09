using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Tick
{
    public class SatisfiedState : State
    {
        public SatisfiedState(Attention attention) : base(attention)
        {
        }

        public override void Start()
        {
            _attention.StartCoroutine(BeSatisfiedForXSeconds(Random.Range(_attention.MySettings.SatisfiedDurationMinimum, _attention.MySettings.SatisfiedDurationMaximum)));
        }

        private IEnumerator BeSatisfiedForXSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            _attention.SetState(new WanningState(_attention));
        }
    } 
}
