using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Slider volumeSlider;
    public Button BackBtn;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bgm = GameObject.Find("BgmManager");

        if (volumeSlider != null)
        {
            volumeSlider.value = volumeSlider.value;
        }

        if (BackBtn != null)
        {
            BackBtn.onClick.AddListener(BackBtnClick);
        }
    }

    private void BackBtnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
