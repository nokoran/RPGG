using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public Rigidbody _rb;
    private float _userInputHorizontal, _userInputVertical;
    public static float tears = 0.5f, speed = 7;
    private Vector3 _vec;
    public static float angle;
    private bool fire = false, abilitytofire = true;
    public GameObject Bullet;
    public Transform Mouth;
    public static Vector3 position;
    public static List<Item.ItemClass> MyItems = new List<Item.ItemClass>();

    void FireDelay()
    {
        abilitytofire = true;
    }
    
    void Update()
    {
        position = transform.position;
        _userInputHorizontal = Input.GetAxis("Horizontal");
        _userInputVertical = Input.GetAxis("Vertical");
        //_vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //angle = Mathf.Atan2(_vec.y, _vec.x) * Mathf.Rad2Deg;
        if (Input.GetMouseButton(0) && abilitytofire)
        {
            fire = true;
            abilitytofire = false;
            Invoke("FireDelay", tears);
        }

    }

    private void FixedUpdate()
    {

        _rb.velocity = new Vector3(_userInputHorizontal*speed, _rb.velocity.y, _userInputVertical*speed);
        //_rb.rotation = angle;
        if (fire)
        {
            Instantiate(Bullet, Mouth.position, transform.rotation);
            fire = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            MyItems.Add(Item.AllItems[RoomPlacer.NewItem]);
            ChangeStats(RoomPlacer.NewItem);
            CanvasScript.StatsChanged();
            CanvasScript.AddNewItem(Item.AllItems[RoomPlacer.NewItem]._Sprite);
            Destroy(other.gameObject);
        }
    }

    private void ChangeStats(int ID)
    {
        tears += Item.AllItems[ID].tears;
        speed += Item.AllItems[ID].speed;
        global::Bullet.range += Item.AllItems[ID].range;
        global::Bullet.shotspeed += Item.AllItems[ID].shotspeed;
        
    }
}