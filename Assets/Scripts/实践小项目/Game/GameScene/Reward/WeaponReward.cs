using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    //有多个用于随机的获取武器的预设体
    public GameObject[] weapon;
    public GameObject effectObj;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerObj>().ChangeWeapon(weapon[Random.Range(0, weapon.Length)]);
            GameObject effect = Instantiate(effectObj, transform.position, Quaternion.identity);
            AudioSource  audio = effect.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.MusicData.soundValue;
            audio.mute = !GameDataMgr.Instance.MusicData.isOpenSound;
            //获取到武器后销毁奖励对象
            Destroy(gameObject);
        }
    }
}
