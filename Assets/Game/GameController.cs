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

    public GameController(List<Video> videos)
    {
        Debug.Log($"GameController constructor, video count is {videos.Count}");
    }
}
