using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//����ฺ����ݲ˵������İ�ť��ʽ�����ɰ�ť
public class IR_MenuButton : FD_Interaction, IcanInteracted
{
    /// <summary>
    /// �������涨ÿ����ť����ʽ��ÿ����ť��һ��ͼ����һ�����������
    /// </summary>
    /// <param name="Buttonimage">������</param>
    /// <param name="Iconimage">Logo</param>
    /// <param name="buttonid">�����ť��ID�������������ѡ���ĸ���ť</param>

    private Sprite ButtonImage;

    private Sprite IconImage;

    private IR_FloatingMenu MyDaddy_FloMenu;

   
    #region �����߼�����
    private int ButtonID;

    private bool Ipress;

    private int insure;
    #endregion
    //���ԣ�����ע���ܷ��ø�����
    private void Awake()
    {
        InitButton();
    }

    public override void YesInteracted()
    {
        Mano_InputManger.IAmTouching += InsureChange;
        Mano_InputManger.IAmTouching += ConfirmPress;
    }


    public override void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= InsureChange;
        Mano_InputManger.IAmTouching -= ConfirmPress;
    }
    private void InsureChange() 
    {
        insure += 1;
        switch (insure)
        {
            case 0: this.gameObject.transform.GetChild(0).transform.localScale = Vector3.one * 1f; break;
            case 1: this.gameObject.transform.GetChild(0).transform.localScale = Vector3.one * 1.5f;break;
            default: break;
        }
    }
    private void InitButton()
    {
        //1���Լ���ӵ����
        //2���Լ��ľ���
        MyDaddy_FloMenu=this.transform.parent.gameObject.GetComponent<IR_FloatingMenu>();
        ButtonImage =this.gameObject.GetComponent<Sprite>();
        IconImage = this.gameObject.GetComponentInChildren<Sprite>();
        //��ʼ��ͼ����ʽ
    }
    private void ConfirmPress()
    {
        if(insure>=2)
        {
            Ipress = true;
        }
    }
    public void SetUpButton(Sprite IconLook,Sprite ButtonLook,int Buttonid)
    {
        IconImage = IconLook;
        ButtonImage = ButtonLook;
        ButtonID= Buttonid;
    }
    public void ResetInsure()
    {
        insure = 0;
    }



}
