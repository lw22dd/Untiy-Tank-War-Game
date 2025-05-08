using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotateSpeed = 5f;
    
    // Update is called once per frame
    void Update()
    {
      this.transform.Rotate(Vector3.up,rotateSpeed*Time.deltaTime);   
    }
}
