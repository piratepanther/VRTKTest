using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using Common;


namespace VR.UGUI.FrameWork { 
public class UIWindow : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private VRTK.VRTK_UICanvas uiCanvas;
    private Dictionary<string, UIEventListener> uiEventDIC;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        uiCanvas = GetComponent<VRTK.VRTK_UICanvas>();
        uiEventDIC=new Dictionary<string, UIEventListener>();
    }

    public void SetVisible(bool state, float delay = 0)
    {
        StartCoroutine(SetVisibleDelay(state, delay));

    }

    private IEnumerator SetVisibleDelay(bool state, float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasGroup.alpha = state ? 1 : 0;
        uiCanvas.enabled = state;
    }

    public UIEventListener GetUIEventListener(string name)
    {
        if (!uiEventDIC.ContainsKey(name))
        {
            Transform tf = transform.FindChildByName(name);
            UIEventListener uiEvent = UIEventListener.GetListener(tf);
            uiEventDIC.Add(name,uiEvent);
        }
        return uiEventDIC[name];
    }


}
}