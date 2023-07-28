using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;

public class FD_ArManager : MonoBehaviour
{
    /*
     * �ṩһ������
     * �򿪣���������ͼ�ŵ�׷�ٵ���ͼ����
     * �رգ���������ͼ�̶���ARspace��*/
    [SerializeField]
    private GameObject test;

    [Tooltip("ͬ��״̬�������ǰѵ�ͼһֱ�ڵ�ͼ���ϣ��ؾ���������ͼ����ʵ�����λ�ã�ֵ�ɿ��ؿ���")]
    private bool _IsUpdateMapLocation=true;
    
    [SerializeField]
    [Tooltip("ARͼ��׷��,����б�Ҫ���Թص�����������Լ���ܣ�ͬʱ�����ڵ���ar�뵼�µĶ���")]
    private ARTrackedImageManager FD_TrackImageManager;
    /// <summary>
    /// ��������ᱻ��ť����,����ͼ��׷��ʶ����
    /// </summary>
    public void Change_State()
    {
        _IsUpdateMapLocation =! _IsUpdateMapLocation;
        SetArSessionByState(_IsUpdateMapLocation);
    }

    /// <summary>
    /// ���ݰ�ť״̬������ARͼ��ʶ��׷�ٹ��ܣ���ʡ����
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
