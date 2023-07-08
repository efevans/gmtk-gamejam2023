using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FrugalTime.Game
{
    public class GameController : IInitializable
    {
        public Smartphone Smartphone { get; private set; }

        private State _state;

        public void Initialize()
        {
            Debug.Log("GameController initialize");
            SetState(new PlayingState(this));
        }

        [Inject]
        public GameController(VideoSelection videoSelection, Smartphone smartphone)
        {
            Debug.Log("GameController constructor");
            videoSelection.InitVideoSelection(new VideoSelection.VideoSelectionSettings()
            {
                OnSelect = OnVideoSelectCallback
            });
            Smartphone = smartphone;
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
    }
}
