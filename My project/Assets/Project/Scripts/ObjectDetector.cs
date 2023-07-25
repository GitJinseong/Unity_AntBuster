using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    public bool CheckForObject(Vector2 position)
    {
        Collider2D hitCollider = Physics2D.OverlapPoint(position);
        return hitCollider != null;
    }
}