using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jawaban : MonoBehaviour
{
    public GameObject PopUp_benar, PopUp_salah;
    public GameObject panelSkor;
    public TextMeshProUGUI teksNomorSoal;
    int skor;
    int nomorSoal;
    int totalSoal;

     // Flag agar pengacakan hanya dilakukan sekali
    private static bool sudahDiacak = false;

    void Start()
    {
        totalSoal = transform.parent.childCount;

        if (!sudahDiacak)
        {
            AcakSoal();
            sudahDiacak = true;

            // Aktifkan soal pertama
            for (int i = 0; i < transform.parent.childCount; i++)
                transform.parent.GetChild(i).gameObject.SetActive(false);

            transform.parent.GetChild(0).gameObject.SetActive(true);

             UpdateNomorSoal(0);
        }

    }

    // Fungsi dipanggil saat jawaban diklik
    public void jawab(bool jawaban)
    {
        if (jawaban)
        {
            // Munculkan popup benar
            SoundManager.instance.Panggil_sfx(1);
            PopUp_benar.SetActive(false);
            PopUp_benar.SetActive(true);

            // Tambah skor
            skor = PlayerPrefs.GetInt("skor") + 10;
            PlayerPrefs.SetInt("skor", skor);


            // Jalankan jeda sebelum lanjut soal berikutnya
            StartCoroutine(LanjutSoalDenganJeda());
        }
        else
        {
            // Munculkan popup salah
            SoundManager.instance.Panggil_sfx(2);
            PopUp_salah.SetActive(false);
            PopUp_salah.SetActive(true);

            // Jalankan jeda sebelum lanjut soal berikutnya
            StartCoroutine(LanjutSoalDenganJeda());
        }
    }

    // Coroutine untuk kasih delay
    IEnumerator LanjutSoalDenganJeda()
    {
        yield return new WaitForSeconds(1f); // jeda 1 detik

        // Matikan soal sekarang
        gameObject.SetActive(false);

        int nextIndex = transform.GetSiblingIndex() + 1;

        // // Nomor Soal
        // nomorSoal = nextIndex;
        // teksNomorSoal.text = (nomorSoal) + " / 10";

        // Kalau masih ada soal → tampilkan soal berikutnya
        if (nextIndex < transform.parent.childCount)
        {
            transform.parent.GetChild(nextIndex).gameObject.SetActive(true);

             UpdateNomorSoal(nextIndex);
        }
    else
    {
    if (panelSkor != null)
    //  PlayerPrefs.SetInt("skor", skor);
    SoundManager.instance.Panggil_sfx(3);
        panelSkor.SetActive(true);
        
        }

    }

    void AcakSoal()
    {
        Transform parent = transform.parent;
        int jumlah = parent.childCount;

        for (int i = 0; i < jumlah; i++)
        {
            int acakIndex = Random.Range(i, jumlah);
            parent.GetChild(acakIndex).SetSiblingIndex(i);
        }
    }
    void UpdateNomorSoal(int index)
    {
        teksNomorSoal.text = (index + 1) + "/" + totalSoal;
    }

}


