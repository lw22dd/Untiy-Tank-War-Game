using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBaseObj : MonoBehaviour
{
    //攻击力防御力最大当前血量相关
    public int atk;
    public int def;
    public int maxHp;
    public int hp;
    // 所有坦克都有炮台
    public Transform tankHead;
    
    public float moveSpeed = 10;
    public float roundSpeed = 100; //旋转速度
    public float headRoundSpeed = 100;//炮头旋转速度

    public GameObject deadEffect;
    /// <summary>
    /// 开火抽象方法子类重写开火行为即可，因为每中子类都有自己的开火逻辑，
    /// 所以需要 abstract强制提供统一的接口。确保所有子类都有重写该方法
    /// </summary>
    public abstract void Fire();

    public virtual void Wounded(TankBaseObj orther)
    {
        int hurt = orther.atk - def;
        if (hurt <0)
        {
            return;
        }
        this.hp -= hurt;
        if (this.hp <= 0)// 死亡
        {
            this.hp = 0;//  防止hp小于0导致UI异常
            this.Dead();
        }
    }

    /// <summary>
    /// 死亡行为，在场景上移除该对象
    /// </summary>
    public virtual void Dead()
    {
        Destroy(gameObject);
        if (this.deadEffect != null)
        {   //Quaternion.identity 是指创建一个无旋转的rotation
            GameObject effect  = Instantiate(this.deadEffect, transform.position, this.transform.rotation);
            // 由于该特效直接关联了音效，在此处也可以同时控制音效大小
            AudioSource audioSource = effect.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.volume = GameDataMgr.Instance.MusicData.soundValue;
                // mute  是否静音
                audioSource.mute  = !GameDataMgr.Instance.MusicData.isOpenSound;
                // 由于音效勾选了PlayOnAwake，这里随意可以手动播放
                audioSource.Play();
            }
            
        }
    }
    
}
