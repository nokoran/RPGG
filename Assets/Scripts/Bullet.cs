using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float range = 1f, shotspeed = 0.5f, damage = 10f;
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            Destroy();
        }
    }
}
