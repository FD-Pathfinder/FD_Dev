using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//这个类负责根据菜单传来的按钮样式来生成按钮
public class IR_MenuButton : FD_Interaction, IcanInteracted
{
    /// <summary>
    /// 这用来规定每个按钮的样式，每个按钮由一个图案和一个背景板组成
    /// </summary>
    /// <param name="Buttonimage">背景板</param>
    /// <param name="Iconimage">Logo</param>
    /// <param name="buttonid">这个按钮的ID，用来区分玩家选了哪个按钮</param>

    private Sprite ButtonImage;

    private Sprite IconImage;

    private IR_FloatingMenu MyDaddy_FloMenu;

   
    #region 触发逻辑部分
    private int ButtonID;

    private bool Ipress;

    private int insure;
    #endregion
    //调试：这里注意能否获得父对象
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
        //1找自己的拥有者
        //2找自己的精灵
        MyDaddy_FloMenu=this.transform.parent.gameObject.GetComponent<IR_FloatingMenu>();
        ButtonImage =this.gameObject.GetComponent<Sprite>();
        IconImage = this.gameObject.GetComponentInChildren<Sprite>();
        //初始化图标样式
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
