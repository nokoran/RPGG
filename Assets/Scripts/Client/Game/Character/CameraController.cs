using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private static Transform camtransform;
    private void Awake()
    {
        camtransform = transform;
    }

    public static Transform Follow(Transform target)
    {
        camtransform.SetParent(target, false);
        Transform cam = camtransform;
        return cam;
    }
}
