using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class Challenge : MonoBehaviour
{
    private AudioSource _source;
    private List<GameObject> _buttons;
    private Note _trueNote;
    private Note _wrongNote1;
    private Note _wrongNote2;
    private System.Random _random;
    private int _score;
    private int _trueButton;

    public TMP_Text result;
    public TMP_Text scoreText;


    void Start()
    {
        _source = GetComponent<AudioSource>();
        _buttons = new List<GameObject>();
        result.text = "";
        scoreText.text = "Score : 0";
        _random = new System.Random();
        _score = 0;

        _buttons.Add(GameObject.Find("Answer_button_1"));
        _buttons.Add(GameObject.Find("Answer_button_2"));
        _buttons.Add(GameObject.Find("Answer_button_3"));

        GameObject.Find("Final_Result (TMP)").SetActive(false);
        GoNext();
    }

    void Shuffle()
    {
        _trueNote = getRandomNote();
        _wrongNote1= getRandomNote();
        _wrongNote2= getRandomNote();

        while (_wrongNote1 == _trueNote)
        {
            _wrongNote1 = getRandomNote();
        }
        while (_wrongNote2 == _trueNote || _wrongNote2 == _wrongNote1)
        {
            _wrongNote2 = getRandomNote();
        }

        _trueButton = _random.Next(3);
        OnClickPlaySound();
    }

    public void GoToResult()
    {
        foreach(GameObject btn in _buttons)
        {
            btn.SetActive(false);
        }
    }

    public void OnClickPlaySound()
    {
        _source.clip = _trueNote.ClipAudio;
        _source.Play();
    }

    public void OnClickButton1()
    {
        clickButton(0);
    }
    public void OnClickButton2()
    {
        clickButton(1);
    }
    public void OnClickButton3()
    {
        clickButton(2);
    }

    void clickButton(int button)
    {
        if (_trueButton == button)
        {
            _score++;
            scoreText.text = "Score : " + _score.ToString();
            result.text = $"Vrai, c'était {_trueNote.NoteMusic}";

            GoNext();
        }
        else
        {
            result.text = $"Réessayez";
            _buttons[button].SetActive(false);
        }
        
    }

    void GoNext()
    {
        Shuffle();
        for (int index = 0; index < 3; index++)
        {
            _buttons[index].SetActive(true);
            switch (index)
            {
                case 0:
                    _buttons[_trueButton % 3].GetComponentInChildren<TMP_Text>().text = _trueNote.NoteMusic.ToString();
                    break;
                case 1:
                    _buttons[(_trueButton + 1) % 3].GetComponentInChildren<TMP_Text>().text = _wrongNote1.NoteMusic.ToString();
                    break;
                case 2:
                    _buttons[(_trueButton + 2) % 3].GetComponentInChildren<TMP_Text>().text = _wrongNote2.NoteMusic.ToString();
                    break;
            }
        }
    }

    Note getRandomNote()
    {
        return NotesList.All[_random.Next(NotesList.All.Count())];
    }
}
