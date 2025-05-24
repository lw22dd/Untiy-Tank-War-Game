using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostPanel : BasePanel<LostPanel>
{
    public CustomGUIButton btnBack;
    public CustomGUIButton btnGoOn;

    void Start()
    {
        btnBack.clickEvent += () =>
        {
            SceneManager.LoadScene("BeginScene");
            HideMe();
        };
        btnGoOn.clickEvent += () =>
        {
            SceneManager.LoadScene("GameScene");
            HideMe();

        };
        HideMe();

    }
}
