using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    private Camera _mainCamera;
    private Dropable _dropable;
    public float MinX;
    public float MaxX;
    
    private void Start()
    {
        _mainCamera = Camera.main;
        _dropable = GetComponentInChildren<Dropable>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 position = transform.position;
            float x = _mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
            transform.SetPositionAndRotation(new Vector3(x > MaxX ? MaxX : x < MinX ? MinX : x, position.y, position.z), transform.rotation);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _dropable.Drop();
        }
    }
}
