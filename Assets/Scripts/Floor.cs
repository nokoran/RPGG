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
        int rng =  Random.Range(0, 2);
        if (rng == 1)
        {
            sr.sprite = tilesprite;
            sr.material = TileMaterial;
        }
        else
        {
            sr.sprite = DefaultSprite;
            sr.material = defaultMaterial;
        }
    }

    private void Update()
    {
        int rng =  Random.Range(0, 2);
        if (rng == 1)
        {
            sr.sprite = tilesprite;
            sr.material = TileMaterial;
        }
        else
        {
            sr.sprite = DefaultSprite;
            sr.material = defaultMaterial;
        }
    }
}
