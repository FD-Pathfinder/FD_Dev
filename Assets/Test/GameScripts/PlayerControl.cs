using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public void YesInteracted()
    {
       
    }
    public void NoInteracted()
    {


    }
    /// <summary>
    /// ��������
    /// </summary>
    private int maxHealth=10; //��ɫ�������ֵ
    private int currentHealth;//��ɫ��ǰ����ֵ

    private int maxfigure; //��ɫ�������
    private int figure;//��ɫ��ǰ����


    /// <summary>
    /// ��������
    /// </summary>
    public float  Speed=5f;//�ٶ�
    private float structure; //�ṹ����
    private float Eye_range;//�Ӿ�
    private float maxCondition;//��û���״̬private float
    private float currentConditon;//��ǰ����״̬

    private float gravity;  //���� 
    private float mount;     //��ɫ��������
    private float maxStore; //��ɫ��󴢴�����
    private float currentStore;//��ɫ��ǰ��������

   

    Rigidbody rb;
    public Transform shuxing; //��ɫ���
        // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
       

    }

    // Update is called once per frame
    void Update()
    {
            
        shuxing.transform.position = Camera.main.WorldToScreenPoint(transform.position+Vector3.up*2);//��������ת��Ļ����
    }
}
