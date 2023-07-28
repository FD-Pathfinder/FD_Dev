using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// ����UI�Ļ������ܣ�UI�ؼ���Ҫ��������ӿڣ�UI�������Updateͬ��������������UI����ʾ��Ϣ
/// </summary>

public interface UpdateUI 
{
    public void UpdateMe();
}


public class FD_UI : MonoBehaviour
{
    #region ���UI����Ľ���
    // todo
    //����ui����ᱻ��Ϊ�Ӽ����ӵ���������ÿ�����������񶼱�һ������ֵ����
    //�ṩһ���ӿ����ڸ���UI��Ϣ��ÿ����UI��صĽű�����Ҫ�ṩ��������UI��Ϣ��ʵ��
    //�ṩ��ʼ����ʾ�ؼ��ķ���
    #endregion

    #region ��inspector�Ϲҵ����
    [Header("��UI�����߹���ĵ�UI�������")]
    [SerializeField]
    //ĿǰUI�ؼ�ֻ�е�����һ��
    private FD_UI_Debugstate UiDebugState;
    //���ɲ˵��Ĺ���
    [SerializeField]
    private IR_FloatingMenu UiMyFloatMenu;
    #endregion
   
    #region  ���������˵����ܵ��õ��Ĳ���

    [Header("�����˵�")]
    [SerializeField]
    private FloatMenuBunker[] FloatMenuList;

    #endregion
    
    #region �����˵������ɺ�ʵ��
    /// <summary>
    /// ����˵�����Ϣ������λ������һ�������˵�
    /// </summary>
    /// <param name="TypeWantToBuild">��Ҫ���������˵�����Ϣ</param>
    /// <param name="MyPosition">�����˵���λ��</param>
    public void ShowFloatMenu(FloatMenuType TypeWantToBuild,Vector3 MyPosition)
    {
        //���б����Ӧ�������˵����ݣ�������һ�������˵�����������ƶ���Ŀ��λ��
        UiMyFloatMenu.gameObject.SetActive(true);
        UiMyFloatMenu.SetupMenu(FinDByMenuType(FloatMenuList,TypeWantToBuild));
        UiMyFloatMenu.gameObject.transform.position= MyPosition;
    }

    public void HideFloatMenu()
    {
        //���б����Ӧ�������˵����ݣ�������һ�������˵�
        UiMyFloatMenu.DestoryFloatMenu();
        UiMyFloatMenu.gameObject.SetActive(false);
    }

    #endregion

    void Update()
    {
        UiDebugState.UpdateMe();
    }

    private void Start()
    {
        ShowFloatMenu(FloatMenuType.FloatMenu_Creeper, Vector3.zero);
    }

    #region �ͼ�����
    private FloatMenuBunker FinDByMenuType(FloatMenuBunker[] YouWantCheck,FloatMenuType type)
    {
        for (int i = 0; i < YouWantCheck.Length; i++)
        {
            if (YouWantCheck[i].MenuType == type)
            {
                return YouWantCheck[i];
            }
        }
        return YouWantCheck[0];
    }
    #endregion

}
