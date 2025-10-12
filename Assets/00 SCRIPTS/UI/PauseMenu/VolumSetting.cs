using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumSetting : MonoBehaviour
{
    [SerializeField] protected AudioMixer _audioMixer;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Slider _sliderSFX;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Music")) this.LoadVolume();
        else
        {
            this.SetVolume();
            this.SetSFX();  
        }
    }

    public void SetVolume()
    {
        float volume = _slider.value;
        _audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetSFX()
    {
        float volume = _sliderSFX.value;
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFX", volume);
    }

    protected void LoadVolume()
    {
        _slider.value = PlayerPrefs.GetFloat("Music");
        _sliderSFX.value = PlayerPrefs.GetFloat("SFX");
        this.SetVolume();
        this.SetSFX();
    }
}
