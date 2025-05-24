using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : TankBaseObj
{
    // 要让tank在多个点之间来回移动，tank要一直盯着玩家，当玩家到达一定距离的时候开火
    public Transform targetPos;
    public Transform[] randomPos;
    public Transform playerPos;
    public float fireOffSetTime = 1;
    public float fireDis = 10;
    public float nowTime;
    //开火
    public Transform[] shootPos;
    public GameObject bullet;
    
    void Start()
    {
        RandomPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        #region 多个点之间的随机移动逻辑

        this.transform.LookAt(targetPos);
        this.transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        
        if (Vector3.Distance(this.transform.position, targetPos.position) < 0.05f)
        {
            RandomPos();
        }

        #endregion

        #region 看向自己的目标
        if  (playerPos)
        {
            tankHead.LookAt(playerPos);
            if (Vector3.Distance(this.transform.position, playerPos.position) <= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime > fireOffSetTime)
                {
                    nowTime = 0;
                    Fire();
                }
            }
        }

        #endregion
        
    }

    private void RandomPos()
    {
        if (randomPos.Length == 0)
        {
            return;
        }
        // 使用外部绑定的randomPos来确定目标点
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
        
    }
    
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject bulletObj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            //  设置子弹的归属，方便进行属性计算
            bulletObj.GetComponent<BulletObj>().SetOwner(this);
        }
        
    }

    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.UpdateScore(10);
        GameObject  deadEffect = Instantiate(this.deadEffect, this.transform.position, this.transform.rotation);
        AudioSource  audio = deadEffect.GetComponent<AudioSource>();
        audio.volume = GameDataMgr.Instance.MusicData.soundValue;
        audio.mute = !GameDataMgr.Instance.MusicData.isOpenSound;
        audio.Play();
    }
}
