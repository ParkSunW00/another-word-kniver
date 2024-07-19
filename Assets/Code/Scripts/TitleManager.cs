using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public bool isStarted = false; //시작여부 


    // Update is called once per frame
    void Update()
    {
        // 마우스 클릭 + 터치 감지
        if (!isStarted && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            // 게임 시작 상태로 변경
            isStarted = true;
            // MainMenu 로드
            SceneManager.LoadScene("ChatScene");
        }
    }
}
