using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BlinkManager : MonoBehaviour
{
    public Image imageToBlink;
    public float blinkDuration = 1.0f; // 한 번의 깜빡임 지속 시간

    void Start()
    {
        if (imageToBlink != null)
        {
            StartCoroutine(BlinkImage());
        }
    }

    IEnumerator BlinkImage()
    {
        while (true)
        {
            // 이미지가 점점 사라짐
            yield return StartCoroutine(FadeImage(false));
            // 이미지가 점점 나타남
            yield return StartCoroutine(FadeImage(true));
        }
    }

    IEnumerator FadeImage(bool fadeIn)
    {
        float startAlpha = fadeIn ? 0.0f : 1.0f;
        float endAlpha = fadeIn ? 1.0f : 0.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < blinkDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / blinkDuration);
            imageToBlink.canvasRenderer.SetAlpha(alpha);
            yield return null;
        }

        // 최종 알파 값 설정
        imageToBlink.canvasRenderer.SetAlpha(endAlpha);
    }
}
