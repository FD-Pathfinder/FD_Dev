using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FD_Interaction : MonoBehaviour, IcanInteracted
{
   
    public void YesInteracted()
    {
        Mano_InputManger.IAmTouching += IR_SetParent;
        Mano_InputManger.IAmRelease += IR_DeleteParent;
        Debug.Log("���������壺������");
    }
    public void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= IR_SetParent;
        Mano_InputManger.IAmRelease -= IR_DeleteParent;
        Debug.Log("���������壺��������");
    }

    GameObject WhoTouchMe;


    //�������Ϸ����������ɰ�����
    private void IR_DeleteParent()
    {
        Debug.Log("�յ������Ʒſ��Ĺ㲥�¼�");
        this.gameObject.transform.parent.SetParent(null);
    }

    //�������Ϸ������������һ����Ϸ�������ϣ�ץס��
    private void IR_SetParent()
    {
        Debug.Log("�յ�������ץס�Ĺ㲥�¼�");
        this.gameObject.transform.parent.SetParent(WhoTouchMe.transform);
    }

    //���ж������������Ϸ����ʱ��ȡ��������
    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
}
