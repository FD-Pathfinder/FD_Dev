using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    /// <summary>
    /// 基础属性
    /// </summary>
    static public int maxHealth=10, currentHealth;

    static public int maxfigure=4, figure; 
   

    /// <summary>
    /// 机体属性
    /// </summary>
    public float  Speed=5f;//速度
    private float structure; //结构精度
    private float Eye_range;//视距
    private float maxCondition;//最好机体状态private float
    private float currentConditon;//当前机体状态

    private float gravity;  //重力 
    private float mount;     //角色挂载能力
    private float maxStore; //角色最大储存能力
    private float currentStore;//角色当前储存能力

   

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
