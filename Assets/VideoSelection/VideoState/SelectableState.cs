using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Playable
{
    public class SelectableState : VideoState
    {
        public SelectableState(Video video) : base(video)
        {
        }

        public override void Start()
        {
            _video.Lock.gameObject.SetActive(false);
        }

        public override void OnSelect()
        {
            _video.OnSelect(_video);
        }

        public override void Disable()
        {
            _video.SetState(new DisabledState(_video));
        }
    }
}
