using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerCusor : MonoBehaviour
{
    [Tooltip("YES NO材质，用来快速测试调试")]
    [SerializeField]
    public Material HandOpenMaterial;
    public Material HandCloseMaterial;

    MeshRenderer CursorRenderer;

    private bool handstate;

    public string debugmessage;

    //这两个碰撞检测会在碰到对象时确定对象有没有提供交互的实现，如果提供了就让他们自己去订阅需要的事件，比如抓取放开，手背手心
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

    //获取引用初始化
    void Awake()
    {
        CursorRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        Mano_InputManger.IAmRelease += HandRelax;
        Mano_InputManger.IAmTouching += HandWantCheck;
    }


    //更新捏合与松开的提示
    public void HandRelax()
    {
            CursorRenderer.material = HandOpenMaterial;
            debugmessage+= "现在应该是绿色";
    }

    public void HandWantCheck()
    {
        CursorRenderer.material = HandCloseMaterial;
        debugmessage += "现在应该是红色";
    }


}
