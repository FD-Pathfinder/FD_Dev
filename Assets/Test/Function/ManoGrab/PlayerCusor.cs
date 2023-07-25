using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerCusor : MonoBehaviour
{
    [Tooltip("YES NO���ʣ��������ٲ��Ե���")]
    [SerializeField]
    public Material HandOpenMaterial;
    public Material HandCloseMaterial;

    MeshRenderer CursorRenderer;

    public string debugmessage;

    //��������ײ��������������ʱȷ��������û���ṩ������ʵ�֣�����ṩ�˾��������Լ�ȥ������Ҫ���¼�������ץȡ�ſ����ֱ�����
    private void OnTriggerEnter(Collider BeTouch)
    {

        if(BeTouch.GetComponent<FD_Interaction>()!=null)
        {
            BeTouch.GetComponent<FD_Interaction>().YesInteracted();
            BeTouch.GetComponent<FD_Interaction>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider BeTouch)
    {
        
        if (BeTouch.GetComponent<FD_Interaction>() != null)
        {
            BeTouch.GetComponent<FD_Interaction>().NoInteracted();
            BeTouch.GetComponent<FD_Interaction>().enabled = false;
        }
    }

    //��ȡ���ó�ʼ��
    void Awake()
    {
        CursorRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        UpdatePlayerCursor();
    }

    //����������ɿ�����ʾ
    public void UpdatePlayerCursor()
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == ManoGestureContinuous.OPEN_HAND_GESTURE)
        {
            CursorRenderer.material = HandOpenMaterial;
            debugmessage+= "����Ӧ������ɫ";
        }
        else
        {
            CursorRenderer.material = HandCloseMaterial;
            debugmessage += "����Ӧ���Ǻ�ɫ";
        }
    }


}
