using System.Collections;

using UnityEngine;

public class AutoTransparecy : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float transparency;
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] float fadeDuration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(layerMask == (layerMask|(1 << collision.gameObject.layer)))
        {
            SetTransparency(transparency);
        }
    }
    private void OnTriggerExit2D (Collider2D collision)
    {
        if (layerMask == (layerMask | (1 << collision.gameObject.layer)))
        {
            SetTransparency(1);
        }
    }
    private void SetTransparency(float alpha)
    {
        StopCoroutine("FadeCoroutine");
        StartCoroutine("FadeCoroutine",alpha);
    }
    private IEnumerator FadeCoroutine(float fadeTo)
    {
        float timer = 0;
        Color currentColor = targetRenderer.material.color;
        float startAlpha = targetRenderer.material.color.a;
        while (timer < 1)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime / fadeDuration;

            currentColor.a = Mathf.Lerp(startAlpha, fadeTo, timer);
            targetRenderer.material.color = currentColor;
        }
    }
}
