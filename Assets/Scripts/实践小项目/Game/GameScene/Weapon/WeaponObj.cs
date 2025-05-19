using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{
    public GameObject bullet;

    public Transform[] shootPos;
    public TankBaseObj owner;
    
    public void SetOwner(TankBaseObj tank)
    {
        owner = tank;
    }
    public void Fire()
    {
        // 根据炮管位置创建子弹
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //控制子弹行为
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetOwner(owner);//坦克通过武器发射子弹的时候，武器传owner参数给子弹
        }
    }
}
