using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    //首先声明公共的成员变量来关联各个控件
    public CustomGUIButton btnBegin;
    public CustomGUIButton btnSetting;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnRank;
    void Start()
    {
        //点击按钮打开对应面板
        btnBegin.clickEvent +=(() =>
        {
            //打开游戏场景
            SceneManager.LoadScene("GameScene");
        });
        btnSetting.clickEvent += (() =>
        {
            //打开设置面板
            //SettingPanel.Instance.ShowMe();
        });
        btnQuit.clickEvent += (() =>
        {
            //退出游戏
            Application.Quit();
        });
        btnRank.clickEvent += (() =>
        {
            //打开排行榜面板
            //RankPanel.Instance.ShowMe();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
