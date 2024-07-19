using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    // 슬라이더
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        // 슬라이더를 최대값으로 설정
        if (volumeSlider != null)
        {
            volumeSlider.value = volumeSlider.maxValue;
        }
    }


}
