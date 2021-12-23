using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
    public int type;
    public Material BossTile2, ItemTile2, ShopTile2, DefaultTile2;
    public MeshRenderer mr;
    void Start()
    {
        int rng =  Random.Range(0, 3);
        if (type == 0)
        {
            if (rng == 1)
            {
                mr.material = BossTile2;
            }
        }
        if (type == 1)
        {
            if (rng == 1)
            {
                mr.material = ItemTile2;
            }
        }
        if (type == 2)
        {
            if (rng == 1)
            {
                mr.material = ShopTile2;
            }
        }
        if (type == 3)
        {
            if (rng == 1)
            {
                mr.material = DefaultTile2;
            }
        }
    }
}
