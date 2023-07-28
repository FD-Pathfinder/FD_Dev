
using UnityEngine;
//这个类负责根据菜单传来的按钮样式来生成按钮
public class IR_MenuButton : FD_Interaction,IcanInteracted
{
    #region 按钮样式
    private SpriteRenderer ButtonImage;

    private SpriteRenderer IconImage;

    #endregion

    #region 触发逻辑部分的参数
    private int ButtonID;

    public bool Ipress;

    private int insure;

    private IR_FloatingMenu MyDaddy_FloMenu;
    #endregion


    //调试：这里注意能否获得父对象
    private void Awake()
    {
        InitButton();
    }
    
    /// <summary>
    /// 在触碰的时候接收点击输入
    /// </summary>
    public override void YesInteracted()
    {
        Mano_InputManger.IAmTouching += InsureChange;
        Mano_InputManger.IAmTouching += ConfirmPress;
    }
    /// <summary>
    /// 在不再触碰的时候接受点击输入
    /// </summary>
    public override void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= InsureChange;
        Mano_InputManger.IAmTouching -= ConfirmPress;
        ResetInsure();
    }

    /// <summary>
    /// 只要手还留在按钮上，时刻检测是否完成了“按”的动作
    /// </summary>
    /// <param name="Cursor">玩家的光标</param>
    private void OnTriggerStay(Collider Cursor)
    {
        if (Ipress)
        {
            MyDaddy_FloMenu.DeteButtonPress();
        }
    }


    #region 一个按钮的公共方法，可以被外部调用
    /// <summary>
    /// 生成按钮，悬浮菜单组件会传入这些信息，以设置按钮的基本样式
    /// </summary>
    /// <param name="IconLook">按钮的LOGO</param>
    /// <param name="ButtonLook">按钮的背景板</param>
    /// <param name="Buttonid">按钮的ID</param>
    /// <param name="position">按钮的位置</param>
    public void SetUpButton(Sprite IconLook,Sprite ButtonLook,int Buttonid,Vector3 position)
    {
        IconImage.sprite = IconLook;
        ButtonImage.sprite = ButtonLook;
        ButtonID= Buttonid;
        this.gameObject.transform.localPosition= position;
    }
    
    /// <summary>
    /// 重置按钮保险，这意味着玩家又得重复操作
    /// </summary>
    public void ResetInsure()
    {
        insure = 0;
        this.gameObject.transform.GetChild(0).transform.localScale = Vector3.one * 0.5f;
    }

#endregion



    #region 按钮自己的交互逻辑
    /// <summary>
    /// 确认玩家点击按钮的次数是否大于等于2
    /// </summary>
    private void ConfirmPress()
    {
        if(insure>=2)
        {
            Ipress = true;
            MyDaddy_FloMenu.DeteButtonPress();
        }
    }
    
    /// <summary>
    /// 初始化按钮，找自己的组件
    /// </summary>
    private void InitButton()
    {
        //1找自己的拥有者
        //2找自己的精灵
        MyDaddy_FloMenu=this.transform.parent.gameObject.GetComponent<IR_FloatingMenu>();
        ButtonImage =this.gameObject.GetComponent<SpriteRenderer>();
        IconImage = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        
        //初始化图标样式
    }
    
    /// <summary>
    /// 更改保险值，同时稍微放大按钮的logo
    /// </summary>
    private void InsureChange() 
    {
        insure += 1;
        switch (insure)
        {
            case 0: this.gameObject.transform.GetChild(0).transform.localScale = Vector3.one * 0.5f; break;
            case 1: this.gameObject.transform.GetChild(0).transform.localScale = Vector3.one * 0.7f;break;
            default: break;
        }
    }
    #endregion


}
