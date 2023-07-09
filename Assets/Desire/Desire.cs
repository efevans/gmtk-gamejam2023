using FrugalTime.Playable;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Desire : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Transform DisplayTranslateStartpoint;
    [SerializeField]
    private Transform DisplayTranslateEndpoint;

    public void DisplayInfoText(string text)
    {
        SetText(text);
        StartCoroutine(MoveToEndpoint(DisplayTranslateEndpoint.position, 2f));
    }

    public void MoveBack()
    {
        StartCoroutine(MoveToEndpoint(DisplayTranslateStartpoint.position, 1.7f));
    }

    private IEnumerator MoveToEndpoint(Vector2 endpoint, float time)
    {
        float timeToMove = time;
        float startX = transform.position.x;
        float moveDistance = CalculateJumpVector(endpoint.x, startX);

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            float currX = startX + moveDistance * Mathf.Sin(t * Mathf.PI / 2);

            transform.position = new Vector2(currX, transform.position.y);

            yield return null;
        }
    }

    private float CalculateJumpVector(float start, float end)
    {
        return start - end;
    }

    private void SetText(string text)
    {
        _text.text = text;
    }

    [Serializable]
    public class Example
    {
        public string Text;
        public List<Video.Genre> FulfillingGenres;
    }
}
