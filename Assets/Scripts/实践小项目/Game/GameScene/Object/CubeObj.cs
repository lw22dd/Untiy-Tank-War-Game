using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObjects;
    public GameObject effectObj;//销毁特效
   private void OnTriggerEnter(Collider other)
   {
      // 打到自己的子弹同样销毁
      // 由于子弹对象打到Cube类型的对象会自己销毁，则设置当前绑定的对象为Cube就行
      
      // 设置一个随机奖励
      int random = UnityEngine.Random.Range(0, 100);
      if (random < 50)
      {
         random = UnityEngine.Random.Range(0, rewardObjects.Length);
         Instantiate(rewardObjects[random], this.transform.position, this.transform.rotation);
      }
      
      GameObject effect = Instantiate(effectObj, transform.position, Quaternion.identity);
      AudioSource  audio = effect.GetComponent<AudioSource>();
      audio.volume = GameDataMgr.Instance.MusicData.soundValue;
      audio.mute = !GameDataMgr.Instance.MusicData.isOpenSound;
      Destroy(gameObject);
   }
}
