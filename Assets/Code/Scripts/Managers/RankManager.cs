using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class RankManager : MonoBehaviour
{
    public Button BackBtn;
    public Text MaxRankingText;

    // Start is called before the first frame update
    void Start()
    {
        int bestScore = 0;
        if(PlayerPrefs.HasKey("bestScore"))
        {
            bestScore = PlayerPrefs.GetInt("bestScore");
            
        }
        // 최고 기록 텍스트 업데이트
        UpdateMaxRankingText(bestScore);

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

    void UpdateMaxRankingText(int bestScore)
    {
        if (MaxRankingText != null)
        {
            MaxRankingText.text = bestScore.ToString();
        }
    }
}
