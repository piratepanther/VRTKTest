using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR.UGUI.FrameWork;
using VR.UGUI;

public class GameController : MonoSingleton<GameController>
{
    //游戏开始前
    private void Start()
    {
        UIManager.instance.GetWindow<UIMainWindow>().SetVisible(true);
    }

    //游戏开始
    public void GameStart()
    {
        UIManager.instance.GetWindow<UIMainWindow>().SetVisible(false);
    }

    //游戏结束

    //游戏暂停

}
    