using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static float range, shotspeed = 2f, damage;
    void Destroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        Invoke("Destroy", range);
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (shotspeed * 10) * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            Destroy();
        }
    }
}
