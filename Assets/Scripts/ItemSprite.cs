using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprite : MonoBehaviour
{
    public static MeshFilter mf;
    public static MeshRenderer mr;
    public void Awake()
    {
        mf = transform.GetComponent<MeshFilter>();
        mr = transform.GetComponent<MeshRenderer>();
    }
    public static void SpriteChange()
    {

        mf.mesh = Item.AllItems[RoomPlacer.NewItem]._mesh;
        mr.material = Item.AllItems[RoomPlacer.NewItem]._material;
    }
}
