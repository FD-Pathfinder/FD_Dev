using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;


public class FD_UI_Debugstate : MonoBehaviour,UpdateUI
{
    //���ui��صĿؼ��������ֻ��ϵ���ʱ�ռ���Ϣ����ʾ��صĹ���
    //TODO
    //��ʾ�������
    //��ʾ��ͼ����
    //��ʾ������

    #region ��������
    //����������
    [Tooltip("������-����ϵͳ")]
    [SerializeField]
    private Mano_InputManger dete_InputSystem;
    [Tooltip("������-��ҹ��")]
    private PlayerCusor dete_playercursor;


    //��ӦUI��debugdate�ϵ�3��message�����ã���������UI��Ϣ
    Text Line1;
    Text Line2;
    Text Line3;

    #endregion
    private void Awake()
    {
        InitText();
    }
    private void Start()
    {
        dete_playercursor = dete_InputSystem.PlayerCursor.GetComponent<PlayerCusor>();

    }
    public void UpdateMe()
    {
        #region ������Ϣ
        ShowText(dete_InputSystem.debugmessage, Line1);
        ShowText(dete_playercursor.debugmessage, Line2);
        #endregion
        #region ����debug�ַ�����ϢΪ��
        dete_playercursor.debugmessage=string.Empty;
        dete_InputSystem.debugmessage = string.Empty;
        #endregion
    }

    /// <summary>
    /// ��ʼ���ı���ʾ
    /// </summary>
    private void InitText()
    {
        Line1 = this.transform.Find("Line1").gameObject.GetComponent<Text>();
        Line2 = this.transform.Find("Line2").gameObject.GetComponent<Text>();
        Line3 = this.transform.Find("Line3").gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// ���ı���ֵ����ʾ
    /// </summary>
    /// <param name="message">����Ҫ��ʾ������</param>
    /// <param name="Line">�ڵڼ�����ʵ</param>
    private void ShowText(string message,Text Line)
    {
        Line.text = message;
    }

}
