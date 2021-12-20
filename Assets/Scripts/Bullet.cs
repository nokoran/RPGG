using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask whatIsSolid;
    void Destroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        Invoke("Destroy", 1);
    }

    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, 0, whatIsSolid);
        if (hitInfo.collider != null)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
    }
}
