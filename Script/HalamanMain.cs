using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class HalamanMain : MonoBehaviour
{
    // Referensi ke semua objek daun
    public GameObject daunMenyirip;
    public GameObject daunMenjari;
    public GameObject daunMelengkung;
    public GameObject daunSejajar;

    public GameObject dikotil;
    public GameObject monokotil;

    public GameObject btnAnim;
    public GameObject btnSwitch;
    public GameObject btnBiji;

    // Animator masing-masing daun
    public Animator animMenyirip;
    public Animator animMenjari;
    public Animator animMelengkung;
    public Animator animSejajar;

    // Untuk kontrol visibilitas
    private bool isVisible = true;

    // Daftar nama marker
    public string[] markerNames = { "TD_Menyirip", "T_Menjari", "TD_Melengkung", "TD_Sejajar" };

    // Daftar target marker (isi di Inspector sesuai urutan nama)
    public ObserverBehaviour[] markers;

    // Marker yang sedang aktif
    private HashSet<string> activeMarkers = new HashSet<string>();

    void Start()
    {
        // Daftarkan event untuk setiap marker
        for (int i = 0; i < markers.Length; i++)
        {
            string name = markerNames[i];
            ObserverBehaviour marker = markers[i];

            marker.OnTargetStatusChanged += (behaviour, status) =>
            {
                bool isDetected = status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED;

                if (isDetected)
                    activeMarkers.Add(name);
                else
                    activeMarkers.Remove(name);

                UpdateButtons();
            };
        }
    }

    void UpdateButtons()
    {
        dikotil.SetActive(false);
        monokotil.SetActive(false);
        btnAnim.SetActive(false);
        btnSwitch.SetActive(false);
        btnBiji.SetActive(false);

        // Jika ada marker aktif, tampilkan tombol biji
        foreach (string name in activeMarkers)
        {
            if (System.Array.Exists(markerNames, m => m == name))
            {
                btnAnim.SetActive(true);
                btnSwitch.SetActive(true);
                btnBiji.SetActive(true);
                break;
            }
        }
    }



    public void ToggleBiji()
    {
        // Cek apakah marker dikotil aktif
        bool isDikotilActive = activeMarkers.Contains("TD_Menyirip") || activeMarkers.Contains("T_Menjari");

        // Cek apakah marker monokotil aktif
        bool isMonokotilActive = activeMarkers.Contains("TD_Melengkung") || activeMarkers.Contains("TD_Sejajar");

        // Toggle panel dikotil jika marker dikotil aktif
        if (isDikotilActive)
        {
            bool currentState = dikotil.activeSelf;
            dikotil.SetActive(!currentState);
            monokotil.SetActive(false); // pastikan monokotil disembunyikan
        }
        // Toggle panel monokotil jika marker monokotil aktif
        else if (isMonokotilActive)
        {
            bool currentState = monokotil.activeSelf;
            monokotil.SetActive(!currentState);
            dikotil.SetActive(false); // pastikan dikotil disembunyikan
        }

    }

    // Fungsi untuk menampilkan/menyembunyikan semua daun
    public void ToggleDaun()
    {
        isVisible = !isVisible;
        daunMenyirip.SetActive(isVisible);
        daunMenjari.SetActive(isVisible);
        daunMelengkung.SetActive(isVisible);
        daunSejajar.SetActive(isVisible);
    }

    // Fungsi untuk memutar animasi semua daun ketika tombol diklik
    public void PlayAllAnimation()
    {
        // Pastikan semua animator sudah diisi di inspector
        animMenyirip.SetTrigger("PlayAnim");
        animMenjari.SetTrigger("PlayAnim");
        animMelengkung.SetTrigger("PlayAnim");
        animSejajar.SetTrigger("PlayAnim");
    }


}
