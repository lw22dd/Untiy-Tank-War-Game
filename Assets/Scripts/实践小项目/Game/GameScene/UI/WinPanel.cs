using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : BasePanel<WinPanel>
{
    public CustomGUIInput input;
    public CustomGUIButton buttonSure;
    
    void Start()
    {
        buttonSure.clickEvent += () =>
        {
            if (input.content.text != "")
            {
                GameDataMgr.Instance.AddRankInfo(input.content.text,GamePanel.Instance.nowScore, GamePanel.Instance.nowTime);
                HideMe();
                SceneManager.LoadScene("BeginScene");
            }
        };
        HideMe();
    }
}
