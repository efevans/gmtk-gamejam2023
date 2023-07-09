using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrugalTime.Game
{
    public class PlayerLostState : State
    {
        private readonly List<string> _endingTexts = new List<string>()
        {
            "Nice job on your first day, A-45",
            "",
            "Keep that up that pace and we may just become the next big hit!",
            "(Thank you for playing! There is no replace screen so if you wish to replay, please refresh the brower)"
        };
        private int _cursor = 0;

        public PlayerLostState(GameController controller) : base(controller)
        {
        }

        public override void Start()
        {
            _controller.GameInfo.DisplayInfoText(_endingTexts[_cursor]);
            _controller.EndTime = DateTime.Now;
        }

        public override void OnAdvance()
        {
            _cursor++;
            if (_cursor < _endingTexts.Count)
            {
                if (_cursor == 1)
                {
                    string text = $"You kept the fleshclump at attention for {CalculatePlaytime():0.00} seconds!";
                    _controller.GameInfo.ContinueText(text);
                }
                else
                {
                    _controller.GameInfo.ContinueText(_endingTexts[_cursor]);
                }

                if (_cursor == _endingTexts.Count - 1)
                {
                    _controller.GameInfo.HideContinueText();
                }
            }
        }

        private double CalculatePlaytime()
        {
            return (_controller.EndTime - _controller.StartTime).TotalSeconds;
        }
    } 
}
