using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

/// <summary>
/// Handles wich features / gizmos that will be calculated and visualized.
/// </summary>
public class GizmoManager : MonoBehaviour
{
    #region Singleton
    private static GizmoManager _instance;
    public static GizmoManager Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
    #endregion

    #region  UI控件声明，这些控件会根据manomotion的运行状态在屏幕上显示

    public Color disabledStateColor;
    [SerializeField]
    private Image[] stateImages;
    [SerializeField]
    private GameObject leftRightGizmo;
    [SerializeField]
    private GameObject handStatesGizmo;
    [SerializeField]
    private GameObject manoClassGizmo;
    [SerializeField]
    private GameObject handSideGizmo;
    [SerializeField]
    private GameObject continuousGestureGizmo;
    [SerializeField]
    private GameObject triggerTextPrefab;
    [SerializeField]
    private GameObject flagHolderGizmo;
    [SerializeField]
    private GameObject smoothingSliderControler;
    [SerializeField]
    private GameObject depthEstimationGizmo;
    private GameObject wristInformationGizmo;
    private GameObject fingerInformationGizmo;
    [SerializeField]
    private GameObject contourInformationGizmo;
    private WristInfoGizmo wristInfoGizmo;
    private FingerInfoGizmo fingerInfoGizmo;
    [SerializeField]
    private ContourGizmo contourGizmo;
    [SerializeField]
    private Text currentSmoothingValue;
    private GameObject topFlag;
    private GameObject leftFlag;
    private GameObject rightFlag;
    private Text leftRightText;
    private Text manoClassText;
    private Text handSideText;
    private Text continuousGestureText;
    private TMP_Text fingerFlag;
    private TMP_Text wristFlag;
    private TextMeshProUGUI depthEstimationValue;
    private Image depthFillAmmount;
    #endregion
   
    #region  布尔值声明，这些值会用来控制manomotion提供的功能是否启用
    [SerializeField]
    private bool _showGestureAnalysis;
    [SerializeField]
    private bool _showPickDrop;
    [SerializeField]
    private bool _showGrabRelease;
    [SerializeField]
    private bool _showSwipes;

    private bool _showLeftRight;
    private bool _showHandStates;
    private bool _showManoClass;
    private bool _showHandSide;
    private bool _showContinuousGestures;

    [SerializeField]
    private bool _showWarnings;
    private bool _showPickTriggerGesture;
    private bool _showDropTriggerGesture;
    private bool _showSwipeHorizontalTriggerGesture;
    private bool _showSwipeVerticalTriggerGesture;
    [SerializeField]
    private bool _showClickTriggerGesture;
    private bool _showGrabTriggerGesture;
    private bool _showReleaseTriggerGesture;
    [SerializeField]
    private bool _showSmoothingSlider;
    [SerializeField]
    private bool _showDepthEstimation;

    [SerializeField]
    private bool _showWristInfo;
    [SerializeField]
    private bool _showFingerInfo;
    [SerializeField]
    private bool _showContour;
    [SerializeField]
    private bool skeleton3d;
    //关键参数
    [SerializeField]
    private bool gestures;
    [SerializeField]
    private bool fastMode;
    #endregion

    #region  给private布尔值设置访问方式

    public bool ShowLeftRight
    {
        get { return _showLeftRight; }
        set { _showLeftRight = value; }
    }

    public bool ShowGrabRelease
    {
        get { return _showGrabRelease; }
        set { _showGrabRelease = value; }
    }

    public bool ShowPickDrop
    {
        get { return _showPickDrop; }
        set { _showPickDrop = value; }
    }

    public bool ShowSwipes
    {
        get { return _showSwipes; }
        set { _showSwipes = value; }
    }

    public bool ShowGestureAnalysis
    {
        get
        {
            return _showGestureAnalysis;
        }

        set
        {
            _showGestureAnalysis = value;
        }
    }

    public bool ShowContinuousGestures
    {
        get
        {
            return _showContinuousGestures;
        }

        set
        {
            _showContinuousGestures = value;
        }
    }

    public bool ShowManoClass
    {
        get
        {
            return _showManoClass;
        }

        set
        {
            _showManoClass = value;
        }
    }

    public bool ShowHandSide
    {
        get
        {
            return _showHandSide;
        }

        set
        {
            _showHandSide = value;
        }
    }

    public bool ShowHandStates
    {
        get
        {
            return _showHandStates;
        }

        set
        {
            _showHandStates = value;
        }
    }

    public bool ShowWarnings
    {
        get
        {
            return _showWarnings;
        }

        set
        {
            _showWarnings = value;
        }
    }

    public bool ShowPickTriggerGesture
    {
        get
        {
            return _showPickTriggerGesture;
        }

        set
        {
            _showPickTriggerGesture = value;
        }
    }

    public bool ShowDropTriggerGesture
    {
        get
        {
            return _showDropTriggerGesture;
        }

        set
        {
            _showDropTriggerGesture = value;
        }
    }

    public bool ShowSwipeHorizontalTriggerGesture
    {
        get
        {
            return _showSwipeHorizontalTriggerGesture;
        }

        set
        {
            _showSwipeHorizontalTriggerGesture = value;
        }
    }

    public bool ShowSwipeVerticalTriggerGesture
    {
        get
        {
            return _showSwipeVerticalTriggerGesture;
        }

        set
        {
            _showSwipeVerticalTriggerGesture = value;
        }
    }

    public bool ShowClickTriggerGesture
    {
        get
        {
            return _showClickTriggerGesture;
        }

        set
        {
            _showClickTriggerGesture = value;
        }
    }

    public bool ShowGrabTriggerGesture
    {
        get
        {
            return _showGrabTriggerGesture;
        }

        set
        {
            _showGrabTriggerGesture = value;
        }
    }

    public bool ShowReleaseTriggerGesture
    {
        get
        {
            return _showReleaseTriggerGesture;
        }

        set
        {
            _showReleaseTriggerGesture = value;
        }
    }

    public bool ShowSmoothingSlider
    {
        get
        {
            return _showSmoothingSlider;
        }

        set
        {
            _showSmoothingSlider = value;
        }
    }

    public bool ShowDepthEstimation
    {
        get
        {
            return _showDepthEstimation;
        }
        set
        {
            _showDepthEstimation = value;
        }
    }

    public bool ShowSkeleton3d
    {
        get
        {
            return skeleton3d;
        }
        set
        {
            skeleton3d = value;
        }
    }

    public bool ShowGestures
    {
        get
        {
            return gestures;
        }
        set
        {
            gestures = value;
        }
    }

    public bool Fastmode
    {
        get
        {
            return fastMode;
        }
        set
        {
            fastMode = value;
        }
    }

    public bool ShowWristInfo
    {
        get
        {
            return _showWristInfo;
        }
        set
        {
            _showWristInfo = value;
        }
    }

    public bool ShowFingerInfo
    {
        get
        {
            return _showFingerInfo;
        }
        set
        {
            _showFingerInfo = value;
        }
    }

    public bool ShowContour
    {
        get
        {
            return _showContour;
        }
        set
        {
            _showContour = value;
        }
    }

    #endregion

    /// <summary>
    /// 设置根据布尔值设置哪些manomotion的功能应该被启用
    /// <summary>
    void Start()
    {
        #region 确保游戏至少有一个ManoMotion控件管理
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion
       
        SetGestureDescriptionParts();
        
        SetFlagDescriptionParts();
        HighlightStatesToStateDetection(0);
        InitializeFlagParts();
        InitializeTriggerPool();
        SetFeaturesToCalculate();
    }

    /// <summary>
    /// 设置根据布尔值设置哪些manomotion的功能应该被启用
    /// <summary>
    private void SetFeaturesToCalculate()
    {
        //是否计算手势，详见manomotion手势支持
        ManomotionManager.Instance.ShouldCalculateGestures(ShowGestures);
        //是否计算3D骨架
        ManomotionManager.Instance.ShouldCalculateSkeleton3D(ShowSkeleton3d);
        //是否用快速模式，可能会产生点问题
        ManomotionManager.Instance.ShouldRunFastMode(Fastmode);
        //是否计算手腕信息
        ManomotionManager.Instance.ShouldRunWristInfo(ShowWristInfo);
        //是否计算手指信息
        ManomotionManager.Instance.ShouldRunFingerInfo(ShowFingerInfo);
        //是否进行外轮廓估计，很耗性能
        ManomotionManager.Instance.ShouldRunContour(ShowContour);
    }

    /// <summary>
    /// 每帧更新手势信息，跟踪信息，警告，还有其他的杂七杂八
    /// 同时也更新UI上的显示信息
    /// </summary>
    void Update()
    {
        GestureInfo gestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;
        TrackingInfo trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
        Warning warning = ManomotionManager.Instance.Hand_infos[0].hand_info.warning;
        Session session = ManomotionManager.Instance.Manomotion_Session;

        DisplayContinuousGestures(gestureInfo.mano_gesture_continuous);
        DisplayManoclass(gestureInfo.mano_class);
        DisplayTriggerGesture(gestureInfo.mano_gesture_trigger, trackingInfo);
        DisplayHandState(gestureInfo.state);
        DisplayHandSide(gestureInfo.hand_side);
        DisplayApproachingToEdgeFlags(warning);
        DisplayFingerFlags(trackingInfo, gestureInfo);
        DisplayWristFlags(trackingInfo, gestureInfo);
        DisplayCurrentsmoothingValue(session);
        DisplaySmoothingSlider();
        DisplayDepthEstimation(trackingInfo.depth_estimation);
        DisplayWristInformation();
        DisplayFingerInformation();
        DisplayContour();
        DisplayLeftRight(gestureInfo.is_right);
    }

    #region Display Methods

    /// <summary>
    /// Displays the Wrist Information from WristInfoGizmo for the detected hand if feature is on.
    /// </summary>
    private void DisplayWristInformation()
    {
        if (wristInfoGizmo == null)
        {
            wristInfoGizmo = GameObject.Find("TryOnManager").GetComponent<WristInfoGizmo>();
            wristInformationGizmo = GameObject.Find("Wrist");
        }

        wristInformationGizmo.SetActive(ShowWristInfo);

        if (ShowWristInfo)
        {
            wristInfoGizmo.ShowWristInformation();
        }
    }

    /// <summary>
    /// Dispalys the Finger information from FingerInfoGizmo for the detected hand if feature is on.
    /// </summary>
    private void DisplayFingerInformation()
    {
        if (fingerInfoGizmo == null)
        {
            fingerInfoGizmo = GameObject.Find("TryOnManager").GetComponent<FingerInfoGizmo>();
            fingerInformationGizmo = GameObject.Find("Finger");
        }

        fingerInformationGizmo.SetActive(ShowFingerInfo);

        if (ShowFingerInfo)
        {
            fingerInfoGizmo.ShowFingerInformation();
        }
    }

    /// <summary>
    /// Displays the hand contour from ContourGizmo if feature is on.
    /// </summary>
    private void DisplayContour()
    {
        contourInformationGizmo.SetActive(ShowContour);

        if (ShowContour)
        {
            contourGizmo.ShowContour();
        }
    }

    /// <summary>
    /// Displays the depth estimation of the detected hand.
    /// </summary>
    /// <param name="depthEstimation">Requires the float value of depth estimation.</param>
    void DisplayDepthEstimation(float depthEstimation)
    {
        depthEstimationGizmo.SetActive(ShowDepthEstimation);

        if (!depthEstimationValue)
        {
            depthEstimationValue = depthEstimationGizmo.transform.Find("DepthValue").gameObject.GetComponent<TextMeshProUGUI>();
        }
        if (!depthFillAmmount)
        {
            depthFillAmmount = depthEstimationGizmo.transform.Find("CurrentLevel").gameObject.GetComponent<Image>();
        }
        if (ShowDepthEstimation)
        {
            depthEstimationValue.text = depthEstimation.ToString("F2");
            depthFillAmmount.fillAmount = depthEstimation;
        }
    }

    /// <summary>
    /// Displays in text value the current smoothing value of the session
    /// </summary>
    /// <param name="session">Requires a Session.</param>
    void DisplayCurrentsmoothingValue(Session session)
    {
        if (smoothingSliderControler.activeInHierarchy)
        {
            currentSmoothingValue.text = "Tracking smoothing: " + session.smoothing_controller.ToString("F2");
        }
    }

    /// <summary>
    /// Displays information regarding the detected manoclass
    /// </summary>
    /// <param name="manoclass">Requires a Manoclass.</param>
    void DisplayManoclass(ManoClass manoclass)
    {
        manoClassGizmo.SetActive(ShowGestureAnalysis);
        if (ShowGestureAnalysis)
        {
            switch (manoclass)
            {
                case ManoClass.NO_HAND:
                    manoClassText.text = "Manoclass: No Hand";
                    break;
                case ManoClass.GRAB_GESTURE:
                    manoClassText.text = "Manoclass: Grab Class";
                    break;
                case ManoClass.PINCH_GESTURE:
                    manoClassText.text = "Manoclass: Pinch Class";
                    break;
                case ManoClass.POINTER_GESTURE:
                    manoClassText.text = "Manoclass: Pointer Class";
                    break;
                default:
                    manoClassText.text = "Manoclass: No Hand";
                    break;
            }
        }
    }

    /// <summary>
    /// Displays information regarding the detected manoclass
    /// </summary>
    /// <param name="manoGestureContinuous">Requires a continuous Gesture.</param>
    void DisplayContinuousGestures(ManoGestureContinuous manoGestureContinuous)
    {
        continuousGestureGizmo.SetActive(ShowGestureAnalysis);
        if (ShowGestureAnalysis)
        {
            switch (manoGestureContinuous)
            {
                case ManoGestureContinuous.CLOSED_HAND_GESTURE:
                    continuousGestureText.text = "Continuous: Closed Hand";
                    break;
                case ManoGestureContinuous.OPEN_HAND_GESTURE:
                    continuousGestureText.text = "Continuous: Open Hand";
                    break;
                case ManoGestureContinuous.HOLD_GESTURE:
                    continuousGestureText.text = "Continuous: Hold";
                    break;
                case ManoGestureContinuous.OPEN_PINCH_GESTURE:
                    continuousGestureText.text = "Continuous: Open Pinch";
                    break;
                case ManoGestureContinuous.POINTER_GESTURE:
                    continuousGestureText.text = "Continuous: Pointing";
                    break;
                case ManoGestureContinuous.NO_GESTURE:
                    continuousGestureText.text = "Continuous: None";
                    break;
                default:
                    continuousGestureText.text = "Continuous: None";
                    break;
            }
        }
    }

    /// <summary>
    /// Displays wich hand side currently facing the camera.
    /// </summary>
    /// <param name="handside">Requires a ManoMotion Handside.</param>
    void DisplayHandSide(HandSide handside)
    {
        handSideGizmo.SetActive(ShowGestureAnalysis);

        if (!handSideGizmo.activeInHierarchy && ShowHandSide)
        {
            handSideGizmo.SetActive(ShowHandSide);
        }

        if (ShowGestureAnalysis || ShowHandSide)
        {
            switch (handside)
            {
                case HandSide.Palmside:
                    handSideText.text = "Handside: Palm Side";
                    break;
                case HandSide.Backside:
                    handSideText.text = "Handside: Back Side";
                    break;
                case HandSide.None:
                    handSideText.text = "Handside: None";
                    break;
                default:
                    handSideText.text = "Handside: None";
                    break;
            }
        }
    }

    /// <summary>
    /// Displays wich hand currently facing the camera.
    /// </summary>
    /// <param name="isRight">Requiers the isRight from Gesture Inforamtion</param>
    void DisplayLeftRight(int isRight)
    {
        leftRightGizmo.SetActive(ShowGestureAnalysis);

        if (ShowGestureAnalysis)
        {
            switch (isRight)
            {
                case 0:
                    leftRightText.text = "Hand: Left";
                    break;
                case 1:
                    leftRightText.text = "Hand: Right";
                    break;
                default:
                    leftRightText.text = "Hand: None";
                    break;
            }
        }
    }

    /// <summary>
    /// Updates the visual information that showcases the hand state (how open/closed) it is
    /// </summary>
    /// <param name="handstate">Requires a handsate int</param>
    void DisplayHandState(int handstate)
    {
        handStatesGizmo.SetActive(ShowGestureAnalysis);
        if (ShowGestureAnalysis)
        {
            HighlightStatesToStateDetection(handstate);
        }
    }

    private ManoGestureTrigger previousTrigger;

    /// <summary>
    /// Display Visual information of the detected trigger gesture and trigger swipes.
    /// In the case where a click is intended (Open pinch, Closed Pinch, Open Pinch) we are clearing out the visual information that are generated from the pick/drop
    /// </summary>
    /// <param name="triggerGesture">Requires an input from ManoGestureTrigger.</param>
    /// <param name="trackingInfo">Requires an input of tracking info.</param>
    void DisplayTriggerGesture(ManoGestureTrigger triggerGesture, TrackingInfo trackingInfo)
    {

        if (triggerGesture != ManoGestureTrigger.NO_GESTURE)
        {

            if (_showPickDrop)
            {
                if (triggerGesture == ManoGestureTrigger.PICK)
                {
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.PICK);
                }
            }

            if (_showPickDrop)
            {
                if (triggerGesture == ManoGestureTrigger.DROP)
                {
                    if (previousTrigger != ManoGestureTrigger.CLICK)
                    {
                        TriggerDisplay(trackingInfo, ManoGestureTrigger.DROP);
                    }
                }
            }

            if (_showClickTriggerGesture)
            {
                if (triggerGesture == ManoGestureTrigger.CLICK)
                {
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.CLICK);
                    if (GameObject.Find("PICK"))
                    {
                        GameObject.Find("PICK").SetActive(false);
                    }
                }
            }

            if (_showSwipes)
            {
                if (triggerGesture == ManoGestureTrigger.SWIPE_LEFT)
                {
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.SWIPE_LEFT);
                }
            }

            if (_showSwipes)
            {
                if (triggerGesture == ManoGestureTrigger.SWIPE_RIGHT)
                {
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.SWIPE_RIGHT);
                }
            }

            if (_showSwipes)
            {
                if (triggerGesture == ManoGestureTrigger.SWIPE_UP)
                {
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.SWIPE_UP);
                }
            }

            if (_showSwipes)
            {
                if (triggerGesture == ManoGestureTrigger.SWIPE_DOWN)
                {
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.SWIPE_DOWN);
                }
            }

            if (_showGrabRelease)
            {
                if (triggerGesture == ManoGestureTrigger.GRAB_GESTURE)
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.GRAB_GESTURE);
            }

            if (_showGrabRelease)
            {
                if (triggerGesture == ManoGestureTrigger.RELEASE_GESTURE)
                    TriggerDisplay(trackingInfo, ManoGestureTrigger.RELEASE_GESTURE);
            }
        }

        previousTrigger = triggerGesture;
    }

    public List<GameObject> triggerObjectPool = new List<GameObject>();
    public int amountToPool = 20;

    /// <summary>
    /// Initializes the object pool for trigger gestures.
    /// </summary>
    private void InitializeTriggerPool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject newTriggerObject = Instantiate(triggerTextPrefab);
            newTriggerObject.transform.SetParent(transform);
            newTriggerObject.SetActive(false);
            triggerObjectPool.Add(newTriggerObject);
        }
    }

    /// <summary>
    /// Gets the current pooled trigger object.
    /// </summary>
    /// <returns>The current pooled trigger.</returns>
    private GameObject GetCurrentPooledTrigger()
    {
        for (int i = 0; i < triggerObjectPool.Count; i++)
        {
            if (!triggerObjectPool[i].activeInHierarchy)
            {
                return triggerObjectPool[i];
            }
        }
        return null;
    }

    /// <summary>
    /// Displays the visual information of the performed trigger gesture.
    /// </summary>
    /// <param name="bounding_box">Bounding box.</param>
    /// <param name="triggerGesture">Trigger gesture.</param>
    void TriggerDisplay(TrackingInfo trackingInfo, ManoGestureTrigger triggerGesture)
    {

        if (GetCurrentPooledTrigger())
        {
            GameObject triggerVisualInformation = GetCurrentPooledTrigger();

            triggerVisualInformation.SetActive(true);
            triggerVisualInformation.name = triggerGesture.ToString();
            triggerVisualInformation.GetComponent<TriggerGizmo>().InitializeTriggerGizmo(triggerGesture);
            triggerVisualInformation.GetComponent<RectTransform>().position = Camera.main.ViewportToScreenPoint(trackingInfo.palm_center);

        }
    }

    /// <summary>
    /// 通过一个槽位的满与空的程度来显示手的开合状态
    /// </summary>
    /// <param name="stateValue">需要一个hand state </param>
    void HighlightStatesToStateDetection(int stateValue)
    {
        for (int i = 0; i < stateImages.Length; i++)
        {
            if (i > stateValue)
            {
                stateImages[i].color = disabledStateColor;
            }
            else
            {
                stateImages[i].color = Color.white;
            }
        }
    }

    /// <summary>
    /// 根据ManoManger给的值来显示屏幕边缘
    /// </summary>
    /// <param name="warning">Requires a Warning.</param>
    void DisplayApproachingToEdgeFlags(Warning warning)
    {
        if (_showWarnings)
        {
            if (!flagHolderGizmo.activeInHierarchy)
            {
                flagHolderGizmo.SetActive(true);
            }

            rightFlag.SetActive(warning == Warning.WARNING_APPROACHING_RIGHT_EDGE);
            topFlag.SetActive(warning == Warning.WARNING_APPROACHING_UPPER_EDGE);
            leftFlag.SetActive(warning == Warning.WARNING_APPROACHING_LEFT_EDGE);
        }
        else
        {
            if (flagHolderGizmo.activeInHierarchy)
            {
                flagHolderGizmo.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 显示手腕信息的错误代码
    /// </summary>
    /// <param name="trackingInfo"></param>
    private void DisplayWristFlags(TrackingInfo trackingInfo, GestureInfo gestureInfo)
    {
        if (wristFlag != null)
        {
            if (ShowWristInfo && gestureInfo.mano_class != ManoClass.NO_HAND)
            {
                switch (trackingInfo.wristInfo.wristWarning)
                {
                    case 0:
                        wristFlag.text = "";
                        break;
                    case 2000:
                        wristFlag.text = "WRIST ERROR[2000]";
                        break;
                    default:
                        wristFlag.text = "";
                        break;
                }
            }

            else
            {
                wristFlag.text = "";
            }
        }
    }

    /// <summary>
    /// 显示与手指错误相关的代码
    /// </summary>
    /// <param name="trackingInfo">trackinginfo参数</param>
    private void DisplayFingerFlags(TrackingInfo trackingInfo, GestureInfo gestureInfo)
    {
        if (fingerFlag != null)
        {
            if (ShowFingerInfo && gestureInfo.mano_class != ManoClass.NO_HAND)
            {
                switch (trackingInfo.fingerInfo.fingerWarning)
                {
                    case 0:
                        fingerFlag.text = "";
                        break;
                    case 1001:
                        fingerFlag.text = "FINGER ERROR[1001]";
                        break;
                    case 1002:
                        fingerFlag.text = "FINGER POINTS CLOSE TO EDGE[1002]";
                        break;
                    case 1003:
                        fingerFlag.text = "FINGER POINTS OUTSIDE FRAME[1003]";
                        break;
                    case 1004:
                        fingerFlag.text = "FINGER POINTS TO CLOSE TO PALM[1004]";
                        break;
                    case 1005:
                        fingerFlag.text = "FINGER ERROR[1005]";
                        break;
                    case 1006:
                        fingerFlag.text = "FINGER ERROR[1006]";
                        break;
                    case 1007:
                        fingerFlag.text = "FINGER ERROR[1007]";
                        break;
                    case 1008:
                        fingerFlag.text = "FINGER ERROR[1008]";
                        break;
                    case 1009:
                        fingerFlag.text = "FINGER ERROR[1009]";
                        break;
                    case 1010:
                        fingerFlag.text = "FINGER ERROR[1010]";
                        break;
                    case 1011:
                        fingerFlag.text = "FINGER ERROR[1011]";
                        break;
                    case 1012:
                        fingerFlag.text = "FINGER ERROR[1012]";
                        break;
                    case 1013:
                        fingerFlag.text = "FINGER ERROR[1013]";
                        break;
                    default:
                        fingerFlag.text = "";
                        break;
                }
            }

            else
            {
                fingerFlag.text = "";
            }
        }
    }

    /// <summary>
    /// 是否显示平滑度
    /// </summary>
    /// <param name="display">如果设置 <c>true</c> 就会显示</param>
    public void ShouldDisplaySmoothingSlider(bool display)
    {
        smoothingSliderControler.SetActive(display);
    }

    /// <summary>
    /// 显示平滑程度滑块，就是解决抖动问题的一个参数：平滑度
    /// </summary>
    public void DisplaySmoothingSlider()
    {
        smoothingSliderControler.SetActive(_showSmoothingSlider);
    }

    /// <summary>
    /// 找到那些用来显示具体数值的TEXT组件，包括手势的当前描述，左右手的描述，持续姿势的描述
    /// </summary>
    void SetGestureDescriptionParts()
    {
        manoClassText = manoClassGizmo.transform.Find("Description").GetComponent<Text>();
        handSideText = handSideGizmo.transform.Find("Description").GetComponent<Text>();
        continuousGestureText = continuousGestureGizmo.transform.Find("Description").GetComponent<Text>();
        leftRightText = leftRightGizmo.transform.Find("Description").GetComponent<Text>();
    }

    /// <summary>
    /// 初始化手指和手腕的显示组件，
    /// </summary>
    void SetFlagDescriptionParts()
    {
        try
        {
            fingerFlag = GameObject.Find("FingerFlag").GetComponent<TMP_Text>();
        }
        catch (Exception ex)
        {
            Debug.Log("Cant find finger flag TMP_Text.");
            Debug.Log(ex);
        }

        try
        {
            wristFlag = GameObject.Find("WristFlag").GetComponent<TMP_Text>();
        }
        catch (Exception ex)
        {
            Debug.Log("Cant find wrist flag TMP_Text.");
            Debug.Log(ex);
        }
    }

    /// <summary>
    /// 初始化手有无超出边缘的显示组件
    /// </summary>
    void InitializeFlagParts()
    {
        topFlag = flagHolderGizmo.transform.Find("Top").gameObject;
        rightFlag = flagHolderGizmo.transform.Find("Right").gameObject;
        leftFlag = flagHolderGizmo.transform.Find("Left").gameObject;
    }

    #endregion
}
