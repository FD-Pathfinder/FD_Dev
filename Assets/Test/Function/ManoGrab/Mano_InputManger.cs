using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using static UnityEngine.UI.ContentSizeFitter;
//����һ��IcanInteractive�ӿڣ��������߹��Ӵ�����������û��׼�������õ��ĺ���
public interface IcanInteracted
{
    public void YesInteracted();
    public void NoInteracted();
}

public class Mano_InputManger : MonoBehaviour
{
    //todo
    //ͨ��tag��ȡ��ҹ��Ԥ�Ƽ�
    //�ṩһ����������ʹ���𤸽������
    //�㲥�¼�ץס����
    //��¼���Ʊ任ǰһ������

    [Tooltip("��ҹ�꣬���ڴ����tag��ȡ������ҹ��")]
    private GameObject _PlayerCursor;
    public GameObject PlayerCursor
    {
        get { return _PlayerCursor; }
    }

    private PlayerCusor SC_PlayerCursor;

    public static event Action IAmTouching;
    public static event Action IAmRelease;

    GestureInfo FD_gestureInfo;
    enum FD_LastGesture
    {
        OPENHAND = 0,
        CLOSEHAND = 1
    }
    //������ö�٣�������¼��һ�ε����ƣ���0��1�üǵ㣬��ʱ�򻹻��������ֱ��Ĺ��ܼ���,����д�߼������õ����
    FD_LastGesture _Playerlastgesture;

    private void Awake()
    {
        //Ĭ���Ǵ�״̬��ֱ����һ�μ�⵽������
        _Playerlastgesture = FD_LastGesture.OPENHAND;
        //��ȡ��ͼ�ϵ�С���
        GetCusorInMap();
    }
    void Update()
    {
        FD_gestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;
        //�ù��ճ����
        LetCursorAttachToHand();
        //���߶��������Ƹ��ĵļһ����Ƹı���,ֻ�������Ƹı��ʱ�����
        SendingStateChange();

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
    /// �㲥�ֵ�״̬����,ֻ��ÿ����״̬���ĵ�ʱ��㲥һ��
    /// </summary>
    private void SendingStateChange()
    {
        if (FD_gestureInfo.mano_gesture_continuous == ManoGestureContinuous.OPEN_HAND_GESTURE && _Playerlastgesture == FD_LastGesture.CLOSEHAND)
        {
            IAmRelease?.Invoke();
            _Playerlastgesture = FD_LastGesture.OPENHAND;
            Debug.Log("��");
        }
        else if (FD_gestureInfo.mano_gesture_continuous == ManoGestureContinuous.CLOSED_HAND_GESTURE && _Playerlastgesture == FD_LastGesture.OPENHAND)
        {
            IAmTouching?.Invoke();
            _Playerlastgesture = FD_LastGesture.CLOSEHAND;
            Debug.Log("�ر�");
        }
    }
    /// <summary>
    /// ������ʼ��Mano����
    /// </summary>




}
