using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : IInitializable
{
    public void Initialize()
    {
        Debug.Log("GameController initialize");
    }

    [Inject]
    public GameController(VideoSelection videoSelection)
    {
        videoSelection.InitVideoSelection(new VideoSelection.VideoSelectionSettings() { OnSelect = (Video video) => { Debug.Log("clicked!"); } }); 
    }
}
