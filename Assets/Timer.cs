using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private bool _firstTime;
    private float _tempsDebut;
    private float _tempsEcoule;
    private GameObject _result;

    public TMP_Text timer;
    public TMP_Text result;
    public TMP_Text score;

    void Start()
    {
        _firstTime= true;
        _tempsDebut = 30f + Time.time;
        _result = GameObject.Find("Final_Result (TMP)");
    }

    void Update()
    {
        _tempsEcoule = _tempsDebut - Time.time;
        AfficherTemps(_tempsEcoule);
        if (_tempsEcoule <= 0 && _firstTime)
        {
            _firstTime = !_firstTime;
            foreach (GameObject btn in GameObject.FindGameObjectsWithTag("DisableBtn"))
            {
                btn.SetActive(false);
            }
            result.text = "Votre score est de "+score.text.Substring(8);
            _result.SetActive(true);
            
        }
    }

    void AfficherTemps(float temps)
    {
        int minutes = Mathf.FloorToInt(temps / 60);
        int secondes = Mathf.FloorToInt(temps % 60);
        timer.text = "Timer : "+string.Format("{0:00}:{1:00}", minutes, secondes);
    }

    
}

