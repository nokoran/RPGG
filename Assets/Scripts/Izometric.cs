using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Izometric : MonoBehaviour
{
    void Update()
    {
        if (Player.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
}
