using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Video", menuName = "Video/New Video")]
public class VideoResource : ScriptableObject
{
    public Sprite Thumbnail;
    public Sprite VideoImage;
    public string Title;
    public string UploaderName;
    public Sprite UploadedImage;
    public AudioClip Audio;
}
