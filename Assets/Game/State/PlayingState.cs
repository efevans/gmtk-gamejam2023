using FrugalTime.Game;
using FrugalTime.Playable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Game
{
    public class PlayingState : State
    {
        public PlayingState(GameController controller) : base(controller)
        {
        }

        public override void Start()
        {
            _controller.Attention.DoStart();
            _controller.StartTime = DateTime.Now;

            _controller.VideoSelection.InitVideoSelection(new VideoSelection.VideoSelectionSettings()
            {
                OnSelect = _controller.OnVideoSelectCallback
            });
        }

        public override void PlayVideo(Video video)
        {
            _controller.Smartphone.SetPlayingVideo(video);
        }

        public override void AttentionDepleted()
        {
            _controller.SetState(new PlayerLostState(_controller));
        }
    }

}