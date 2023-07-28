
using UnityEngine;
//����ฺ����ݲ˵������İ�ť��ʽ�����ɰ�ť
public class IR_MenuButton : FD_Interaction,IcanInteracted
{
    #region ��ť��ʽ
    private SpriteRenderer ButtonImage;

    private SpriteRenderer IconImage;

    #endregion

    #region �����߼����ֵĲ���
    private int ButtonID;

    public bool Ipress;

    private int insure;

    private IR_FloatingMenu MyDaddy_FloMenu;
    #endregion


    //���ԣ�����ע���ܷ��ø�����
    private void Awake()
    {
        InitButton();
    }
    
    /// <summary>
    /// �ڴ�����ʱ����յ������
    /// </summary>
    public override void YesInteracted()
    {
        Mano_InputManger.IAmTouching += InsureChange;
        Mano_InputManger.IAmTouching += ConfirmPress;
    }
    /// <summary>
    /// �ڲ��ٴ�����ʱ����ܵ������
    /// </summary>
    public override void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= InsureChange;
        Mano_InputManger.IAmTouching -= ConfirmPress;
        ResetInsure();
    }

    /// <summary>
    /// ֻҪ�ֻ����ڰ�ť�ϣ�ʱ�̼���Ƿ�����ˡ������Ķ���
    /// </summary>
    /// <param name="Cursor">��ҵĹ��</param>
    private void OnTriggerStay(Collider Cursor)
    {
        if (Ipress)
        {
            MyDaddy_FloMenu.DeteButtonPress();
        }
    }


    #region һ����ť�Ĺ������������Ա��ⲿ����
    /// <summary>
    /// ���ɰ�ť�������˵�����ᴫ����Щ��Ϣ�������ð�ť�Ļ�����ʽ
    /// </summary>
    /// <param name="IconLook">��ť��LOGO</param>
    /// <param name="ButtonLook">��ť�ı�����</param>
    /// <param name="Buttonid">��ť��ID</param>
    /// <param name="position">��ť��λ��</param>
    public void SetUpButton(Sprite IconLook,Sprite ButtonLook,int Buttonid,Vector3 position)
    {
        IconImage.sprite = IconLook;
        ButtonImage.sprite = ButtonLook;
        ButtonID= Buttonid;
        this.gameObject.transform.localPosition= position;
    }
    
    /// <summary>
    /// ���ð�ť���գ�����ζ������ֵ��ظ�����
    /// </summary>
    public void ResetInsure()
    {
        insure = 0;
        this.gameObject.transform.GetChild(0).transform.localScale = Vector3.one * 0.5f;
    }

#endregion



    #region ��ť�Լ��Ľ����߼�
    /// <summary>
    /// ȷ����ҵ����ť�Ĵ����Ƿ���ڵ���2
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
    /// ��ʼ����ť�����Լ������
    /// </summary>
    private void InitButton()
    {
        //1���Լ���ӵ����
        //2���Լ��ľ���
        MyDaddy_FloMenu=this.transform.parent.gameObject.GetComponent<IR_FloatingMenu>();
        ButtonImage =this.gameObject.GetComponent<SpriteRenderer>();
        IconImage = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        
        //��ʼ��ͼ����ʽ
    }
    
    /// <summary>
    /// ���ı���ֵ��ͬʱ��΢�Ŵ�ť��logo
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
