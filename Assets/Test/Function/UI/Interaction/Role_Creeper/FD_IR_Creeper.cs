using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FD_IR_Creeper : FD_Interaction
{
    public static event Action IsMECreeper;

    public override void YesInteracted()
    {
        IR_FloatingMenu.Button2 += IamStupie;
        Mano_InputManger.IAmTouching += ShowMenu;
        Mano_InputManger.IAmRelease += base.MyUIManager.HideFloatMenu;
    }

    public override void NoInteracted()
    {
        Mano_InputManger.IAmTouching -= ShowMenu;
        Mano_InputManger.IAmRelease -= base.MyUIManager.HideFloatMenu;

    }

    private void ShowMenu()
    {
        base.MyUIManager.ShowFloatMenu(FloatMenuType.FloatMenu_Creeper, this.transform.position);
    }

    public void IamStupie()
    {
        AudioManager.whichtoplay = 1;
        IsMECreeper?.Invoke();
        AudioManager.whichtoplay = 0;
        IR_FloatingMenu.Button2 -= IamStupie;
        this.enabled= false;

    }

}
