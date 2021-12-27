using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Samples;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NetworkObject))]
[RequireComponent(typeof(ClientNetworkTransform))]
public class Player : NetworkBehaviour
{
    private CharacterController CharacterController;
    private Transform cam;
    public GameObject bullet;
    public Transform Mouth;
    public static List<Item.ItemClass> MyItems = new List<Item.ItemClass>();
    private float _userInputHorizontal, _userInputVertical, _userMouseHorizontal, _userMouseVertical;
    private Vector3 MoveDir, direction, rotation;
    public static Transform player;
    public static float attackspeed, speed;
    public static int hp;
    private bool Attack, abilitytofire = true;
    private static int CurrentClass;
    public LayerMask EnemyLayers;
    public class Class
    {
        public string name;
        public int hp;
        public float attackspeed, speed, damage, range;

    }
    public static List<Class> Classes = new List<Class>
    {
        new Class{name = "Mage", hp = 80, attackspeed = 0.5f, speed = 7f, damage = 10f, range = 2f},
        new Class{name = "Warrior", hp = 120, attackspeed = 0.75f, speed = 4f, damage = 15f, range = 1f}
    };

    public static void ChangeClass(string ChosenClass)
    {
        if (ChosenClass == "Mage")
        {
            CurrentClass = 0;
        }
        else if(ChosenClass == "Warrior")
        {
            CurrentClass = 1;
        }

    }
    void FireDelay()
    {
        abilitytofire = true;
    }

    public static void HideRooms(int x, int z)
    {
        Vector2Int p = new Vector2Int(x/18 + 5, z/18 + 5);
        int maxX = RoomPlacer.SpawnedRooms.GetLength(0) - 1;
        int maxY = RoomPlacer.SpawnedRooms.GetLength(1) - 1;
        List<Vector2Int> neighbours = new List<Vector2Int>();
        if (RoomPlacer.SpawnedRooms[p.x, p.y].DoorTop != null && p.y < maxY && RoomPlacer.SpawnedRooms[p.x, p.y + 1]?.DoorBottom != null)
        {
            Vector2Int room = new Vector2Int(p.x, p.y + 1); 
            neighbours.Add(room);
        }
        if (RoomPlacer.SpawnedRooms[p.x, p.y].DoorBottom != null && p.y > 0 && RoomPlacer.SpawnedRooms[p.x, p.y - 1]?.DoorTop != null)
        {
            Vector2Int room = new Vector2Int(p.x, p.y - 1); 
            neighbours.Add(room);
        }
        if (RoomPlacer.SpawnedRooms[p.x, p.y].DoorRight != null && p.x < maxX && RoomPlacer.SpawnedRooms[p.x + 1, p.y]?.DoorLeft != null)
        {
            Vector2Int room = new Vector2Int(p.x + 1, p.y); 
            neighbours.Add(room);
        }
        if (RoomPlacer.SpawnedRooms[p.x, p.y].DoorLeft != null && p.x > 0 && RoomPlacer.SpawnedRooms[p.x - 1, p.y]?.DoorRight != null)
        {
            Vector2Int room = new Vector2Int(p.x - 1, p.y); 
            neighbours.Add(room);
        }
        
        for (int i = 0; i <= maxX; i++)
        {
            for (int j = 0; j <= maxY; j++)
            {
                if (p.x == i && p.y == j)
                {
                    continue;
                }
                if (neighbours.Count == 4 && RoomPlacer.SpawnedRooms[i,j] != null)
                {
                    if ((neighbours[0].x == i && neighbours[0].y == j) || (neighbours[1].x == i && neighbours[1].y == j) || (neighbours[2].x == i && neighbours[2].y == j) || (neighbours[3].x == i && neighbours[3].y == j))
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(true);
                    }
                    else
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(false);
                    }
                }
                else if (neighbours.Count == 3 && RoomPlacer.SpawnedRooms[i,j] != null)
                {
                    if ((neighbours[0].x == i && neighbours[0].y == j) || (neighbours[1].x == i && neighbours[1].y == j) || (neighbours[2].x == i && neighbours[2].y == j))
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(true);
                    }
                    else
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(false);
                    }
                }
                else if (neighbours.Count == 2 && RoomPlacer.SpawnedRooms[i,j] != null)
                {
                    if ((neighbours[0].x == i && neighbours[0].y == j) || (neighbours[1].x == i && neighbours[1].y == j))
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(true);
                    }
                    else
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(false);
                    }
                }
                else if (neighbours.Count == 1 && RoomPlacer.SpawnedRooms[i,j] != null)
                {
                    if (neighbours[0].x == i && neighbours[0].y == j)
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(true);
                    }
                    else
                    {
                        RoomPlacer.SpawnedRooms[i,j].gameObject.SetActive(false);
                    }
                }
            }
        }
    }
    
    private void Start()
    {
        CharacterController = transform.GetComponent<CharacterController>();
        if (IsClient && IsOwner)
        {
            transform.position = new Vector3(Random.Range(-1, 1), 0.5f ,Random.Range(-1, 1));
            cam = CameraScript.Follow(transform);
        }
        Cursor.lockState = CursorLockMode.Locked;
        attackspeed = Classes[CurrentClass].attackspeed;
        speed = Classes[CurrentClass].speed;
        PlayerCombat.damage = Classes[CurrentClass].damage;
        PlayerCombat.range = Classes[CurrentClass].range;
        hp = Classes[CurrentClass].hp;
        CanvasScript.StatsChanged();
    }

    private void Update()
    {
        if (IsClient && IsOwner)
        {
            ClientInput();
        }
    }

    
    void ClientInput()
    {
        _userMouseHorizontal += Input.GetAxis("Mouse X");
        rotation = new Vector3(0, _userMouseHorizontal * 2f, 0);
        transform.localRotation = Quaternion.Euler(rotation);
        
        _userInputHorizontal = Input.GetAxisRaw("Horizontal");
        _userInputVertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(_userInputHorizontal * speed, 0, _userInputVertical * speed);
        if (direction.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            MoveDir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            CharacterController.Move(MoveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            MoveDir = Vector3.zero;
            CharacterController.Move(MoveDir.normalized * speed * Time.deltaTime);
        }
    }


    
   /*
        if (Input.GetMouseButton(0) && abilitytofire)
        {
            Attack = true;
            AttackEvent();
            abilitytofire = false;
            Invoke("FireDelay", attackspeed);
        }

    }*/
   

    private void AttackEvent()
    {
        if (Attack && CurrentClass == 0)
        {
            Instantiate(bullet, Mouth.position, transform.rotation);
            Attack = false;
        }
        else if (Attack && CurrentClass == 1)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(Mouth.position, PlayerCombat.range, EnemyLayers);
            foreach (Collider enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage();
            }
            Attack = false;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Mouth.position, PlayerCombat.range);
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
        if (other.gameObject.layer == 12)
        {
            HideRooms((int)other.transform.parent.gameObject.transform.position.x, (int)other.transform.parent.gameObject.transform.position.z);
        }
        
    }


    private void ChangeStats(int ID)
    {
        attackspeed += Item.AllItems[ID].tears;
        speed += Item.AllItems[ID].speed;
        global::PlayerCombat.range += Item.AllItems[ID].range;
        global::PlayerCombat.shotspeed += Item.AllItems[ID].shotspeed;
        
    }
}