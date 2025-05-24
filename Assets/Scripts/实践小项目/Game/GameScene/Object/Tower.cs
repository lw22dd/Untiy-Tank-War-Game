using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : TankBaseObj
{
    public float fireOffSetTime = 1;
    private float fireOffSetTimeCount = 0;

    public GameObject bullet;
    public Transform[] firePoint;


    void Update()
    {
        // 通过帧间隔时间累加时间
        fireOffSetTimeCount += Time.deltaTime;
        // 当时间超过间隔时间时就开火
        if (fireOffSetTimeCount > fireOffSetTime)
        {
            Fire();
            fireOffSetTimeCount = 0;
        }
        
    }

    public override void Fire()
    {
        for (int i = 0; i < firePoint.Length; i++)
        { 
            GameObject bulletObj = Instantiate(bullet, firePoint[i].position, firePoint[i].rotation);
            //  设置子弹的归属，方便进行属性计算
            bulletObj.GetComponent<BulletObj>().SetOwner(this);
            
        }
    }
    public override void Wounded(TankBaseObj orther)
    {
        // 固定不动的塔不受到伤害
    }
}
