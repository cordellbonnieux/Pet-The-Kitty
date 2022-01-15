using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public int zoomDistance = -15;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, 0, zoomDistance);
    }

    void LateUpdate() 
    {
        transform.position = player.transform.position + offset;
    }
}
