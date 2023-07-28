using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;

public class FD_ArManager : MonoBehaviour
{
    /*
     * 提供一个开关
     * 打开：将场景地图放到追踪到的图像上
     * 关闭：将场景地图固定（ARspace）*/
    [SerializeField]
    private GameObject test;

    [Tooltip("同步状态，开就是把地图一直摆到图像上，关就是锁定地图在现实世界的位置，值由开关控制")]
    private bool _IsUpdateMapLocation=true;
    
    [SerializeField]
    [Tooltip("AR图像追踪,如果有必要可以关掉这玩意来节约性能，同时避免遮挡到ar码导致的抖动")]
    private ARTrackedImageManager FD_TrackImageManager;
    /// <summary>
    /// 这个方法会被按钮调用,控制图形追踪识别功能
    /// </summary>
    public void Change_State()
    {
        _IsUpdateMapLocation =! _IsUpdateMapLocation;
        SetArSessionByState(_IsUpdateMapLocation);
    }

    /// <summary>
    /// 根据按钮状态来开关AR图像识别追踪功能，节省性能
    /// </summary>
    /// <param name="_isUpdateMapLocation"></param>
    private void SetArSessionByState(bool _isUpdateMapLocation) 
    {
        if (_isUpdateMapLocation)
        {       
            FD_TrackImageManager.enabled= true;
        }
        else
        {
            FD_TrackImageManager.enabled = false;
        }


    }


}
