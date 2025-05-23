using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    //关联场景控件对象
    public CustomGUILabel score;
    public CustomGUILabel time;
    public CustomGUIButton btnQuit;
    public CustomGUIButton btnSetting;
    public CustomGUITexture Hp;
    public float hpMaxWidth;//最大血条宽度，需要在Unity绑定

    // 当前分数，由于界面上不需要更改，所以添加一个特性
    [HideInInspector]
    public int nowScore = 0;
    [HideInInspector]
    public float nowTime = 0;
    
    
    void Start()
    {
        // 监听键盘事件
        btnSetting.clickEvent += () => {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };
        btnQuit.clickEvent += () => {
            // 弹出一个确认框，返回主页面
            QuitPanel.Instance.ShowMe();
            // 暂停游戏
            Time.timeScale = 0;
        };
        UpdateScore(100);//初始化分数100
    }

    // Update is called once per frame
    void Update()
    {
        // 通过帧间隔时间累加时间，定60帧每秒
        nowTime  += Time.deltaTime;
        // 时间格式转换
        
        int tmptime = (int)nowTime;//向下取整
        time.content.text = (tmptime / 3600).ToString() + ":" + (tmptime % 3600 / 60).ToString() + ":" +
                (tmptime % 60).ToString();
        
    }
    // 更新分数
    public void UpdateScore(int score)
    {
        nowScore += score;
        this.score.content.text = nowScore.ToString();
    }
    // 逻辑是根据当前血量和最大血量计算百分比，再控制血量UI的宽度减少
    public void UpdateHp(int hp, int maxHp)
    {
        Hp.guiPos.width = hp / (float)maxHp * hpMaxWidth;
    }
}
