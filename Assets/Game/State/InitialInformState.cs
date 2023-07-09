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
            "As a recommender here, your role will be to keep the fleshclumps entertained",
            "See that green bar at the top? That's their attention span",
            "Don't let that deplete all the way",
            "In order to accomplish that, recommend them videos",
            "You'll need to intuit what they'll like from their thoughts",
            "Keep them engaged, you know?",
            "There's a short delay before you can recommend another video, so try to satisfy them with the first try",
            "Finally, we can't keep everyone forever so their attention will start to decrease faster as time goes on"
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
