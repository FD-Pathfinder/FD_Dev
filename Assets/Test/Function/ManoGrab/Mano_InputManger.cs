using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
// ��ǰ����Ϊ���ڲ��Ժ����ƣ����Ա�������public��������úͼ��
public class Mano_InputManger : MonoBehaviour
{
    //todo
    //ͨ��tag��ȡ��ҹ��Ԥ�Ƽ�
    //�ṩһ����������ʹ���𤸽������
    //�ṩһ��ץס���ֵķ��������Ľӿڶ���
    public ManoGestureContinuous OpenHand= (ManoGestureContinuous)2;
    public ManoGestureContinuous CloseHand= (ManoGestureContinuous)4;
    
[Tooltip("��ҹ�꣬���ڴ����tag��ȡ������ҹ��")]
    private GameObject _PlayerCursor;
    public GameObject PlayerCursor 
    {
        get { return _PlayerCursor; }
    }

    [Tooltip("YES NO���ʣ��������ٲ��Ե���")]
    public Material YesMaterial;
    public Material NoMaterial;


    public static event Action IWasTouching;

    public static event Action IWasLeaving;


    void Update()
    {
           // ���¹����Ϣ
        GetCusorInMap();
        LetCursorAttachToHand();
        //ʵʱ����Ƿ���ץ������
    }
   

    /// <summary>
    /// ��ȡ���ɳ�������ҹ�꣬ͬʱ��ʼ��һ�鸸����
    /// </summary>
    private void GetCusorInMap()
    {
        _PlayerCursor = GameObject.FindWithTag("GameController");
        _PlayerCursor.transform.SetParent(Camera.main.transform);
    }

    /// <summary>
    /// �����ɳ����Ĺ��ճ������
    /// </summary>
    private void LetCursorAttachToHand()
    {
        //������ȹ���ֵ����ֲ����걻��ֵ�����Ԥ�Ƽ����������Ҫ��ManoUtils���ĺ�������Ȼ���������λ�ù�ϵ�����
        _PlayerCursor.transform.position = ManoUtils.Instance.CalculateNewPositionDepth(ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.palm_center, ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.skeleton.joints[9].z);
    }


    /// <summary>
    /// ������ײ�ж�
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == CloseHand)
        {
            
        }
    }



}
