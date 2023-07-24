using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FD_UI_Debugstate : MonoBehaviour,UpdateUI
{
    //这个ui相关的控件处理在手机上调试时收集信息和显示相关的功能
    //TODO
    //显示光标坐标
    //显示地图坐标
    //显示调试项

    #region 变量声明
    //声明检测对象
    [Tooltip("检测对象-输入系统")]
    [SerializeField]
    private Mano_InputManger dete_InputSystem;
    

    //对应UI的debugdate上的3个message的引用，用来更新UI信息
    Text Line1;
    Text Line2;
    Text Line3;
    #endregion
    public static event Action FD_Debugging;
    private void Awake()
    {
        InitText();
    }
    public void UpdateMe()
    {
        #region 更新信息
        ShowText("当前手势" + ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous.ToString(), Line1);
        #endregion
    }



    /// <summary>
    /// 初始化文本显示
    /// </summary>
    private void InitText()
    {
        Line1 = this.transform.Find("Line1").gameObject.GetComponent<Text>();
        Line2 = this.transform.Find("Line2").gameObject.GetComponent<Text>();
        Line3 = this.transform.Find("Line3").gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// 给文本赋值并显示
    /// </summary>
    /// <param name="message">你想要显示的内容</param>
    /// <param name="Line">在第几行现实</param>
    private void ShowText(string message,Text Line)
    {
        Line.text = message;
    }

}
