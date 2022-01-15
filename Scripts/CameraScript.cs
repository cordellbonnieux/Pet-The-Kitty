using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    public int rotateSpeed;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 3, -5);
        transform.position = player.transform.position + offset;  
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        transform.RotateAround(player.transform.position,Vector3.up, y * rotateSpeed);
        transform.RotateAround(player.transform.position,Vector3.right, x * rotateSpeed);
    }
}
