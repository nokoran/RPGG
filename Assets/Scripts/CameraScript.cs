using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private static Transform camtransform;
    private void Awake()
    {
        camtransform = transform;
    }

    public static void Follow(Transform target)
    {
        camtransform.SetParent(target, false);
    }
}
