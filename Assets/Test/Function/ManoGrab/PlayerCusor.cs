using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerCusor : MonoBehaviour
{
    [Tooltip("YES NO���ʣ��������ٲ��Ե���")]
    public Material HandOpenMaterial;
    public Material HandCloseMaterial;

    MeshRenderer CursorRenderer;

    //��������ײ��������������ʱȷ��������û���ṩ������ʵ�֣�����ṩ�˾��������Լ�ȥ������Ҫ���¼�������ץȡ�ſ����ֱ�����
    private void OnTriggerEnter(Collider BeTouch)
    {
        if(BeTouch.GetComponent<FD_Interaction>()!=null)
        {
            Debug.Log("������");
            BeTouch.GetComponent<FD_Interaction>().YesInteracted();
            BeTouch.GetComponent<FD_Interaction>().enabled = true;
        }
    }
    private void OnTriggerExit(Collider BeTouch)
    {
        if (BeTouch.GetComponent<FD_Interaction>() != null)
        {
            Debug.Log("û������");
            BeTouch.GetComponent<FD_Interaction>().NoInteracted();
            BeTouch.GetComponent<FD_Interaction>().enabled = false;
        }
    }

    //��ȡ���ó�ʼ��
    private void Awake()
    {
        CursorRenderer = this.transform.Find("playerCursor").gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        UpdatePlayerCursor();
    }
    //����������ɿ�����ʾ
    private void UpdatePlayerCursor()
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == ManoGestureContinuous.OPEN_HAND_GESTURE)
        {
            CursorRenderer.material= HandOpenMaterial;

        }
        else
        {
            CursorRenderer.material= HandCloseMaterial;
        }
    }

    private void OnServerInitialized()
    {
        CursorRenderer = this.transform.Find("playerCursor").gameObject.GetComponent<MeshRenderer>();
    }



}
