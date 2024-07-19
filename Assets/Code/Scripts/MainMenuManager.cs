using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    //버튼
    public Button StartBtn;
    public Button OptionBtn;
    public Button ExitBtn;

    TitleManager Titlemng;

    void Start()
    {
        if (StartBtn != null)
        {
            StartBtn.onClick.AddListener(StartBtnClick);
        }

        if (OptionBtn != null)
        {
            OptionBtn.onClick.AddListener(OptionBtnClick);
        }

        if (ExitBtn != null)
        {
            ExitBtn.onClick.AddListener(ExitBtnClick);
        }
    }//--void Start()

    // Update is called once per frame
    void Update()
    {

    }

    private void StartBtnClick()
    {

        Debug.Log("Click");
        SceneManager.LoadScene("InGame");
    }

    private void OptionBtnClick()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("InOption");
    }

    private void ExitBtnClick()
    {
        Debug.Log("click");
        ExitGame();
    }

    public void ExitGame()
    {
        Debug.Log("종료");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

}
