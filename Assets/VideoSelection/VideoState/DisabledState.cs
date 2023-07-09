using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Playable
{
    public class DisabledState : VideoState
    {
        public DisabledState(Video video) : base(video)
        {
        }

        public override void Start()
        {
            _video.Lock.gameObject.SetActive(true);
        }

        public override void Enable()
        {
            _video.SetState(new SelectableState(_video));
        }
    }
}
