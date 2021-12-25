using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public class ItemClass
    {
        public Mesh _mesh ;
        public Sprite _Sprite;
        public Material _material;
        public float tears, speed, range, shotspeed;
        public int ID;
    }
    
    public static List<ItemClass> AllItems = new List<ItemClass>();

    public static int RandomizeItem()
    {
        int ID = Random.Range(0, AllItems.Count);
        Debug.Log(ID);
        return ID;
    }
    public static void load()
    {
        Item.AllItems.Add(new Item.ItemClass()
        {
            _Sprite = Resources.Load<Sprite>("Sprites/Boots"),
            _mesh = Resources.Load<GameObject>("Vox/Boots").transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh,
            _material = Resources.Load<Material>("Materials/Boots"),
            ID = 1,
            tears = 0f,
            speed = 2f,
            range = 0f,
            shotspeed = 0f
        });
    }
}
