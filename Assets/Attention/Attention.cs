using FrugalTime.Playable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FrugalTime.Tick
{
    public class Attention : MonoBehaviour
    {
        [SerializeField]
        private Image LeftBar;
        [SerializeField]
        private Image RightBar;

        public Desire Desire { get; private set; }

        private float _amount;
        public float Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                LeftBar.fillAmount = _amount;
                RightBar.fillAmount = _amount;
            }
        }

        private State _state;
        public Settings MySettings { get; private set; }

        public float DecayRate;
        public float SecondsSinceLastDecayRateIncrease = 0;

        private Action _onDepleted;

        [Inject]
        public void Construct(Settings settings, Desire desire)
        {
            MySettings = settings;
            Desire = desire;
        }

        public void Init(Action onDepleted)
        {
            _onDepleted = onDepleted;
            DecayRate = MySettings.DecaySpeed;
            SecondsSinceLastDecayRateIncrease = 0;
        }

        // Do start starts the component to tick down, Start is already take but same idea
        public void DoStart()
        {
            _state.OnGameStart();
        }

        public void OnVideoSelected(Video video)
        {
            _state.VideoShown(video);
        }

        private void OnEnable()
        {
            Amount = 1f;
            SetState(new WaitingToStartState(this));
        }

        // Update is called once per frame
        void Update()
        {
            _state.Tick(Time.deltaTime);
        }

        public void OnDepleted()
        {
            _onDepleted();
        }

        public void SetState(State newState)
        {
            _state = newState;
            _state.Start();
        }

        public Desire.Example GetRandomDesire()
        {
            return MySettings.Desires[UnityEngine.Random.Range(0, MySettings.Desires.Count)];
        }

        [Serializable]
        public class Settings
        {
            public float DecaySpeed;
            public float DecayAcceleration;
            public float SatisfyRecover;
            public float SatisfiedDurationMinimum;
            public float SatisfiedDurationMaximum;
            public List<Desire.Example> Desires;
        }
    }
}
