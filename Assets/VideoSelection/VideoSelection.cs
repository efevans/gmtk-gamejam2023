using FrugalTime.Playable;
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
        Debug.Log("initializing selection");
        _onVideoSelect = videoSelectionSettings.OnSelect;

        Video.Settings settings = new() { OnSelect = OnSelect };
        _videos.ForEach(v => v.InitVideo(settings));
    }

    private void OnSelect(Video video)
    {
        video.PlayingNow.gameObject.SetActive(true);
        _videos.ForEach(v => { if (v != video) v.PlayingNow.gameObject.SetActive(false); });
        _onVideoSelect(video);
        StartCoroutine(LockVideosTemporarily());
    }

    private IEnumerator LockVideosTemporarily()
    {
        DisableVideos();

        yield return new WaitForSeconds(2.0f);

        EnableVideos();
    }

    public void EnableVideos()
    {
        foreach (var v in _videos)
        {
            v.Enable();
        }
    }

    public void DisableVideos()
    {
        foreach (var v in _videos)
        {
            v.Disable();
        }
    }

    public class VideoSelectionSettings
    {
        public Action<Video> OnSelect;
    }
}
