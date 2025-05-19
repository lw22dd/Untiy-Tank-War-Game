using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;
    public TankBaseObj  owner;
    public GameObject effectObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        
    }
    //和物体碰撞触发
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (effectObj)
            {
                GameObject effect = Instantiate(effectObj, transform.position, Quaternion.identity);
                //从特效上挂载的音频脚本修改音效的音量和开启状态，从DataMgr中获取
                AudioSource audioSource = effect.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.MusicData.soundValue; 
                audioSource.mute = !GameDataMgr.Instance.MusicData.isOpenSound;
            }
            //销毁子弹
            Destroy(this.gameObject);
            
        }
        
        
    }
    public void SetOwner(TankBaseObj tank)
    {
        owner = tank;
    }
}
