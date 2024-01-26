using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachable : MonoBehaviour
{
    private GameObject _attachObject;
    private GameObject _attachPrefab;
    public GameObject AttachObject
    {
        get
        {
            Destroy(_attachObject);
            return _attachPrefab;
        }
        set
        {
            _attachPrefab = value;
            _attachObject = Attach(value);
        }
    }

    public float AttachObjectDeltaPositionZ;

    private GameObject Attach(GameObject attachObject)
    {
        GameObject instance;
        instance = Instantiate(attachObject, transform);
        instance.transform.position += new Vector3(0, 0, AttachObjectDeltaPositionZ);
        Rigidbody2D[] rigidbody2Ds = instance.GetComponentsInChildren<Rigidbody2D>();
        foreach (var rigidbody2D in rigidbody2Ds)
        {
            rigidbody2D.simulated = false;
        }
        return instance;
    }
}
