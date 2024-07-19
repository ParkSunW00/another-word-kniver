using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public bool isStarted = false; //���ۿ��� 


    // Update is called once per frame
    void Update()
    {
        // ���콺 Ŭ�� + ��ġ ����
        if (!isStarted && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            // ���� ���� ���·� ����
            isStarted = true;
            // MainMenu �ε�
            SceneManager.LoadScene("ChatScene");
        }
    }
}
