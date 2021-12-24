using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask whatIsSolid;
    public static float range = 1f, shotspeed = 2f;
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

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0, whatIsSolid);
        if (hitInfo.collider != null)
        {
            Destroy();
        }
        transform.Translate(Vector3.forward * (shotspeed * 10) * Time.deltaTime);
    }
}
