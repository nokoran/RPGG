using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public class ItemClass
    {
        public Sprite _sprite ;
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
    
    void Start()
    {

    }
    public static void load()
    {
        Item.AllItems.Add(new Item.ItemClass()
        {
            _sprite = (Sprite)Resources.Load("ItemBotinok", typeof(Sprite)),
            _material = (Material)Resources.Load("ItemBotinok", typeof(Material)),
            ID = 1,
            tears = 0f,
            speed = 2f,
            range = 0f,
            shotspeed = 0f
        });
    }
}
