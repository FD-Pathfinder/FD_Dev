using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the main menu icon layout depending on the phone orientation
/// </summary>
public class IconMainMenu : MonoBehaviour
{
    public delegate void OrientationChange();
    public static event OrientationChange OnOrientationChanged;
    public ScreenOrientation currentOrientation;

    private void Start()
    {
        currentOrientation = ScreenOrientation.Unknown;
    }

    void Update()
    {
        CheckForScreenOrientationChange();
    }

    /// <summary>
    /// 触发碰撞判定
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.state>=7)
        {
            other.gameObject.transform.position = this.transform.position;
        }
    }


    /// <summary>
    /// Checks for changes on the orientation of the device.
    /// </summary>
    void CheckForScreenOrientationChange()
    {
        if (currentOrientation != Screen.orientation)
        {
            currentOrientation = Screen.orientation;
            OnOrientationChanged();
        }
    }

    /// <summary>
    /// Updates the orientation when enabled.
    /// </summary>
    void OnEnable()
    {
        if (OnOrientationChanged != null)
        {
            OnOrientationChanged();
        }
    }
}
