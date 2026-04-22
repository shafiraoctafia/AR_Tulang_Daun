using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hasil : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // PlayerPrefs.SetInt("skor",0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text> ().text = PlayerPrefs.GetInt ("skor").ToString();
        
    }
    
    void OnEnable()
    {
        int skor = PlayerPrefs.GetInt("skor");
        GetComponent<Text>().text = "Skor Kamu: " + skor.ToString();
    }

}

