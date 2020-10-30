using UnityEngine;

using UnityEngine.UI;
using System.Collections;

public class CharacterSelected : MonoBehaviour
{
    private GameObject selectedGO;
    public string selectedName = "";//选择器游戏物体名称
    private float hideTime=0;
    private float displayTime=3;
    //[Tooltip("选择器游戏物体名称")]
    private void start()
    {
        selectedGO = transform.Find(selectedName).gameObject;
    }
    
    public void SetSelectedActive(bool state)
    {
        selectedGO.SetActive(state);
        this.enabled = state;
        //等待3秒禁用物体
        if (state)
            hideTime = Time.time + displayTime;
    }



    private void Update()
    {
        if (hideTime <= Time.time)
        {
            SetSelectedActive(false);
        }
    }
    
}
