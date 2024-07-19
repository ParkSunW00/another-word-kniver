using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class RankManager : MonoBehaviour
{
    public Button BackBtn;

    // Start is called before the first frame update
    void Start()
    {
        if (BackBtn != null)
        {
            BackBtn.onClick.AddListener(BackBtnClick);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BackBtnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
