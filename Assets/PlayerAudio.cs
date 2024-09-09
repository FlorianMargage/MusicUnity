using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public List<AudioClip> notesClipList;
    private AudioSource _audioSource;
    private SpriteRenderer _render;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _render = GetComponent<SpriteRenderer>();

        foreach (var note in NotesList.All)
        {
            var audioClip = AssetDatabase.LoadAssetAtPath<AudioClip>($"Assets/audio/{note.NoteName}3.mp3");

            note.ClipAudio = audioClip;
            AssetDatabase.SaveAssets();

        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (char c in Input.inputString)
            {
                var note = NotesList.All.FirstOrDefault(note => (char)note.KeyCode == c);
                _audioSource.clip = note.ClipAudio;
                _audioSource.Play();
                _render.color = note.Color;
            }
        }
    }
}


public static class NotesList
{
    public static List<Note> All = new List<Note>()
    {
         new Note(KeyCode.Q, Notes.C, "#7C85F2"),
         new Note(KeyCode.S, Notes.D, "#AF3B6E"),
         new Note(KeyCode.D, Notes.E, "#424651"),
         new Note(KeyCode.F, Notes.F, "#21FA90"),
         new Note(KeyCode.G, Notes.G, "#ACAD94"),
         new Note(KeyCode.H, Notes.A, "#D8D4D5"),
         new Note(KeyCode.J, Notes.B, "#384D48")
    };
}

