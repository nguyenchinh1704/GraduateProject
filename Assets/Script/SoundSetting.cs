using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    public static float musicVolume { get; private set; }
   public static float sfxVolume { get; private set; }

    [SerializeField] private Text musicSliderInGame, musicSliderInStart;
    [SerializeField] private Text sfxSliderInGame, sfxSliderInStart;

    
    public void OnMusicSlider(float value)
    {
        musicVolume = value;
        musicSliderInGame.text =((int)(value * 100)).ToString() + "%";
        musicSliderInStart.text = ((int)(value * 100)).ToString() + "%";
        PlayerController.instance.music.volume = value;
    }

    public void OnSFXSlider(float value)
    {
        sfxVolume = value;
        sfxSliderInGame.text = ((int)(value * 100)).ToString() + "%";
        sfxSliderInStart.text = ((int)(value * 100)).ToString() + "%";
        PlayerController.instance.SFXCoin.volume = value;
    }

}
