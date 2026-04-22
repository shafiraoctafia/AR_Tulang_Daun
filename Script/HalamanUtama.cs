using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HalamanUtama : MonoBehaviour
{
    public GameObject exitUI;
    public void Exit()
    {
        // audioSource.PlayOneShot(clipButton);
        exitUI.SetActive(false);
        exitUI.SetActive(true);
    }

    public void ExitYA()
    {
       Application.Quit();
       Debug.Log("Keluar Dari Aplikasi");
    }


    public void Panduan()
    {
        SceneManager.LoadScene("Halaman_Panduan");
    }

    public void Pengaturan()
    {
        SceneManager.LoadScene("Halaman_Pengaturan");
    }

    public void Play()
    {
        SceneManager.LoadScene("Halaman_Main");
    }

    public void Materi()
    {
        SceneManager.LoadScene("Halaman_Materi");
    }

    public void Kuis()
    {
        SceneManager.LoadScene("Halaman_Kuis");
        PlayerPrefs.SetInt("skor",0);
    }
    
    public void btn_suara (int id)
    {
        SoundManager.instance.Panggil_sfx(id);
    }


}
