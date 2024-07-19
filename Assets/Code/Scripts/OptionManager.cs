using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Slider volumeSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject bgm = GameObject.Find("BgmManager");

        if (volumeSlider != null)
        {
            volumeSlider.value = volumeSlider.value;
        }
    }



}
