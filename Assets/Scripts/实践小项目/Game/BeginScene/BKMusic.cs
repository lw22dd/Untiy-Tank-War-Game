using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;
    
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //得到自己依附的游戏对象上挂载的音频源脚本
            audioSource = this.GetComponent<AudioSource>();
            //初始化背景音乐
            OpenOrCloseBKMusic(GameDataMgr.Instance.MusicData.isOpenBK);
            ChangeBkValue(GameDataMgr.Instance.MusicData.bkValue);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeBkValue(float value)
    {
        audioSource.volume = value;
    }

    public void OpenOrCloseBKMusic(bool isOpen)
    {
        audioSource.enabled = isOpen;
    }
}
