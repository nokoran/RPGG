using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    public static SpriteRenderer sr;
    public void Awake()
    {
        sr = transform.GetComponent<SpriteRenderer>();
    }
    public static void SpriteChange()
    {

        sr.sprite = Item.AllItems[RoomPlacer.NewItem]._sprite;
        sr.material = Item.AllItems[RoomPlacer.NewItem]._material;
    }
}
