using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPengaturan : MonoBehaviour
{
    public Slider Slider_SFX, Slider_BGM;

    private void OnEnable()
    {
        Slider_SFX.value = SoundManager.instance.source_sfx.volume;
        Slider_BGM.value = SoundManager.instance.source_bgm.volume;
    }

    public void UbahVolume(bool SFX)
    {
        if(SFX)
        {
            SoundManager.instance.source_sfx.volume = Slider_SFX.value;
        }
        else
        {
            SoundManager.instance.source_bgm.volume = Slider_BGM.value;
        }
    }

}