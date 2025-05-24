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
    public RankList RankData;
    
    private GameDataMgr()
    {
        // 游戏启动的时候先初始化游戏数据
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
        // 初始化排行榜
        RankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "rank") as RankList;
            
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
    public void OpenOrCloseBK(bool isOpen)
    {
        MusicData.isOpenBK = isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
        BKMusic.Instance.OpenOrCloseBKMusic(isOpen);
    }
    public void ChangeBkValue(float value)
    {
        MusicData.bkValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
        BKMusic.Instance.ChangeBkValue(value);
    }
    public void ChangeSoundValue(float value)
    {
        MusicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(MusicData, "music");
    }
    // 排行榜中添加数据
    public void AddRankInfo(string playerName,int score,float time)
    {
        RankInfo rankInfo = new RankInfo(playerName,score,time);
        RankData.rankList.Add(rankInfo);
        // 每次加入List之后要按时间重新排序
        RankData.rankList.Sort((x,y)=>y.time.CompareTo(x.time));
        // 因为只存10条，我们从后往前移除数据
        while (RankData.rankList.Count > 10)
        {
            RankData.rankList.RemoveAt(RankData.rankList.Count - 1);
        }
        PlayerPrefsDataMgr.Instance.SaveData(RankData, "rank");
    }
}
