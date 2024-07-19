using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class FloatButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float floatHeight = 20f; // �������� ����
    public float floatDuration = 0.5f; // �������� �ð�

    private Vector3 originalPosition;
    private Coroutine floatCoroutine;

    void Start()
    {
        // ���� ��ġ�� �����մϴ�.
        originalPosition = transform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Ŀ���� ��ư ���� ���� �� �������� ȿ���� �����մϴ�.
        if (floatCoroutine != null)
        {
            StopCoroutine(floatCoroutine);
        }
        floatCoroutine = StartCoroutine(FloatButton(true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Ŀ���� ��ư�� ���� �� ���� ��ġ�� ���ư��� ȿ���� �����մϴ�.
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
