using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    /// <summary>
    /// ��������
    /// </summary>
    static public int maxHealth=10, currentHealth;

    static public int maxfigure=4, figure; 
   

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
    public HealthUI health;
       
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<HealthUI>();
        currentHealth = maxHealth;
        figure = maxfigure;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            currentHealth--;
        }

    }    
}
