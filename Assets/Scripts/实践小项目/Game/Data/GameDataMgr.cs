using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏数据管理器, 单例
/// </summary>
public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();
    
    public static GameDataMgr Instance => instance;

    public MusicData MusicData;
    
    private GameDataMgr()
    {
        //可以去初始化游戏数据
        MusicData = PlayerPrefsDataMgr.Instance.LoadData( typeof(MusicData), "music") as MusicData;
        //因为首次进入游戏不会有音乐数据，而默认数据是false和0，因此设置默认开启
        if (!MusicData.notFirst)
        {
            MusicData.notFirst = true;
            MusicData.isOpenBK = true;
            MusicData.isOpenSound = true;
            MusicData.bkValue = 1f;
            MusicData.soundValue = 1f;
            PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
            
        }
            
    }
    // 我们需要提供一些API方法，来获取和设置数据
    public void SetMusicData(MusicData MusicData)
    {
        this.MusicData = MusicData;
        PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
    }
    public MusicData GetMusicData()
    {
        return MusicData;
    }

    public void OpenOrCloseSound(bool isOpen)
    {
        MusicData.isOpenSound = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
    }
    public void ChangeBkValue(float value)
    {
        MusicData.bkValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
    }
    public void ChangeSoundValue(float value)
    {
        MusicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
    }
}
