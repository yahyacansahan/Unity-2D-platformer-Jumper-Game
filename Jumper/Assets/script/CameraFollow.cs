using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerPos;

    void Update()
    {
        if (PlayerPos.position.y>transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, PlayerPos.position.y, transform.position.z);
        }
        
    }
}
