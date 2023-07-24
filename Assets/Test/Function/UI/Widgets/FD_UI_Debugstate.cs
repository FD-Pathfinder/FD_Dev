using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    

    //��ӦUI��debugdate�ϵ�3��message�����ã���������UI��Ϣ
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
        #region ������Ϣ
        ShowText("��ǰ����" + ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous.ToString(), Line1);
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
