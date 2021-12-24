using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Player : MonoBehaviour
{
    public Transform cam;
    public CharacterController cc;
    private float turnSmoothTime = 0.1f, turmSmoothVelocity;
    private float _userInputHorizontal, _userInputVertical, _userMouseHorizontal, _userMouseVertical;
    public static float tears = 0.5f, speed = 7;
    private Vector3 _vec;
    private bool fire, abilitytofire = true;
    public GameObject Bullet;
    public Transform Mouth;
    public static List<Item.ItemClass> MyItems = new List<Item.ItemClass>();

    void FireDelay()
    {
        abilitytofire = true;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _userInputHorizontal = Input.GetAxisRaw("Horizontal");
        _userInputVertical = Input.GetAxisRaw("Vertical");
        _userMouseHorizontal += Input.GetAxis("Mouse X");
        _userMouseVertical += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(0, _userMouseHorizontal * 2f, 0);
        Vector3 direction = new Vector3(_userInputHorizontal*speed, 0, _userInputVertical*speed);
        if (direction.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turmSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);
            
            Vector3 MoveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            cc.Move(MoveDir.normalized * speed * Time.deltaTime);
        }
        
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
        //Vector3 direction = new Vector3(_userInputHorizontal*speed, _rb.velocity.y, _userInputVertical*speed);
        //_rb.velocity = direction.normalized;
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