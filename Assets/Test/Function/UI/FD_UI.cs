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
    //����ui����ᱻ��Ϊ�Ӽ����ӵ���������ÿ�����������񶼱�һ������ֵ����
    //�ṩһ���ӿ����ڸ���UI��Ϣ��ÿ����UI��صĽű�����Ҫ�ṩ��������UI��Ϣ��ʵ��
    //�ṩ��ʼ����ʾ�ؼ��ķ���

    public static event Action UIupadteing;

    [SerializeField]
    //ĿǰUI�ؼ�ֻ�е�����һ��
    private FD_UI_Debugstate Debugstate;

    // ������Ϣ
    void Update()
    {
        Debugstate.UpdateMe();
    }
    /// <summary>
    /// ��ʼ��UI�����ϵ�С�ؼ���������ǵ�����
    /// </summary>
    private void InitWidget(GameObject widget) 
    {
    
    }
}
