using FrugalTime.Playable;
using FrugalTime.Tick;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FrugalTime.Game
{
    public class GameController : IInitializable, ITickable
    {
        public Smartphone Smartphone { get; private set; }
        public Attention Attention { get; private set; }
        public GameInfo GameInfo { get; private set; }
        public VideoSelection VideoSelection { get; private set; }

        private State _state;
        public DateTime StartTime;
        public DateTime EndTime;

        public void Initialize()
        {
            Debug.Log("GameController initialize");
            SetState(new InitialInformState(this));
            Attention.Init(OnAttentionDepletedCallback);
        }

        [Inject]
        public GameController(VideoSelection videoSelection, Smartphone smartphone, Attention attention, GameInfo gameInfo)
        {
            Debug.Log("GameController constructor");
            VideoSelection = videoSelection;
            Smartphone = smartphone;
            Attention = attention;
            GameInfo = gameInfo;
        }

        public void SetState(State state)
        {
            _state = state;
            _state.Start();
        }

        public void OnVideoSelectCallback(Video video)
        {
            _state.PlayVideo(video);
            Attention.OnVideoSelected(video);
        }

        private void OnAttentionDepletedCallback()
        {
            Debug.Log("Attention Depleted");
            _state.AttentionDepleted();
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
            {
                _state.OnAdvance();
            }
        }
    }
}
