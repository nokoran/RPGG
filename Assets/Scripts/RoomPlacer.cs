using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomPlacer : MonoBehaviour
{
    public Room[] RoomPrefabs;
    public Room StartingRoom;
    private Room[,] SpawnedRooms;
    void Start()
    {
        SpawnedRooms = new Room[11, 11];
        SpawnedRooms[5, 5] = StartingRoom;

        for (int i = 0; i<12; i++)
        {
            PlaceOneRoom();
        }
    }
    private void PlaceOneRoom()
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
        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);
        Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
    }
}
