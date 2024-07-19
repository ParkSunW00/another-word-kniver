using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AudioEventManager : MonoBehaviour
{
    public Slider AudioSlider;

    // Start is called before the first frame update
    void Start()
    {
        AudioSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    public void ValueChangeCheck()
    {
        //Debug.Log(AudioSlider.value);
        BGMManager.instance.SetVolume(AudioSlider.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
