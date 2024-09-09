using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melody : MonoBehaviour
{
    public int segments = 32;
    public float radius = 5f;

    void Start()
    {
        CreateCircle();
    }

    void CreateCircle()
    {
        GameObject circleObject = new GameObject("CircleObject");
    }
}
