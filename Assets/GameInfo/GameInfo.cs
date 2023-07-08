using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfo : MonoBehaviour
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
        StartCoroutine(MoveToEndpoint());
    }

    private IEnumerator MoveToEndpoint()
    {
        float timeToMove = 1f;
        float moveDistance = CalculateJumpVector();
        float startY = DisplayTranslateStartpoint.position.y;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            float currY = startY + moveDistance * Mathf.Sin(t * Mathf.PI / 2);

            transform.position = new Vector2(transform.position.x, currY);

            yield return null;
        }
    }

    private float CalculateJumpVector()
    {
        return DisplayTranslateEndpoint.position.y - DisplayTranslateStartpoint.position.y;
    }

    private void SetText(string text)
    {
        _text.text = text;
    }
}
