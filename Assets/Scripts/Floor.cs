using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
    public Sprite tilesprite, DefaultSprite;
    [SerializeField] private Material TileMaterial, defaultMaterial;
    public SpriteRenderer sr;
    void Start()
    {
        int rng =  Random.Range(0, 3);
        if (rng == 1)
        {
            sr.sprite = DefaultSprite;
            sr.material = defaultMaterial;
        }
    }
}
