using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform  targetPalyer;

    public Vector3 pos;
    public float H = 10f;//通过外部设定摄像机的高度
    // Start is called before the first frame update
    void LateUpdate()
    {
        if(!targetPalyer) return;
        pos.x  = targetPalyer.position.x;
        pos.z  = targetPalyer.position.z;
        pos.y  =  H;
        transform.position = pos;
    }
}
