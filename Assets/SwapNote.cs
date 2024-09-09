using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class SwapNote : MonoBehaviour
{
    public TMP_Text _swap;
    private SpriteRenderer _rendererCircle;
    

    void Start()
    {
        _rendererCircle = GameObject.Find("Circle").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_rendererCircle.color != Color.white)
        {
            _swap.text = NotesList.All.FirstOrDefault(note => (Color)note.Color == _rendererCircle.color).NoteMusic.ToString();
        }
        
    }
}
