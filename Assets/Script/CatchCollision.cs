using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCollision : MonoBehaviour
{
    public event EventHandler<CatchCollision> OnCollisionEnter;
    private void OnCollisionEnter2D(Collision2D other)
    {
        CatchCollision otherCatchCollision = other.gameObject.GetComponent<CatchCollision>();
        if (otherCatchCollision) {
            OnCollisionEnter?.Invoke(this, otherCatchCollision);
        }
    }
}
