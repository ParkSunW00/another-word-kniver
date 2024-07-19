using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BlinkManager : MonoBehaviour
{
    public Image imageToBlink;
    public float blinkDuration = 1.0f; // �� ���� ������ ���� �ð�

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
            // �̹����� ���� �����
            yield return StartCoroutine(FadeImage(false));
            // �̹����� ���� ��Ÿ��
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

        // ���� ���� �� ����
        imageToBlink.canvasRenderer.SetAlpha(endAlpha);
    }
}
