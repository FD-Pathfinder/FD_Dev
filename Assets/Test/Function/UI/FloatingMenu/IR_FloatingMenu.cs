using System;
using UnityEngine;


//�ܽ��ܣ������Ḻ������һ������С�˵�������Ҫ֪����С�˵��м�����ť��С�˵��ϵİ�ť������,
//��Щ���ݻᱻ�����һ���ṹ�崫�ݸ���

#region ����������ܻ��õ���ö�ٺͽṹ��
[Tooltip("ÿһ��Ԫ�ؾʹ�����Ϸ��һ�������˵�")]
public enum FloatMenuType
{
    FloatMenu_Creeper=0,
    FloatMenu_Aegis=1,
    FloatMenu_Reform=2,
    FloatMenu_Monv=3
}

[Tooltip("����һ�������˵�")]
[System.Serializable]
public struct FloatMenuBunker
{
    public string name;
    [Tooltip("�����˵�������")]
    public FloatMenuType MenuType;
    [Tooltip("���ǰ�ť������������1����������"), Range(1, 5)]
    public int HowManyButtonIhave;
    [Tooltip("���ǰ�ť��ͼ�꣬�������ϸ�֤�Ͱ�ť����һ��")]
    public Sprite[] IconImage;
    [Tooltip("���ǰ�ť�ı����壬�������ϸ�֤�Ͱ�ť����һ��")]
    public Sprite[] ButtonImage;

}

#endregion

public class IR_FloatingMenu :  MonoBehaviour
{
    #region ��ť�¼�������������������ղ�������Ӧ
    public static event Action Button1;
    public static event Action Button2;
    public static event Action Button3;
    public static event Action Button4;
    public static event Action Button5;
    #endregion


    //������ťҪ�õ���ͼ
    private FloatMenuBunker Bunker;

    //����Ԥ�Ƽ�
    [SerializeField]
    private GameObject TheButtonMatrix;

    private IR_MenuButton[] ButtonArray;

    private Vector3[] ButtonPosition;

    //�㲥ֵ�����������㲥ɶ��ť�¼���0�Ͳ��㲥

    private int ButtonBePress=0;
    
    private void Update()
    {
        LookAtCamera();
    }

    #region �����߼�����
    /// <summary>
    /// �ò˵����������
    /// </summary>
    public void LookAtCamera()
    {
        this.gameObject.transform.LookAt(Camera.main.transform);
    }
    /// <summary>
    /// ����ṹ�壬���ݽṹ������һ���˵�
    /// </summary>
    /// <param name="inputBunker">����ṹ����UI������</param>
    public void SetupMenu(FloatMenuBunker inputBunker) 
    {
        //����֮ǰ�Ȱѿ����еİ�ťȫɾ��
        DestoryFloatMenu();
        Bunker = inputBunker;
        //���ⲿ���վ�����Ͱ�ť����
        Init_FloatMenu();
    }
    /// <summary>
    /// �������а���,��UI������,���û�����һ��ѡ���Ҳ�����
    /// </summary>
    public void DestoryFloatMenu()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject.Destroy(this.gameObject.transform.GetChild(i).gameObject);
        }
    }
    /// <summary>
    /// ���˵���ť״��������ť����ʱ�͹㲥�¼������ٲ˵�
    /// </summary>
    public void DeteButtonPress()
    {
        ButtonBePress = RecvButtonPress();
        switch (ButtonBePress)
        {
            case 0:break;
            case 1: Button1?.Invoke(); DestoryFloatMenu(); break;
            case 2: Button2?.Invoke(); DestoryFloatMenu(); break;
            case 3: Button3?.Invoke(); DestoryFloatMenu(); break;
            case 4: Button4?.Invoke(); DestoryFloatMenu(); break;
            case 5: Button5?.Invoke(); DestoryFloatMenu(); break;
            default:break;
        }

    }
    #endregion
   
    #region �ͼ�����
    /// <summary>
    /// ��ʼ����ť
    /// </summary>
    private void Init_FloatMenu()
    {
        //��ʼ����ť����
        ButtonArray = new IR_MenuButton[Bunker.HowManyButtonIhave];
        //��ʼ����ťλ��
        ButtonPosition = Init_ButtonPosition(Bunker.HowManyButtonIhave);
        for (int ButtonID = 0; ButtonID < Bunker.HowManyButtonIhave; ButtonID++)
        {
            ButtonArray[ButtonID] = Instantiate(TheButtonMatrix,this.gameObject.transform ).GetComponent<IR_MenuButton>();
            ButtonArray[ButtonID].SetUpButton(Bunker.IconImage[ButtonID], Bunker.ButtonImage[ButtonID], ButtonID, ButtonPosition[ButtonID]);
        }
    }



    /// <summary>
    /// ���ݰ�ť��������λ��ƫ����
    /// </summary>
    /// <param name="ButtonCount"></param>
    /// <returns></returns>
    private Vector3[] Init_ButtonPosition(int ButtonCount)
    {
        Vector3[] ButtonPosition= new Vector3[ButtonCount];
        switch (ButtonCount)
        {
            case 1: 
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up*15;
                return ButtonPosition;
            case 2: 
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 9;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 9;
                return ButtonPosition;

            case 3:
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 9;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15;
                ButtonPosition[2] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 9;
                return ButtonPosition;

            case 4:
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 12;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15 + Vector3.right * 5;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15 + Vector3.left * 5;
                ButtonPosition[2] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 12;
                return ButtonPosition;

            case 5:
                ButtonPosition[0] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.right * 12;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15+ Vector3.right * 5;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15;
                ButtonPosition[1] = this.gameObject.transform.localPosition + Vector3.up * 15 + Vector3.left * 5;
                ButtonPosition[2] = this.gameObject.transform.localPosition + Vector3.up * 9 + Vector3.left * 12;
                return ButtonPosition;
            default:return null;

        }
    }



   /// <summary>
   /// ������ް�ť�����£����ذ�ť��������������һ��
   /// </summary>
   /// <returns>��ť��������һ�������0����û�а�ť������</returns>
    private int RecvButtonPress()
    {
        for (int ButtonID = 0; ButtonID < ButtonArray.Length; ButtonID++)
        {
            if (ButtonArray[ButtonID].Ipress)
            {
                return ButtonID + 1;
            }
        }
        return 0;
    }
    #endregion

}
