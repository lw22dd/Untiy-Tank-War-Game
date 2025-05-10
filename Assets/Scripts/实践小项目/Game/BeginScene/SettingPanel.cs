using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            BeginPanel.Instance.ShowMe();
        };
        togMusic.changeValue += (value) =>
        {
        };
        togSound.changeValue += (value) =>
        {
        };
        sliderMusic.changeValue += (value) =>
        {

        };
        sliderSound.changeValue += (value) =>
        {

        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
