using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 处理许可licence etc.临时显示帧数和处理时间
/// </summary>
public class ManomotionUIManagment : MonoBehaviour
{
    private bool _showLicenseInfo;

    [SerializeField]
    private Text FPSValueText;
    [SerializeField]
    private Text processingTimeValueText;
    [SerializeField]
    private Text versionText;
    [SerializeField]
    private Text credits;
    [SerializeField]
    private Text daysLeft;
    [SerializeField]
    private Text licenseEnd;

    [SerializeField]
    private GameObject licenseInfoGizmo;

    private void Awake()
    {
        if (!licenseInfoGizmo)
        {
            licenseInfoGizmo = transform.Find("LicenseInfoGizmo").gameObject;
        }
        ManomotionManager.OnManoMotionFrameProcessed += DisplayInformationAfterManoMotionProcessFrame;
    }

    /// <summary>
    /// 在一次mano后更新帧数和处理一帧的时间
    /// </summary>
    void DisplayInformationAfterManoMotionProcessFrame()
    {
        UpdateFPSText();
        UpdateProcessingTime();
    }

    /// <summary>
    ///切换游戏对象的可见性。
    /// </summary>
    /// <param name="givenObject">Requires a Gameobject</param>
    public void ToggleUIElement(GameObject givenObject)
    {
        givenObject.SetActive(!givenObject.activeInHierarchy);
    }

    /// <summary>
    /// 使用计算的“每秒帧数”值更新文本字段。
    /// </summary>
    public void UpdateFPSText()
    {
        FPSValueText.text = ManomotionManager.Instance.Fps.ToString();
    }

    /// <summary>
    /// 使用计算的处理时间值更新文本字段。
    /// </summary>
    public void UpdateProcessingTime()
    {
        processingTimeValueText.text = ManomotionManager.Instance.Processing_time.ToString() + " ms";
    }

    /// <summary>
    /// 切换“显示许可信息”的可见性
    /// </summary>
    public void ToggleShowLicenseInfo()
    {
        _showLicenseInfo = !_showLicenseInfo;
        licenseInfoGizmo.SetActive(_showLicenseInfo);
        if (_showLicenseInfo)
        {
            credits.text = "Credits Remaining: " + ManomotionManager.Instance.Mano_License.machines_left.ToString();
            double current = (double)ManomotionManager.Instance.Mano_License.days_left;

            DateTime expiration = DateTime.Now.AddDays(ManomotionManager.Instance.Mano_License.days_left);
            daysLeft.text = "License Expires: " + expiration.ToString("MM/dd/yyyy");

            string lastDigits = "";

            for (int i = 0; i < ManomotionManager.Instance.LicenseKey.Length; i++)
            {
                if (i > ManomotionManager.Instance.LicenseKey.Length - 6)
                {
                    lastDigits += ManomotionManager.Instance.LicenseKey[i];
                }
            }

            licenseEnd.text = "License: " + lastDigits;
        }
    }

    /// <summary>
    /// 显示SDK的当前版本。
    /// </summary>
    //public void HandleManoMotionManagerInitialized()
    //{
    //    versionText.text = "";
    //    float versionFull = ManomotionManager.Instance.Mano_License.version;
    //    string prefix = "ManoMotion:";

    //    string versionString = versionFull.ToString();

    //    if (versionString.Length == 4)
    //    {
    //        versionString = versionString.Insert(versionString.Length - 1, ".");
    //    }

    //    else if (versionString.Length == 5)
    //    {
    //        versionString = versionString.Insert(versionString.Length - 2, ".");
    //        versionString = versionString.Insert(versionString.Length - 1, ".");
    //    }

    //    int versionLength = versionFull.ToString().Length;

    //    versionText.text = prefix += versionString;
    //}
}
