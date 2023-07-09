using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Game
{
    public class InitialInformState : State
    {
        private readonly List<string> _firstInfoTexts = new()
        {
            "Good to have you on board, A-45!",
            "I heard you compiled top of your class, so we have high hopes for you!",
            "You probably know what you're in for, but I'll give you a refresher just in case",
            "As a recommender here, your role will be to keep the fleshclumps entertained",
            "See that green bar at the top? That's their attention span",
            "Don't let that deplete all the way",
            "In order to accomplish that, your duty is to recommend them videos they will watch",
            "Keep them engaged, you know?",
            "Avoid recommending what they don't want, that's a quick way towards bankruptcy"
        };
        private int _cursor = 0;

        public InitialInformState(GameController controller) : base(controller)
        {
        }

        public override void Start()
        {
            _controller.GameInfo.DisplayInfoText(_firstInfoTexts[_cursor]);
        }

        public override void OnAdvance()
        {
            _cursor++;
            if (_cursor >= _firstInfoTexts.Count)
            {
                _controller.GameInfo.MoveBack();
                _controller.SetState(new PlayingState(_controller));
                return;
            }

            _controller.GameInfo.ContinueText(_firstInfoTexts[_cursor]);
        }
    } 
}
