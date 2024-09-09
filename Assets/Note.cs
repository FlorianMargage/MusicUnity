using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Note
{
    public AudioClip ClipAudio { get; set; }
    public NoteMusic NoteMusic { get; set; }
    public KeyCode KeyCode { get; set; }
    public Notes NoteName { get; set; }
    public Color Color { get; set; }

    public Note(KeyCode keyCode, Notes noteName, string color)
    {
        KeyCode = keyCode;
        NoteName = noteName;
        Color = HexToColor(color);
        NoteMusic = NoteEnToNoteFrMapper(noteName);
    }

    private Color HexToColor(string hex)
    {
        hex = hex.Replace("#", "");
        float r = Convert.ToInt32(hex.Substring(0, 2), 16) / 255f;
        float g = Convert.ToInt32(hex.Substring(2, 2), 16) / 255f;
        float b = Convert.ToInt32(hex.Substring(4, 2), 16) / 255f;

        return new Color(r, g, b);
    }

    private NoteMusic NoteEnToNoteFrMapper(Notes noteName)
    {
        switch(noteName)
        {
            case Notes.C:
                return NoteMusic.Do;
            case Notes.D:
                return NoteMusic.Ré;
            case Notes.E:
                return NoteMusic.Mi;
            case Notes.F:
                return NoteMusic.Fa;
            case Notes.G:
                return NoteMusic.Sol;
            case Notes.A:
                return NoteMusic.La;
            case Notes.B:
                return NoteMusic.Si;
            default:
                return NoteMusic.Do;
        }
        
    }
}


public enum Notes
{
    C,
    D,
    E,
    F,
    G,
    A,
    B
}


public enum NoteMusic
{
    Do,
    Ré,
    Mi,
    Fa,
    Sol,
    La,
    Si
}