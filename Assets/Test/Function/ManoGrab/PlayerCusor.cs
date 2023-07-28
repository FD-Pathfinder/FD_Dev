using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerCusor : MonoBehaviour
{
    [Tooltip("YES NO���ʣ��������ٲ��Ե���")]
    [SerializeField]
    public Material HandOpenMaterial;
    public Material HandCloseMaterial;

    MeshRenderer CursorRenderer;

    private bool handstate;

    public string debugmessage;

    //��������ײ��������������ʱȷ��������û���ṩ������ʵ�֣�����ṩ�˾��������Լ�ȥ������Ҫ���¼�������ץȡ�ſ����ֱ�����
    private void OnTriggerEnter(Collider BeTouch)
    {

        if(BeTouch.GetComponent<FD_Interaction>()!=null)
        {
            BeTouch.GetComponent<FD_Interaction>().enabled = true;
            BeTouch.GetComponent<FD_Interaction>().YesInteracted();
        }
    }

    private void OnTriggerExit(Collider BeTouch)
    {
        
        if (BeTouch.GetComponent<FD_Interaction>() != null)
        {
            BeTouch.GetComponent<FD_Interaction>().NoInteracted();
        }
    }

    //��ȡ���ó�ʼ��
    void Awake()
    {
        CursorRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        Mano_InputManger.IAmRelease += HandRelax;
        Mano_InputManger.IAmTouching += HandWantCheck;
    }


    //����������ɿ�����ʾ
    public void HandRelax()
    {
            CursorRenderer.material = HandOpenMaterial;
            debugmessage+= "����Ӧ������ɫ";
    }

    public void HandWantCheck()
    {
        CursorRenderer.material = HandCloseMaterial;
        debugmessage += "����Ӧ���Ǻ�ɫ";
    }


}
