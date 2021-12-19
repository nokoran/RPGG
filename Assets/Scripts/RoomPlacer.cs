using System.Collections;
using System.Collections.Generic;
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
    }
}
