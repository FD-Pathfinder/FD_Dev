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

    [Tooltip("��ҹ�꣬���ڴ����tag��ȡ������ҹ�꣬ARɨ�����ɳ�������һ��prefab")]
    private GameObject _PlayerCursor;
    public GameObject PlayerCursor 
    {
        get { return _PlayerCursor; }
    }

    [Tooltip("YES NO���ʣ��������ٲ��Ե���")]
    public Material YesMaterial;
    public Material NoMaterial;

    void Update()
    {
           // ���¹����Ϣ
        GetCusorInMap();
        LetCursorAttachToHand();
        //ʵʱ����Ƿ���ץ������
    }
   
    
    /// <summary>
    /// ���ñ任����Ϊ��ҵ��ֻ���maincamera��
    /// </summary>
    private void SetParent()
    {
        _PlayerCursor.transform.SetParent(Camera.main.transform);
    }
    

    /// <summary>
    /// ��ȡ���ɳ�������ҹ�꣬ͬʱ��ʼ��һ�鸸����
    /// </summary>
    private void GetCusorInMap()
    {
        _PlayerCursor = GameObject.FindWithTag("GameController");
        SetParent();
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
    /// ����ת��
    /// </summary>
    private float radianToDegrees(float radiantValue)
    {
        float degreeValue;
        degreeValue = radiantValue * Mathf.Rad2Deg;
        return degreeValue;
    }


    /// <summary>
    /// ������ײ�ж�
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous==ManoGestureContinuous.CLOSED_HAND_GESTURE)
        {
           //ͨ��������Ŀ���transform��������Ϊ��ҹ�����ﵽ�϶���Ŀ�ģ�ͬʱ�ı���ɫ����ʾ��ץȡ
            other.gameObject.transform.parent = PlayerCursor.transform;
            PlayerCursor.GetComponent<Renderer>().material = YesMaterial;
        }
        else
        {
            PlayerCursor.GetComponent<Renderer>().material = NoMaterial;
        }
    }



}
