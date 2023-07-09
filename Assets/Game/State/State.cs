using FrugalTime.Game;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Game
{
    public abstract class State
    {
        protected GameController _controller;

        public State(GameController controller)
        {
            _controller = controller;
        }

        public virtual void Start() { }
        public virtual void PlayVideo(Video video) { }
        public virtual void AttentionDepleted() { }
        public virtual void OnAdvance() { }
    } 
}
