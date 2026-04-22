// using UnityEngine;

// public class PopUpSkor : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
using UnityEngine;
using UnityEngine.UI;

public class PopUpSkor : MonoBehaviour
{
    public GameObject panelSkor;   // Panel pop-up
    public Text textSkor;          // Text untuk menampilkan skor

    // Fungsi untuk menampilkan pop-up skor
    public void TampilkanSkor()
    {
        int totalSkor = PlayerPrefs.GetInt("skor", 0);
        textSkor.text = "Total Skor Kamu: " + totalSkor.ToString();
        panelSkor.SetActive(true);
    }

    // Fungsi untuk menutup pop-up
    public void TutupSkor()
    {
        panelSkor.SetActive(false);
    }
}