using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 更新UI的基础功能，UI控件需要包含这个接口，UI管理会在Update同步更新其他所有UI的显示信息
/// </summary>

public interface UpdateUI 
{
    public void UpdateMe();
}


public class FD_UI : MonoBehaviour
{
    #region 这个UI管理的解释
    // todo
    //各种ui组件会被作为子级连接到这个组件，每个组件启用与否都被一个布尔值控制
    //提供一个接口用于更新UI信息，每个与UI相关的脚本都需要提供更新自身UI信息的实现
    //提供初始化显示控件的方法
    #endregion

    #region 在inspector上挂的组件
    [Header("受UI管理者管理的的UI家族组件")]
    [SerializeField]
    //目前UI控件只有调试这一个
    private FD_UI_Debugstate UiDebugState;
    //生成菜单的工具
    [SerializeField]
    private IR_FloatingMenu UiMyFloatMenu;
    #endregion
   
    #region  生成悬浮菜单功能的用到的参数

    [Header("悬浮菜单")]
    [SerializeField]
    private FloatMenuBunker[] FloatMenuList;

    #endregion
    
    #region 悬浮菜单的生成和实现
    /// <summary>
    /// 传入菜单的信息，根据位置生成一个悬浮菜单
    /// </summary>
    /// <param name="TypeWantToBuild">想要生成悬浮菜单的信息</param>
    /// <param name="MyPosition">悬浮菜单的位置</param>
    public void ShowFloatMenu(FloatMenuType TypeWantToBuild,Vector3 MyPosition)
    {
        //找列表里对应的悬浮菜单数据，并生成一个悬浮菜单，并把组件移动到目标位置
        UiMyFloatMenu.gameObject.SetActive(true);
        UiMyFloatMenu.SetupMenu(FinDByMenuType(FloatMenuList,TypeWantToBuild));
        UiMyFloatMenu.gameObject.transform.position= MyPosition;
    }

    public void HideFloatMenu()
    {
        //找列表里对应的悬浮菜单数据，并生成一个悬浮菜单
        UiMyFloatMenu.DestoryFloatMenu();
        UiMyFloatMenu.gameObject.SetActive(false);
    }

    #endregion

    void Update()
    {
        UiDebugState.UpdateMe();
    }

    private void Start()
    {
        ShowFloatMenu(FloatMenuType.FloatMenu_Creeper, Vector3.zero);
    }

    #region 低级功能
    private FloatMenuBunker FinDByMenuType(FloatMenuBunker[] YouWantCheck,FloatMenuType type)
    {
        for (int i = 0; i < YouWantCheck.Length; i++)
        {
            if (YouWantCheck[i].MenuType == type)
            {
                return YouWantCheck[i];
            }
        }
        return YouWantCheck[0];
    }
    #endregion

}
