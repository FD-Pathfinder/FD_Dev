using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FD_Interaction : MonoBehaviour, IcanInteracted
{

    string DebugMessage = string.Empty;
    public virtual void YesInteracted()
    {
        //����һ�����󷽷�������Ҫ�ڼ̳��������ľ��彻������ȥʵ����
        //��������ҵ��ִ�������Ϸ�����ʱ�򱻵���
    }
    public virtual void NoInteracted()
    {
        //����һ�����󷽷�������Ҫ�ڼ̳��������ľ��彻������ȥʵ����
        //��������ҵ��ֲ��ٽӴ�����Ϸ�����ʱ�򱻵���
    }
    #region ��ȡ��������
    private GameObject WhoTouchMe;
    //���ж������������Ϸ����ʱ��ȡ��������
    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
    #endregion
}

