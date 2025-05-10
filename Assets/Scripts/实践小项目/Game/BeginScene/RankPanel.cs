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
            labelRank.Add(this.transform.Find("LabelRank/LabelRank" + " ("+i+")").GetComponent<CustomGUILabel>());
            labelPlayer.Add(this.transform.Find("LabelPlayer/LabelPlayer" + " ("+i+")").GetComponent<CustomGUILabel>());
            labelScore.Add(this.transform.Find("LabelScore/LabelScore" + " ("+i+")").GetComponent<CustomGUILabel>());
            labelTime.Add(this.transform.Find("LabelTime/LabelTime" + " ("+i+")").GetComponent<CustomGUILabel>());
        }
        btnClose.clickEvent += () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };
        HideMe();
        
    }

    
    public void UpdatePanelInfo()
    {
        for (int i = 0; i < 10; i++)
        {
            labelRank[i].content.text = (i+1).ToString();
            labelPlayer[i].content.text = "玩家" + (i+1).ToString();
            labelScore[i].content.text = "分数" + (i+1).ToString();
            labelTime[i].content.text = "时间" + (i+1).ToString();
        }
    }
    public override void ShowMe()
    { 
        base.ShowMe();
        UpdatePanelInfo();
    }
}
