using System;
using UnityEngine;


//总介绍：这个类会负责生成一个悬浮小菜单，它需要知道：小菜单有几个按钮，小菜单上的按钮的样子,
//这些数据会被打包成一个结构体传递给他

#region 这是这个功能会用到的枚举和结构体
[Tooltip("每一个元素就代表游戏中一种悬浮菜单")]
public enum FloatMenuType
{
    FloatMenu_Creeper=0,
    FloatMenu_Aegis=1,
    FloatMenu_Reform=2,
    FloatMenu_Monv=3
}

[Tooltip("这是一个悬浮菜单")]
[System.Serializable]
public struct FloatMenuBunker
{
    public string name;
    [Tooltip("悬浮菜单的种类")]
    public FloatMenuType MenuType;
    [Tooltip("这是按钮的数量，至少1个，最多五个"), Range(1, 5)]
    public int HowManyButtonIhave;
    [Tooltip("这是按钮的图标，数量请严格保证和按钮数量一样")]
    public Sprite[] IconImage;
    [Tooltip("这是按钮的背景板，数量请严格保证和按钮数量一样")]
    public Sprite[] ButtonImage;

}

#endregion

public class IR_FloatingMenu :  MonoBehaviour
{
    #region 按钮事件，可以让其他物体接收并作出反应
    public static event Action Button1;
    public static event Action Button2;
    public static event Action Button3;
    public static event Action Button4;
    public static event Action Button5;
    #endregion


    //声明按钮要用到的图
    private FloatMenuBunker Bunker;

    //储存预制件
    [SerializeField]
    private GameObject TheButtonMatrix;

    private IR_MenuButton[] ButtonArray;

    private Vector3[] ButtonPosition;

    //广播值，用来决定广播啥按钮事件，0就不广播

    private int ButtonBePress=0;
    
    private void Update()
    {
        LookAtCamera();
    }

    #region 基础高级功能
    /// <summary>
    /// 让菜单面向摄像机
    /// </summary>
    public void LookAtCamera()
    {
        this.gameObject.transform.LookAt(Camera.main.transform);
    }
    /// <summary>
    /// 传入结构体，根据结构体生成一个菜单
    /// </summary>
    /// <param name="inputBunker">这个结构体会从UI管理传入</param>
    public void SetupMenu(FloatMenuBunker inputBunker) 
    {
        //生成之前先把可能有的按钮全删了
        DestoryFloatMenu();
        Bunker = inputBunker;
        //从外部接收精灵组和按钮数量
        Init_FloatMenu();
    }
    /// <summary>
    /// 销毁所有按键,给UI管理用,当用户做出一次选择后也会调用
    /// </summary>
    public void DestoryFloatMenu()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject.Destroy(this.gameObject.transform.GetChild(i).gameObject);
        }
    }
    /// <summary>
    /// 监测菜单按钮状况，当按钮按下时就广播事件并销毁菜单
    /// </summary>
    public void DeteButtonPress()
    {
        ButtonBePress = RecvButtonPress();
        switch (ButtonBePress)
        {
            case 0:break;
            case 1: Button1?.Invoke(); DestoryFloatMenu(); break;
            case 2: Button2?.Invoke(); DestoryFloatMenu(); break;
            case 3: Button3?.Invoke(); DestoryFloatMenu(); break;
            case 4: Button4?.Invoke(); DestoryFloatMenu(); break;
            case 5: Button5?.Invoke(); DestoryFloatMenu(); break;
            default:break;
        }

    }
    #endregion
   
    #region 低级功能
    /// <summary>
    /// 初始化按钮
    /// </summary>
    private void Init_FloatMenu()
    {
        //初始化按钮数组
        ButtonArray = new IR_MenuButton[Bunker.HowManyButtonIhave];
        //初始化按钮位置
        ButtonPosition = Init_ButtonPosition(Bunker.HowManyButtonIhave);
        for (int ButtonID = 0; ButtonID < Bunker.HowManyButtonIhave; ButtonID++)
        {
            ButtonArray[ButtonID] = Instantiate(TheButtonMatrix,this.gameObject.transform ).GetComponent<IR_MenuButton>();
            ButtonArray[ButtonID].SetUpButton(Bunker.IconImage[ButtonID], Bunker.ButtonImage[ButtonID], ButtonID, ButtonPosition[ButtonID]);
        }
    }



    /// <summary>
    /// 根据按钮数量返回位置偏移量
    /// </summary>
    /// <param name="ButtonCount"></param>
    /// <returns></returns>
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
   /// 监测有无按钮被按下，返回按钮的数组索引并加一。
   /// </summary>
   /// <returns>按钮的索引加一，如果是0就是没有按钮被按下</returns>
    private int RecvButtonPress()
    {
        for (int ButtonID = 0; ButtonID < ButtonArray.Length; ButtonID++)
        {
            if (ButtonArray[ButtonID].Ipress)
            {
                return ButtonID + 1;
            }
        }
        return 0;
    }
    #endregion

}
