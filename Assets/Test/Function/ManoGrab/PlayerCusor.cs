using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerCusor : MonoBehaviour
{
    [Tooltip("YES NO材质，用来快速测试调试")]
    [SerializeField]
    public Material HandOpenMaterial;
    public Material HandCloseMaterial;

    MeshRenderer CursorRenderer;

    public string debugmessage;

    //这两个碰撞检测会在碰到对象时确定对象有没有提供交互的实现，如果提供了就让他们自己去订阅需要的事件，比如抓取放开，手背手心
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

    //获取引用初始化
    void Awake()
    {
        CursorRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        UpdatePlayerCursor();
    }

    //更新捏合与松开的提示
    public void UpdatePlayerCursor()
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == ManoGestureContinuous.OPEN_HAND_GESTURE)
        {
            CursorRenderer.material = HandOpenMaterial;
            debugmessage+= "现在应该是绿色";
        }
        else
        {
            CursorRenderer.material = HandCloseMaterial;
            debugmessage += "现在应该是红色";
        }
    }


}
