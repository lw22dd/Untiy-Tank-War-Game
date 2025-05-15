using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : BasePanel<SettingPanel>
{
    //声明蒙版内所有成员变量
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    
    public CustomGUIButton btnClose;
    void Start()
    {
        btnClose.clickEvent += () =>
        {
            HideMe();
            if(SceneManager.GetActiveScene().name == "BeginScene")
             BeginPanel.Instance.ShowMe();
        };
        // 其实核心就是改变MusicData中的值，然后通过PlayerPrefsDataMgr保存到本地
        togMusic.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseBK(value);

        togSound.changeValue += (value) => GameDataMgr.Instance.OpenOrCloseSound(value);
 
        sliderMusic.changeValue += (value) => GameDataMgr.Instance.ChangeBkValue(value);

        sliderSound.changeValue += (value) => GameDataMgr.Instance.ChangeSoundValue(value);

        HideMe();
    }

    public void UpdatePanelInfo()
    {
        MusicData MusicData = GameDataMgr.Instance.MusicData;    
        
        // 设置音效和背景音乐开关
        togMusic.isSel = MusicData.isOpenBK;
        togSound.isSel = MusicData.isOpenSound;
        sliderMusic.nowValue = MusicData.bkValue;
        sliderSound.nowValue = MusicData.soundValue;
    }
    public override void ShowMe()
    {
        base.ShowMe();
        //  每次显示Setting时更新面板信息
        UpdatePanelInfo();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
