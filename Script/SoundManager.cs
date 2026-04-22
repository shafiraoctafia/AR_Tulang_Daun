using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip[] Clip;

    public AudioSource source_sfx;

    public AudioSource source_bgm;  

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Panggil_sfx(int id)
    {
        source_sfx.PlayOneShot(Clip[id]);
    }


    // public Slider sliderMusic;
    // public AudioSource sumberSuara;
    // public float volume = 1f;

    // public const string keyVolume = "VOLUME";

    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }



    // private void Start()
    // {
    //     float volumeTerakhir = PlayerPrefs.GetFloat(keyVolume, 1f);
    //     SliderDiUbah(volumeTerakhir);

    //     if (sliderMusic != null)
    //     {
    //         sliderMusic.value = volumeTerakhir;
    //         sliderMusic.onValueChanged.AddListener(SliderDiUbah);
    //     }
    // }

    // public void SliderDiUbah(float nilaiSlider)
    // {
    //     volume = nilaiSlider;
    //     sumberSuara.volume = nilaiSlider;
    //     PlayerPrefs.SetFloat(keyVolume, nilaiSlider);
    // }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class SoundManager : MonoBehaviour
// {
//     public static SoundManager Instance;

//     public Slider sliderMusic;
//     public AudioSource sumberSuara;
//     public float volume = 1f;

//     public const string keyVolume = "VOLUME";

//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//             DontDestroyOnLoad(gameObject);
//             Debug.Log("SoundManager aktif: " + gameObject.name);
//         }
//         else
//         {
//             Debug.Log("SoundManager duplikat dihancurkan: " + gameObject.name);
//             Destroy(gameObject);
//         }
//     }

//     private void Start()
//     {
//         // Ambil volume terakhir dari PlayerPrefs
//         float volumeTerakhir = PlayerPrefs.GetFloat(keyVolume, 1f);
//         volume = volumeTerakhir;

//         // Atur volume ke sumber suara
//         if (sumberSuara == null)
//         {
//             Debug.LogWarning("sumberSuara belum diisi!");
//             return;
//         }

//         sumberSuara.volume = volume;

//         if (!sumberSuara.isPlaying)
//         {
//             sumberSuara.Play();
//         }

//         // Cari slider jika belum terisi
//         if (sliderMusic == null)
//         {
//             GameObject soundManagerObj = GameObject.Find("Sound Manager");
//             if (soundManagerObj != null)
//             {
//                 sliderMusic = soundManagerObj.GetComponentInChildren<Slider>();
//                 if (sliderMusic != null)
//                 {
//                     Debug.Log("Slider ditemukan dan disambungkan ulang.");
//                     SetSlider(sliderMusic);
//                 }
//                 else
//                 {
//                     Debug.LogWarning("Slider tidak ditemukan di dalam Sound Manager.");
//                 }
//             }
//             else
//             {
//                 Debug.LogWarning("GameObject 'Sound Manager' tidak ditemukan.");
//             }
//         }
//         else
//         {
//             SetSlider(sliderMusic);
//         }
//     }

//     public void SetSlider(Slider s)
//     {
//         sliderMusic = s;
//         sliderMusic.onValueChanged.RemoveAllListeners(); // Hindari listener ganda
//         sliderMusic.value = volume;                      // Sinkronkan tampilan slider
//         sliderMusic.onValueChanged.AddListener(SliderDiUbah);
//         SliderDiUbah(sliderMusic.value);                 // Terapkan langsung ke suara
//     }

//     public void SliderDiUbah(float nilaiSlider)
//     {
//         volume = nilaiSlider;
//         sumberSuara.volume = nilaiSlider;
//         PlayerPrefs.SetFloat(keyVolume, nilaiSlider);
//         Debug.Log("Volume diubah ke: " + nilaiSlider);
//     }

//     public void TerapkanKe(AudioSource target)
//     {
//         if (target != null)
//         {
//             target.volume = volume;
//         }
//     }
// }