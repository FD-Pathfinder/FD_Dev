using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FD_Interaction : MonoBehaviour, IcanInteracted
{

    string DebugMessage = string.Empty;
    public void YesInteracted()
    {
        Mano_InputManger.IAmTouching += IR_SetParent; //�Ӵ����ᴥ��ʲô
        Mano_InputManger.IAmRelease += IR_DeleteParent; //�ɿ��ᴥ��ʲô
                                                        //������������б�����������
    }
    public void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= IR_SetParent;
        Mano_InputManger.IAmRelease -= IR_DeleteParent;
    }

    GameObject WhoTouchMe;

    public static event Action test;


    //�������Ϸ����������ɰ�����
    private void IR_DeleteParent()
    {

        this.gameObject.transform.SetParent(null);
    }

    //�������Ϸ������������һ����Ϸ�������ϣ�ץס��
    private void IR_SetParent()
    {

        this.gameObject.transform.SetParent(WhoTouchMe.transform);
    }

    //���ж������������Ϸ����ʱ��ȡ��������
    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
}

