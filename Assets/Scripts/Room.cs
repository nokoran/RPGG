using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject DoorTop, DoorRight, DoorBottom, DoorLeft;
    public Transform[] floor;

    public void RotateRandomly()
    {
        int Count = Random.Range(0, 4);
        for(int i = 0; i < Count; i++)
        {
            transform.Rotate(0, 0, -90);
            for (int e = 0; e < floor.Length; e++)
            {
                floor[e].Rotate(new Vector3Int(0, 0, 90));
            }
            GameObject tmp = DoorLeft;
            DoorLeft = DoorBottom;
            DoorBottom = DoorRight;
            DoorRight = DoorTop;
            DoorTop = tmp;
        }
    }
}
