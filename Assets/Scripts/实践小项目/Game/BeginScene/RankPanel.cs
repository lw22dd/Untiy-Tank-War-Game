using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;
    public List<CustomGUILabel> labelRank;
    public List<CustomGUILabel> labelPlayer;
    public List<CustomGUILabel> labelScore;
    public List<CustomGUILabel> labelTime;

    void Start()
    {
        //通过序列化的命名和遍历来获取控件
        for (int i = 1; i <= 10; i++)
        {
            labelRank.Add(this.transform.Find("LabelRank/LabelRank" + " (" + i + ")").GetComponent<CustomGUILabel>());
            labelPlayer.Add(this.transform.Find("LabelPlayer/LabelPlayer" + " (" + i + ")")
                .GetComponent<CustomGUILabel>());
            labelScore.Add(this.transform.Find("LabelScore/LabelScore" + " (" + i + ")")
                .GetComponent<CustomGUILabel>());
            labelTime.Add(this.transform.Find("LabelTime/LabelTime" + " (" + i + ")").GetComponent<CustomGUILabel>());
        }

        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        // 测试数据
        //GameDataMgr.Instance.AddRankInfo("小明", 100, 100);
        HideMe();
    }


    public override void ShowMe()
    {
        base.ShowMe();
        UpdateRankInfo();
    }

    public void UpdateRankInfo()
    {
        // 先得到原有的数据
        List<RankInfo> rankList = GameDataMgr.Instance.RankData.rankList;

        for (int i = 1; i <= rankList.Count; i++)
        {
            labelPlayer[i - 1].content.text = rankList[i - 1].playerName;
            labelScore[i - 1].content.text = rankList[i - 1].score.ToString();
            // 我们使用秒来记录单位时间，但是显示成string要转换成时分秒
            int time = rankList[i - 1].time;
            labelTime[i - 1].content.text = (time / 3600).ToString() + ":" + (time % 3600 / 60).ToString() + ":" +
                                            (time % 60).ToString();
        }
    }
}