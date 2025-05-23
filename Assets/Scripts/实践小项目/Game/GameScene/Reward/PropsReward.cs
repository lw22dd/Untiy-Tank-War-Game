using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropsType
{
    // 奖励属性的类型
    HP,
    ATK,
    DEF,
    MaxHP
}
public class PropsReward : MonoBehaviour
{
    public PropsType propsType = PropsType.ATK;

    public int changeValue = 5;//可以动态配置奖励值
    public GameObject effect;//奖励特效
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //  获取玩家对象
            PlayerObj player = other.GetComponent<PlayerObj>();

            // 根据绑定的属性类型，对玩家进行奖励，
            switch (propsType)
            {
                case PropsType.HP:
                    player.hp += changeValue;
                    if (player.hp > player.maxHp)
                    {
                        player.hp = player.maxHp;// 如果奖励值大于最大值，则设置为最大值
                    }
                    GamePanel.Instance.UpdateHp(player.hp, player.maxHp);//通过面板更新Hp
                    break;
                case PropsType.ATK:
                    player.atk += changeValue;
                    break;
                case PropsType.DEF:
                    player.def += changeValue;
                    break;
                case PropsType.MaxHP:
                    player.maxHp += changeValue;
                    GamePanel.Instance.UpdateHp(player.hp, player.maxHp);
                    break;
            }
            GameObject effectObj = Instantiate(effect, transform.position, Quaternion.identity);
            AudioSource  audio = effectObj.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.MusicData.soundValue;
            audio.mute = !GameDataMgr.Instance.MusicData.isOpenSound;        
        
            Destroy(gameObject);
        }
        
    }
}
