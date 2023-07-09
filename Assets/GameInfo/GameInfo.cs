using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private TextMeshProUGUI _spaceToContinueText;
    [SerializeField]
    private Transform DisplayTranslateStartpoint;
    [SerializeField]
    private Transform DisplayTranslateEndpoint;

    public void DisplayInfoText(string text)
    {
        SetText(text);
        StartCoroutine(MoveToEndpoint(DisplayTranslateEndpoint.position));
    }

    public void ContinueText(string text)
    {
        SetText(text);
    }

    public void MoveBack()
    {
        _spaceToContinueText.gameObject.SetActive(false);
        StartCoroutine(MoveToEndpoint(DisplayTranslateStartpoint.position));
    }

    public void HideContinueText()
    {
        _spaceToContinueText.gameObject.SetActive(false);
    }

    private IEnumerator MoveToEndpoint(Vector2 endpoint)
    {
        float timeToMove = 1f;
        float startY = transform.position.y;
        float moveDistance = CalculateJumpVector(endpoint.y, startY);

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            float currY = startY + moveDistance * Mathf.Sin(t * Mathf.PI / 2);

            transform.position = new Vector2(transform.position.x, currY);

            yield return null;
        }

        _spaceToContinueText.gameObject.SetActive(true);
    }

    private float CalculateJumpVector(float start, float end)
    {
        return start - end;
    }

    private void SetText(string text)
    {
        _text.text = text;
    }
}
