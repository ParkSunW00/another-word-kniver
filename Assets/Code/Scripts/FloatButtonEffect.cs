using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class FloatButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float floatHeight = 20f; // 떠오르는 높이
    public float floatDuration = 0.5f; // 떠오르는 시간

    private Vector3 originalPosition;
    private Coroutine floatCoroutine;

    void Start()
    {
        // 원래 위치를 저장합니다.
        originalPosition = transform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // 커서가 버튼 위에 있을 때 떠오르는 효과를 시작합니다.
        if (floatCoroutine != null)
        {
            StopCoroutine(floatCoroutine);
        }
        floatCoroutine = StartCoroutine(FloatButton(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // 커서가 버튼을 떠날 때 원래 위치로 돌아가는 효과를 시작합니다.
        if (floatCoroutine != null)
        {
            StopCoroutine(floatCoroutine);
        }
        floatCoroutine = StartCoroutine(FloatButton(false));
    }

    IEnumerator FloatButton(bool floatUp)
    {
        float elapsedTime = 0f;
        Vector3 targetPosition = floatUp ? originalPosition + new Vector3(0, floatHeight, 0) : originalPosition;

        while (elapsedTime < floatDuration)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, elapsedTime / floatDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPosition;
    }
}
