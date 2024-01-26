using System;
using System.Linq;
using UnityEngine;

public class Mergeable : MonoBehaviour
{
    public GameObject ProgressObject;
    private CatchCollision[] _catchCollisions;
    private bool _isMerged;
    
    private void Start()
    {
        _isMerged = false;
        _catchCollisions = GetComponentsInChildren<CatchCollision>();
        foreach (var catchCollision in _catchCollisions)
        {
            catchCollision.OnCollisionEnter += (sender, otherCatchCollision) =>
            {
                if (_catchCollisions.Contains(otherCatchCollision)) return;
                Mergeable otherMergeable = otherCatchCollision.GetComponentInParent<Mergeable>();
                if (gameObject.name != otherMergeable.name) return;
                Vector3 collidePosition = (((Component)sender).transform.position + otherCatchCollision.transform.position) / 2;
                Destroy(gameObject);
                if (_isMerged) return;
                _isMerged = true;
                Progressable.instance.Progress(gameObject.name, ProgressObject, collidePosition);
            };
        }
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     Debug.Log("HI");
    //     if (gameObject.name == other.gameObject.name)
    //     {
    //         Vector3 collidePosition = (transform.position + other.gameObject.transform.position) / 2;
    //         Progressable.instance.Progress(gameObject.name, ProgressObject, collidePosition);
    //         Destroy(gameObject);
    //     }
    // }
}
