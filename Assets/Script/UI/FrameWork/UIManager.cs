using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;



namespace VR.UGUI.FrameWork
{
    /// <summary>
    /// 窗口基类 显示隐藏共有窗口
    /// </summary>
    public class UIManager : MonoSingleton<UIManager> 
   {
        private Dictionary<string, UIWindow> uiWindowDIC;

        public override void Init()
        {
            base.Init();
            uiWindowDIC = new Dictionary<string, UIWindow>();
            UIWindow[] uiWindowArr = FindObjectsOfType<UIWindow>();
            for (int i = 0; i < uiWindowArr.Length; i++)
            {
                uiWindowArr[i].SetVisible(false);
                AddWindow(uiWindowArr[i]);
            }
        }

        public void AddWindow(UIWindow window)
        {
            uiWindowDIC.Add(window.GetType().Name, window);

        }

        public T GetWindow<T>() where T : class
    {
        string key = typeof(T).Name;
        if (!uiWindowDIC.ContainsKey(key)) return null;
        return uiWindowDIC[key] as T;
    }

   }
}