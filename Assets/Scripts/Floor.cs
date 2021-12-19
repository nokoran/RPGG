using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Sprite defaultsprite, tilesprite;
    public SpriteRenderer sr;
    void Start()
    {
        sr.sprite = Random.Range(0, 2) == 1 ? defaultsprite : tilesprite;
    }
}
