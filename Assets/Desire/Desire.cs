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
