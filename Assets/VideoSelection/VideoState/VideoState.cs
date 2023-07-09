using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Playable
{
    public abstract class VideoState
    {
        protected Video _video;

        public VideoState(Video video)
        {
            _video = video;
        }

        public virtual void Start() { }
        public virtual void OnSelect() { }
        public virtual void Enable() { }
        public virtual void Disable() { }
    } 
}
