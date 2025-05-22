using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : TankBaseObj
{
    public WeaponObj nowWeapon;
    public Transform weaponPos;//武器位置

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
        if (nowWeapon)
        {
            nowWeapon.Fire();
        }
    }
    /// <summary>
    /// 切换武器
    /// </summary>
    /// <param name="weapon"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        //如果有当前武器则先销毁
        if (nowWeapon)
        {
            Destroy(nowWeapon.gameObject);
            nowWeapon = null;
        }
        //创建出武器设置它的父对象并且保证缩放没什么问题
        GameObject weaponObj = Instantiate(weapon, weaponPos,false);
        nowWeapon = weaponObj.GetComponent<WeaponObj>();
        //设置武器的拥有者，为了使得子弹携带Tank的攻击力数值
        nowWeapon.SetOwner(this);
        
    }
}