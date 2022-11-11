using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject leftShoe, rightShoe;

    public Vector3 cameraAim;
    // Update is called once per frame
    void Update()
    {
        float lx = leftShoe.transform.position.x;
        float lz = leftShoe.transform.position.z;
        float rx = rightShoe.transform.position.x;
        float rz = rightShoe.transform.position.z;

        cameraAim = new Vector3(((lx + rx) /2),0, ((lz + rz) / 2));

        this.transform.position = Vector3.Lerp(this.transform.position, cameraAim + new Vector3(0,4,-5), Time.deltaTime);
    }
}
