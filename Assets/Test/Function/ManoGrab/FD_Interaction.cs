using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FD_Interaction : MonoBehaviour, IcanInteracted
{

    string DebugMessage = string.Empty;
    public virtual void YesInteracted()
    {
        //这是一个抽象方法，你需要在继承自这个类的具体交互功能去实现它
        //它会在玩家的手触碰到游戏对象的时候被调用
    }
    public virtual void NoInteracted()
    {
        //这是一个抽象方法，你需要在继承自这个类的具体交互功能去实现它
        //它会在玩家的手不再接触到游戏对象的时候被调用
    }
    #region 获取触碰引用
    private GameObject WhoTouchMe;
    //当有东西在摸这个游戏对象时，取它的引用
    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
    #endregion
}

