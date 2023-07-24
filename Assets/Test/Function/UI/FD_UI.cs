using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface UpdateUI 
{
    public void UpdateMe();
}


public class FD_UI : MonoBehaviour
{

    // todo
    //各种ui组件会被作为子级连接到这个组件，每个组件启用与否都被一个布尔值控制
    //提供一个接口用于更新UI信息，每个与UI相关的脚本都需要提供更新自身UI信息的实现
    //提供初始化显示控件的方法

    public static event Action UIupadteing;

    [SerializeField]
    //目前UI控件只有调试这一个
    private FD_UI_Debugstate Debugstate;

    // 更新信息
    void Update()
    {
        Debugstate.UpdateMe();
    }
    /// <summary>
    /// 初始化UI界面上的小控件，获得他们的索引
    /// </summary>
    private void InitWidget(GameObject widget) 
    {
    
    }
}
