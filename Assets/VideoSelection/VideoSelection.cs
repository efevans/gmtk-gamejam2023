using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSelection : MonoBehaviour
{
    [SerializeField]
    private List<Video> _videos;

    private Action<Video> _onVideoSelect;

    public void InitVideoSelection(VideoSelectionSettings videoSelectionSettings)
    {
        _onVideoSelect = videoSelectionSettings.OnSelect;

        Video.Settings settings = new() { OnSelect = _onVideoSelect };
        _videos.ForEach(v => v.InitVideo(settings));
    }

    public class VideoSelectionSettings
    {
        public Action<Video> OnSelect;
    }
}
