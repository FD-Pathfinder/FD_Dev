using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


//�ܽ��ܣ������Ḻ������һ������С�˵�������Ҫ֪����С�˵��м�����ť��С�˵��ϵİ�ť������
public class IR_FloatingMenu : FD_Interaction
{
    IR_FloatingMenu(int ButtonCount)
    {
        HowManyButtonIhave = ButtonCount;
    }

    //������ťҪ�õ���ͼ
    private Sprite[] IconImage;
    private Sprite[] ButtonImage;

    //����Ԥ�Ƽ�
    /// <summary>
    /// ��ťģ��
    /// </summary>
    [SerializeField]
    private GameObject TheButtonMatrix;

    private int HowManyButtonIhave=0;

    private IR_MenuButton[] ButtonArray; 
   
    private Vector3[] Init_ButtonPosition(int ButtonCount)
    {
        Vector3[] ButtonPosition= new Vector3[ButtonCount];
        switch (ButtonCount)
        {
            case 1: 
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up*15;
                return ButtonPosition;
            case 2: 
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 9;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 9;
                return ButtonPosition;

            case 3:
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 9;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15;
                ButtonPosition[2] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 9;
                return ButtonPosition;

            case 4:
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 12;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15 + Vector3.right * 5;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15 + Vector3.left * 5;
                ButtonPosition[2] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 12;
                return ButtonPosition;

            case 5:
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 12;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15+ Vector3.right * 5;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15 + Vector3.left * 5;
                ButtonPosition[2] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 12;
                return ButtonPosition;
            default:return null;

        }
    }
    
    
    /// <summary>
    /// ��ʼ����ť����ʽ����������ʱ��ť��λ�û�����ԭ��
    /// </summary>
    private void Init_FloatMenu()
    {
        //���ɰ�ť
        ButtonArray = new IR_MenuButton[HowManyButtonIhave];
        for (int ButtonID = 0; ButtonID < HowManyButtonIhave; ButtonID++)
        {
            ButtonArray[ButtonID] = Instantiate(TheButtonMatrix,this.gameObject.transform ).GetComponent<IR_MenuButton>();
            ButtonArray[ButtonID].SetUpButton(IconImage[ButtonID], ButtonImage[ButtonID],ButtonID);
        }


    }
    /// <summary>
    /// ���밴ť��������ťicon�͵װ壨���ҵ����Ӧ0-x��
    /// </summary>
    /// <param name="SpriteIcon"></param>
    /// <param name="spriteButton"></param>
    /// <param name="buttonCount"></param>
    public void SetupMenu(Sprite[] SpriteIcon, Sprite[] spriteButton,int buttonCount) 
    {
        
        IconImage= SpriteIcon;
        ButtonImage = spriteButton;
        HowManyButtonIhave = buttonCount;
        //���ⲿ���վ�����Ͱ�ť����
        Init_FloatMenu();
    }

}
