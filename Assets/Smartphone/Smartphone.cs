using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smartphone : MonoBehaviour
{
    public Image Screen;

    public void SetPlayingVideo(Video video)
    {
        Screen.sprite = video.Image.sprite;
        Screen.color = video.Image.color;
    }
}
