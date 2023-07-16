using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
// 当前类因为还在测试和完善，所以变量都是public，方便调用和监测
public class Mano_InputManger : MonoBehaviour
{
    //todo
    //通过tag获取玩家光标预制件
    //提供一个方法用于使光标黏附在手上
    //提供一个抓住松手的方法和它的接口定义

    [Tooltip("玩家光标，用于存放用tag获取到的玩家光标，AR扫码生成出来的是一个prefab")]
    private GameObject _PlayerCursor;
    public GameObject PlayerCursor 
    {
        get { return _PlayerCursor; }
    }

    [Tooltip("YES NO材质，用来快速测试调试")]
    public Material YesMaterial;
    public Material NoMaterial;

    void Update()
    {
           // 更新光标信息
        GetCusorInMap();
        LetCursorAttachToHand();
        //实时检测是否能抓起物体
    }
   
    
    /// <summary>
    /// 设置变换父级为玩家的手机（maincamera）
    /// </summary>
    private void SetParent()
    {
        _PlayerCursor.transform.SetParent(Camera.main.transform);
    }
    

    /// <summary>
    /// 获取生成出来的玩家光标，同时初始化一遍父对象
    /// </summary>
    private void GetCusorInMap()
    {
        _PlayerCursor = GameObject.FindWithTag("GameController");
        SetParent();
    }


    /// <summary>
    /// 让生成出来的光标粘到手上
    /// </summary>
    private void LetCursorAttachToHand()
    {
        //加上深度估计值后的手部坐标被赋值给光标预制件，这里必须要用ManoUtils给的函数，不然与主相机的位置关系会出错
        _PlayerCursor.transform.position = ManoUtils.Instance.CalculateNewPositionDepth(ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.palm_center, ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.joints[9].z);
    }

    /// <summary>
    /// 弧度转度
    /// </summary>
    private float radianToDegrees(float radiantValue)
    {
        float degreeValue;
        degreeValue = radiantValue * Mathf.Rad2Deg;
        return degreeValue;
    }


    /// <summary>
    /// 触发碰撞判定
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous==ManoGestureContinuous.CLOSED_HAND_GESTURE)
        {
           //通过将互动目标的transform父级设置为玩家光标来达到拖动的目的，同时改变颜色来表示已抓取
            other.gameObject.transform.parent = PlayerCursor.transform;
            PlayerCursor.GetComponent<Renderer>().material = YesMaterial;
        }
        else
        {
            PlayerCursor.GetComponent<Renderer>().material = NoMaterial;
        }
    }



}
