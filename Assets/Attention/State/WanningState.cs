using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;
using System.Linq;

namespace FrugalTime.Tick
{
    public class WanningState : State
    {
        private Desire.Example CurrentDesire { get; set; }

        public WanningState(Attention attention) : base(attention)
        {
        }

        public override void Start()
        {
            CurrentDesire = _attention.GetRandomDesire();
            _attention.Desire.DisplayInfoText(CurrentDesire.Text);
        }

        public override void Tick(float delta)
        {
            _attention.Amount = Mathf.Max(0, _attention.Amount - (delta * _attention.DecayRate));

            if (_attention.Amount <= 0)
            {
                _attention.Desire.MoveBack();
                _attention.SetState(new DepletedState(_attention));
            }

            _attention.SecondsSinceLastDecayRateIncrease += Time.deltaTime;

            if (_attention.SecondsSinceLastDecayRateIncrease > _attention.MySettings.DecayAcceleration)
            {
                Debug.Log("Decay rate increased");
                _attention.DecayRate += 0.01f;
                _attention.SecondsSinceLastDecayRateIncrease = 0;
            }
        }

        public override void VideoShown(Video video)
        {
            if (VideoSatisfies(video))
            {
                _attention.Desire.MoveBack();
                _attention.Amount = Mathf.Min(1, _attention.Amount + _attention.MySettings.SatisfyRecover);
                _attention.SetState(new SatisfiedState(_attention)); 
            }
        }

        private bool VideoSatisfies(Video video)
        {
            IReadOnlyList<Video.Genre> videoGenres = video.Genres;
            IReadOnlyList<Video.Genre> desiredGenres = CurrentDesire.FulfillingGenres.AsReadOnly();

            foreach (var genre in videoGenres)
            {
                if (desiredGenres.Contains(genre))
                {
                    return true;
                }
            }

            return false;
        }
    }
}