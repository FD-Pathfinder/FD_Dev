
using UnityEngine;


public class FD_Interaction : MonoBehaviour, IcanInteracted
{
    private void Awake()
    {
        MyUIManager=GameObject.FindWithTag("FD_UI").GetComponent<FD_UI>();
        this.enabled = false;
    }
    #region 必须依赖的类
    [HideInInspector]
    public FD_UI MyUIManager;

    #endregion

    #region 虚方法，用来做接触式交互不同反馈（多态）
    public virtual void YesInteracted()
    {
        //这是一个抽象方法，你需要在继承自这个类的具体交互功能去实现它
        //它会在玩家的手触碰到游戏对象的时候被调用
    }
    public virtual void NoInteracted()
    {
        //这是一个抽象方法，你需要在继承自这个类的具体交互功能去实现它
        //它会在玩家的手不再接触到游戏对象的时候被调用
    }

    #endregion

    #region 获取触碰引用
    [HideInInspector]
    public GameObject WhoTouchMe;
    //当有东西在摸这个游戏对象时，取它的引用


    private void OnTriggerStay(Collider WhoTestMe)
    {
        WhoTouchMe = WhoTestMe.gameObject;
    }
    #endregion
}

