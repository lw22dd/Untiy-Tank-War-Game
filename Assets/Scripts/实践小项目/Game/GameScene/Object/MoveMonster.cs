using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public Texture maxHPBK;
    public Texture curHPBK;
    
    public Rect maxHPBKRect;//最大血条的位置
    public Rect curHPBKRect;
    
    public float showTime = 0;
    
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

    private void OnGUI()
    {
        if (showTime > 0)
        { 
            showTime -= Time.deltaTime;
            //画图 画血条
            //将怪物位置世界坐标转化为屏幕坐标
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            //屏幕位置转化为GUI的坐标位置
            
            screenPos.y = Screen.height  - screenPos.y;
            //然后绘制
            maxHPBKRect.x = screenPos.x- 100;
            maxHPBKRect.y = screenPos.y - 50 ;
            maxHPBKRect.width = 200;
            maxHPBKRect.height = 30;
            GUI.DrawTexture(maxHPBKRect, maxHPBK);
        
            curHPBKRect.x = screenPos.x - 100;
            curHPBKRect.y = screenPos.y - 50 ;
            curHPBKRect.width = (float)hp / maxHp * 200f;//200f是血条的宽度，计算当前血量占比赋值宽度
            curHPBKRect.height = 30;
            GUI.DrawTexture(curHPBKRect, curHPBK);//在curHPBKRect这个区域绘制curHPBK
        }
        
    }
    public override void Wounded(TankBaseObj orther)
    {
        base.Wounded(orther);
        showTime = 3;//当受伤的时候，将血条显示3秒，配合OnGUI的条件判断实现
        
    }
}
