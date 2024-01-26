using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Dropable : MonoBehaviour
{
    public List<GameObject> DropableObject;
    private Attachable[] _attachables;
    private Random _random;
    private GameObject _current;

    private GameObject GetRandomObject()
    { 
        return DropableObject[_random.Next(0, DropableObject.Count-1)];
    }
    public void Start()
    {
        _random = new Random();
        _attachables = transform.GetComponentsInChildren<Attachable>();
        foreach (var attachable in _attachables)
        {
            attachable.AttachObject = GetRandomObject();
        }
    }

    public void Drop()
    {
        GameObject dropObject = Instantiate(_attachables[0].AttachObject);
        dropObject.transform.SetPositionAndRotation(_attachables[0].transform.position, new Quaternion());
        for (int i = 0; i < _attachables.Length - 1; ++i)
        {
            _attachables[i].AttachObject = _attachables[i + 1].AttachObject;
        }

        _attachables[^1].AttachObject = GetRandomObject();
    }
}
