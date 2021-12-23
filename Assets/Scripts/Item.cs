using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public class ItemClass
    {
        public Sprite _sprite ; 
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

        AllItems.Add(new ItemClass()
        {
            _sprite = (Sprite) Resources.Load("ItemBotinok", typeof(Sprite)),
            ID = 1,
            tears = 0f,
            speed = 2f,
            range = 0f,
            shotspeed = 0f
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
