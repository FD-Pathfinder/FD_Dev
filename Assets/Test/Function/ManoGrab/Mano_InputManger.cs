using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using static UnityEngine.UI.ContentSizeFitter;
//定义一个IcanInteractive接口，用来告诉光标接触到的物体有没有准备交互用到的函数
public interface IcanInteracted
{
    public void YesInteracted();
    public void NoInteracted();
}

public class Mano_InputManger : MonoBehaviour
{
    //todo
    //通过tag获取玩家光标预制件
    //提供一个方法用于使光标黏附在手上
    //广播事件抓住松手
    //记录手势变换前一个手势

    [Tooltip("玩家光标，用于存放用tag获取到的玩家光标")]
    private GameObject _PlayerCursor;
    public GameObject PlayerCursor
    {
        get { return _PlayerCursor; }
    }

    private PlayerCusor SC_PlayerCursor;

    public static event Action IAmTouching;
    public static event Action IAmRelease;

    public string debugmessage= string.Empty;


    enum FD_LastGesture
    {
        OPENHAND = 0,
        CLOSEHAND = 1
    }
    //声明个枚举，用来记录上一次的手势，比0和1好记点，到时候还会有手心手背的功能加入,你们写逻辑可以用到这个
    FD_LastGesture _Playerlastgesture;
    [SerializeField]
    private GameObject playercursor; 

    private void Awake()
    {
        //默认是打开状态，直到第一次监测到手背
        _Playerlastgesture = FD_LastGesture.OPENHAND;
        //获取地图上的小光
    }
    private void Start()
    {
        GetCusorInMap();
    }
    void Update()
    {
        //让光标粘手上
        LetCursorAttachToHand();
        //告诉订阅了手势更改的家伙手势改变了,只会在手势改变的时候更新
        SendingStateChange();

    }
   
    /// <summary>
    /// 获取生成出来的玩家光标，同时初始化一遍父对象
    /// </summary>
    private void GetCusorInMap()
    {
        _PlayerCursor = Instantiate(playercursor,Camera.main.transform);
    }

    /// <summary>
    /// 让生成出来的光标粘到手上
    /// </summary>
    private void LetCursorAttachToHand()
    {
        //加上深度估计值后的手部坐标被赋值给光标预制件，这里必须要用ManoUtils给的函数，不然与主相机的位置关系会出错
        _PlayerCursor.transform.position = ManoUtils.Instance.CalculateNewPositionDepth(ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.palm_center, ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation);
    }


    /// <summary>
    /// 广播手的状态更改,只在每次手状态更改的时候广播一次
    /// </summary>
    private void SendingStateChange()
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.hand_side == HandSide.Backside && _Playerlastgesture == FD_LastGesture.CLOSEHAND)
        {
            IAmRelease?.Invoke();
            _Playerlastgesture = FD_LastGesture.OPENHAND;
            debugmessage += "广播手打开";
        }
        else if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.hand_side == HandSide.Palmside && _Playerlastgesture == FD_LastGesture.OPENHAND)
        {
            IAmTouching?.Invoke();
            _Playerlastgesture = FD_LastGesture.CLOSEHAND;
            debugmessage+= "广播手关闭";
        }
    }




}
