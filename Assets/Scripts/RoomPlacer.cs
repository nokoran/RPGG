using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomPlacer : MonoBehaviour
{
    public Room[] RoomPrefabs;
    public Room StartingRoom;
    private Room[,] SpawnedRooms;
    public bool bossex;
    public static int NewItem;
    private IEnumerator Start()
    {
        Item.load();
        SpawnedRooms = new Room[11, 11];
        SpawnedRooms[5, 5] = StartingRoom;

        for (int i = 0; i<20; i++)
        {
            PlaceOneRoom(bossex);
            yield return new WaitForSecondsRealtime(0.01f);
        }
        bossex = true;
        PlaceOneRoom(bossex);
    }
    private void PlaceOneRoom(bool bossex)
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < SpawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < SpawnedRooms.GetLength(1); y++)
            {
                if (SpawnedRooms[x, y] == null) continue;
                int maxX = SpawnedRooms.GetLength(0) - 1;
                int maxY = SpawnedRooms.GetLength(1) - 1;
                if (x > 0 && SpawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && SpawnedRooms[x, y-1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && SpawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && SpawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }
        if (!bossex)
        {
            int a = 3;
            Room newRoom = Instantiate(RoomPrefabs[Random.Range(a, RoomPrefabs.Length)]);
            int limit = 500;
            while (limit-- > 0)
            {
                Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));


                if (ConnectToSomething(newRoom, position, bossex))
                {
                    newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 14;
                    SpawnedRooms[position.x, position.y] = newRoom;
                    return;
                }
            }
            Destroy(newRoom.gameObject);
        }
        else
        {
            int limit = 100;
            int a = 0;
        M2:

            Room newRoom = Instantiate(RoomPrefabs[a]);
            while (limit-- > 0)
            {
                Debug.Log(limit);
            M1:
                Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
                if ((position.x < 4 || position.x > 6) && (position.y < 4 || position.y > 6))
                {
                }
                else
                {
                    goto M1;
                }


                if (ConnectToSomething(newRoom, position, bossex))
                {
                    newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 14;
                    SpawnedRooms[position.x, position.y] = newRoom;
                    vacantPlaces.Remove(position);
                    if (a == 3)
                    {
                        return;
                    }
                    else
                    {
                        if (a == 1)
                        {
                            NewItem = Item.RandomizeItem();
                            ItemSprite.SpriteChange();
                        }
                        a++;
                        goto M2;
                    }
                    
                }
                else
                {
                    Destroy(newRoom.gameObject);
                    goto M2;
                }
            }
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
            Destroy(newRoom.gameObject);
        }
    }
    
    private bool ConnectToSomething(Room room, Vector2Int p, bool bossex)
    {
        int count = 0;
        int maxX = SpawnedRooms.GetLength(0) - 1;
        int maxY = SpawnedRooms.GetLength(1) - 1;
        List<Vector2Int> neighbours = new List<Vector2Int>();
        if (room.DoorTop != null && p.y < maxY && SpawnedRooms[p.x, p.y + 1]?.DoorBottom != null) neighbours.Add(Vector2Int.up);
        if (room.DoorBottom != null && p.y > 0 && SpawnedRooms[p.x, p.y - 1]?.DoorTop != null) neighbours.Add(Vector2Int.down);
        if (room.DoorRight != null && p.x < maxX && SpawnedRooms[p.x + 1, p.y]?.DoorLeft != null) neighbours.Add(Vector2Int.right);
        if (room.DoorLeft != null && p.x > 0 && SpawnedRooms[p.x - 1, p.y]?.DoorRight != null) neighbours.Add(Vector2Int.left);

        if(neighbours.Count == 0)
        {
            return false;
        }
        if (bossex)
        {
            if (p.y != 10)
            {
                if (SpawnedRooms[p.x, p.y + 1] != null)
                {
                    count++;
                }
            }
            if (p.y != 0)
            {
                if (SpawnedRooms[p.x, p.y - 1] != null)
                {
                    count++;
                }
            }
            if (p.x != 10)
            {
                if (SpawnedRooms[p.x + 1, p.y] != null)
                {
                    count++;
                }
            }
            if (p.x != 0)
            {
                if (SpawnedRooms[p.x - 1, p.y] != null)
                {
                    count++;
                }
            }
            if (count != 1)
            {
                return false;
            }
        }
        for (int i = 0; i < neighbours.Count; i++)
        {
            Vector2Int selectedDirection = neighbours[i];
            Room selectedRoom = SpawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

            if (selectedDirection == Vector2Int.up)
            {
                room.DoorTop.SetActive(false);
                selectedRoom.DoorBottom.SetActive(false);
            }
            else if (selectedDirection == Vector2Int.down)
            {
                room.DoorBottom.SetActive(false);
                selectedRoom.DoorTop.SetActive(false);
            }
            else if (selectedDirection == Vector2Int.right)
            {
                room.DoorRight.SetActive(false);
                selectedRoom.DoorLeft.SetActive(false);
            }
            else if (selectedDirection == Vector2Int.left)
            {
                room.DoorLeft.SetActive(false);
                selectedRoom.DoorRight.SetActive(false);
            }
        }
        return true;
    }
}
