using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankInfo 
{
    public string playerName;
    public int score;
    public int time;
    public RankInfo(string playerName,int score,int time)
    {
        this.playerName = playerName;
        this.score = score;
        this.time = time;
    }
    // 默认构造函数
    public RankInfo()
    {
        
    }
    
    
}

public class RankList
{
    // RankList由多条 RankInfo 组成
    public List<RankInfo> rankList = new List<RankInfo>();
    
}
