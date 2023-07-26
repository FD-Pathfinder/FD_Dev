using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


//总介绍：这个类会负责生成一个悬浮小菜单，它需要知道：小菜单有几个按钮，小菜单上的按钮的样子
public class IR_FloatingMenu : FD_Interaction
{
    IR_FloatingMenu(int ButtonCount)
    {
        HowManyButtonIhave = ButtonCount;
    }

    //声明按钮要用到的图
    private Sprite[] IconImage;
    private Sprite[] ButtonImage;

    //储存预制件
    /// <summary>
    /// 按钮模块
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
    /// 初始化按钮的样式和数量，这时候按钮的位置还是在原点
    /// </summary>
    private void Init_FloatMenu()
    {
        //生成按钮
        ButtonArray = new IR_MenuButton[HowManyButtonIhave];
        for (int ButtonID = 0; ButtonID < HowManyButtonIhave; ButtonID++)
        {
            ButtonArray[ButtonID] = Instantiate(TheButtonMatrix,this.gameObject.transform ).GetComponent<IR_MenuButton>();
            ButtonArray[ButtonID].SetUpButton(IconImage[ButtonID], ButtonImage[ButtonID],ButtonID);
        }


    }
    /// <summary>
    /// 传入按钮数量，按钮icon和底板（从右到左对应0-x）
    /// </summary>
    /// <param name="SpriteIcon"></param>
    /// <param name="spriteButton"></param>
    /// <param name="buttonCount"></param>
    public void SetupMenu(Sprite[] SpriteIcon, Sprite[] spriteButton,int buttonCount) 
    {
        
        IconImage= SpriteIcon;
        ButtonImage = spriteButton;
        HowManyButtonIhave = buttonCount;
        //从外部接收精灵组和按钮数量
        Init_FloatMenu();
    }

}
