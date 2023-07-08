using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : IInitializable
{
    private readonly Smartphone _smartphone;

    public void Initialize()
    {
        Debug.Log("GameController initialize");
    }

    [Inject]
    public GameController(VideoSelection videoSelection, Smartphone smartphone)
    {
        videoSelection.InitVideoSelection(new VideoSelection.VideoSelectionSettings()
        {
            OnSelect = OnVideoSelectCallback
        });
        _smartphone = smartphone;
    }

    private void OnVideoSelectCallback(Video video)
    {
        Debug.Log("clicked!");
        _smartphone.SetPlayingVideo(video);
    }
}
