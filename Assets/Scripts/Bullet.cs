using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

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
        transform.Translate(Vector2.right * 10 * Time.deltaTime);
    }
}
