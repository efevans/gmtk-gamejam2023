using FrugalTime.Tick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FrugalTime.Game
{
    public class GameController : IInitializable
    {
        public Smartphone Smartphone { get; private set; }
        public Attention Attention { get; private set; }
        public GameInfo GameInfo { get; private set; }

        private State _state;

        public void Initialize()
        {
            Debug.Log("GameController initialize");
            SetState(new PlayingState(this));
            Attention.Init(OnAttentionDepletedCallback);
            GameInfo.DisplayInfoText("Give this meat-bag what he really wants!");
        }

        [Inject]
        public GameController(VideoSelection videoSelection, Smartphone smartphone, Attention attention, GameInfo gameInfo)
        {
            Debug.Log("GameController constructor");
            videoSelection.InitVideoSelection(new VideoSelection.VideoSelectionSettings()
            {
                OnSelect = OnVideoSelectCallback
            });
            Smartphone = smartphone;
            Attention = attention;
            GameInfo = gameInfo;
        }

        public void SetState(State state)
        {
            _state = state;
            _state.Start();
        }

        private void OnVideoSelectCallback(Video video)
        {
            _state.PlayVideo(video);
        }

        private void OnAttentionDepletedCallback()
        {
            Debug.Log("Attention Depleted");
            _state.AttentionDepleted();
        }
    }
}
