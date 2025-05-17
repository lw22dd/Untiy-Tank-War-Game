using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //1.ws键 控制前景
        
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * (Time.deltaTime * moveSpeed)));
        
        //2.ad键 控制旋转
        transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * (Time.deltaTime * roundSpeed)));
        //3.鼠标左右移动控制炮台旋转
        tankHead.transform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * (Time.deltaTime * headRoundSpeed)));
        //4.开火
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        throw new System.NotImplementedException();
    }
}