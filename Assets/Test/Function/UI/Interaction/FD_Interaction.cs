
using UnityEngine;


public class FD_Interaction : MonoBehaviour, IcanInteracted
{
    private void Awake()
    {
        MyUIManager=GameObject.FindWithTag("FD_UI").GetComponent<FD_UI>();
        this.enabled = false;
    }
    #region ������������
    [HideInInspector]
    public FD_UI MyUIManager;

    #endregion

    #region �鷽�����������Ӵ�ʽ������ͬ��������̬��
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

    #endregion

    #region ��ȡ��������
    [HideInInspector]
    public GameObject WhoTouchMe;
    //���ж������������Ϸ����ʱ��ȡ��������


    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
    #endregion
}

