using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{
    public CustomGUIButton btnQuit;

    public CustomGUIButton btnCancel;
    public CustomGUIButton btnClose;
    // Start is called before the first frame update
    void Start()
    {
        btnClose.clickEvent  += () =>
        {
            HideMe();
        };
        btnQuit.clickEvent += () =>
        {
            // 回到主界面
            SceneManager.LoadScene("BeginScene");
        };
        btnCancel.clickEvent += () =>
        {
            HideMe();
        };
        HideMe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;

    }
    
}
