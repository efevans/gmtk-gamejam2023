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

        private Action _onDepleted;

        [Inject]
        public void Construct(Settings settings)
        {
            MySettings = settings;
        }

        public void Init(Action onDepleted)
        {
            _onDepleted = onDepleted;
        }

        // Do start starts the component to tick down, Start is already take but same idea
        public void DoStart()
        {
            _state.OnGameStart();
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

        [Serializable]
        public class Settings
        {
            public float DecaySpeed;
        }
    }
}
