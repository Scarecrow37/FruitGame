using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progressable : MonoBehaviour
{
    public static Progressable instance;
    private string _buffer;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void Progress(string collisionObjectName, GameObject progressObject, Vector3 instantiatePosition)
    {
        if (_buffer == collisionObjectName)
        {
            Instantiate(progressObject, instantiatePosition, new Quaternion());
            _buffer = null;
        }
        else
        {
            _buffer = collisionObjectName;
        }
    }
}
