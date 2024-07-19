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
    public Button BestRecBtn;
    public Button SkillBtn;
    public Button OptionBtn;

    //OptionPanelObject
    public GameObject OptionPanel;

    public Button SoundOptionBtn;
    public Button ExitBtn;


    void Start()
    {
        if (StartBtn != null)
        {
            StartBtn.onClick.AddListener(StartBtnClick);
        }

        if (SkillBtn != null)
        {
            SkillBtn.onClick.AddListener(SkillBtnClick);
        }

        if (OptionBtn != null)
        {
            OptionBtn.onClick.AddListener(OptionBtnClick);
        }

        if (BestRecBtn != null)
        {
            BestRecBtn.onClick.AddListener(BestRecBtnClick);
        }

        //OptionPanel

        if (ExitBtn != null)
        {
            ExitBtn.onClick.AddListener(ExitBtnClick);
        }

        if (SoundOptionBtn != null)
        {
            SoundOptionBtn.onClick.AddListener(SoundOptionBtnClick);
        }
    }//--void Start()


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKeyDown(KeyCode.Space))
        {
            StartBtnClick();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SkillBtnClick();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionPanel.SetActive(false);
        }
    }


    private void StartBtnClick()
    {
        SceneManager.LoadScene("InGame");
    }

    private void BestRecBtnClick()
    {
        SceneManager.LoadScene("Rank");
    }

    private void SkillBtnClick()
    {
        SceneManager.LoadScene("Rank");
    }


    private void OptionBtnClick()
    {
        TogglePanel();


    }

    private void ExitBtnClick()
    {
        ExitGame();
    }

    private void SoundOptionBtnClick()
    {
        SceneManager.LoadScene("Option");
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

    private void TogglePanel()
    {
        OptionPanel.SetActive(true);
        
    }

}
