using FrugalTime.Game;
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