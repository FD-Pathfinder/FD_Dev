using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FD_Interaction : MonoBehaviour, IcanInteracted
{
   
    public void YesInteracted()
    {
        Mano_InputManger.IAmTouching += IR_SetParent;
        Mano_InputManger.IAmRelease += IR_DeleteParent;
        Debug.Log("被碰到物体：交互啦");
    }
    public void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= IR_SetParent;
        Mano_InputManger.IAmRelease -= IR_DeleteParent;
        Debug.Log("配碰到物体：不交互啦");
    }

    GameObject WhoTouchMe;


    //把这个游戏对象的坐标松绑，松手
    private void IR_DeleteParent()
    {
        Debug.Log("收到了手势放开的广播事件");
        this.gameObject.transform.parent.SetParent(null);
    }

    //把这个游戏对象的坐标绑到另一个游戏对象身上（抓住）
    private void IR_SetParent()
    {
        Debug.Log("收到了手势抓住的广播事件");
        this.gameObject.transform.parent.SetParent(WhoTouchMe.transform);
    }

    //当有东西在摸这个游戏对象时，取它的引用
    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
}
