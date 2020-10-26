using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VR.UGUI.FrameWork;
using UnityEngine.EventSystems;
using Common;

namespace VR.UGUI{
public class UIMainWindow :UIWindow
    {
    private void Start()
    {
        //TransformHelper.FindChildByName(transform, "Button").GetComponent<Button>().onClick.AddListener(OnGameStartButtonClick);
        //transform.Find("Button").GetComponent<Button>().onClick.AddListener(OnGameStartButtonClick);
        //transform.FindChildByName("Button").GetComponent<UIEventListener>().PointerClick+= OnPointerClick;
        GetUIEventListener("Button").PointerClick += OnPointerClick;
        //transform.FindChildByName("Button").GetComponent<Button>().onClick.AddListener(OnGameStartButtonClick);
    }

    private void OnPointerClick(PointerEventData eventData)
    {
        print(eventData.pointerPress+"-----"+eventData.clickCount);
        GameController.instance.GameStart();
    }

    private void OnGameStartButtonClick()
    {
        GameController.instance.GameStart();
    }
    }
}
