using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FD_Interaction : MonoBehaviour, IcanInteracted
{

    string DebugMessage = string.Empty;
    public void YesInteracted()
    {
        Mano_InputManger.IAmTouching += IR_SetParent; //接触到会触发什么
        Mano_InputManger.IAmRelease += IR_DeleteParent; //松开会触发什么
                                                        //在这个方法下列表触发各个方法
    }
    public void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= IR_SetParent;
        Mano_InputManger.IAmRelease -= IR_DeleteParent;
    }

    GameObject WhoTouchMe;

    public static event Action test;


    //把这个游戏对象的坐标松绑，松手
    private void IR_DeleteParent()
    {

        this.gameObject.transform.SetParent(null);
    }

    //把这个游戏对象的坐标绑到另一个游戏对象身上（抓住）
    private void IR_SetParent()
    {

        this.gameObject.transform.SetParent(WhoTouchMe.transform);
    }

    //当有东西在摸这个游戏对象时，取它的引用
    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
}

