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

    public string debugmessage= string.Empty;


    enum FD_LastGesture
    {
        OPENHAND = 0,
        CLOSEHAND = 1
    }
    //������ö�٣�������¼��һ�ε����ƣ���0��1�üǵ㣬��ʱ�򻹻��������ֱ��Ĺ��ܼ���,����д�߼������õ����
    FD_LastGesture _Playerlastgesture;
    [SerializeField]
    private GameObject playercursor; 

    private void Awake()
    {
        //Ĭ���Ǵ�״̬��ֱ����һ�μ�⵽�ֱ�
        _Playerlastgesture = FD_LastGesture.OPENHAND;
        //��ȡ��ͼ�ϵ�С��
    }
    private void Start()
    {
        GetCusorInMap();
    }
    void Update()
    {
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
        _PlayerCursor = Instantiate(playercursor,Camera.main.transform);
    }

    /// <summary>
    /// �����ɳ����Ĺ��ճ������
    /// </summary>
    private void LetCursorAttachToHand()
    {
        //������ȹ���ֵ����ֲ����걻��ֵ�����Ԥ�Ƽ����������Ҫ��ManoUtils���ĺ�������Ȼ���������λ�ù�ϵ�����
        _PlayerCursor.transform.position = ManoUtils.Instance.CalculateNewPositionDepth(ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.palm_center, ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info.depth_estimation);
    }


    /// <summary>
    /// �㲥�ֵ�״̬����,ֻ��ÿ����״̬���ĵ�ʱ��㲥һ��
    /// </summary>
    private void SendingStateChange()
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.hand_side == HandSide.Backside && _Playerlastgesture == FD_LastGesture.CLOSEHAND)
        {
            IAmRelease?.Invoke();
            _Playerlastgesture = FD_LastGesture.OPENHAND;
            debugmessage += "�㲥�ִ�";
        }
        else if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.hand_side == HandSide.Palmside && _Playerlastgesture == FD_LastGesture.OPENHAND)
        {
            IAmTouching?.Invoke();
            _Playerlastgesture = FD_LastGesture.CLOSEHAND;
            debugmessage+= "�㲥�ֹر�";
        }
    }




}
