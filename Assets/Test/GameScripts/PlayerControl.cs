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
    /// 基础属性
    /// </summary>
    private int maxHealth=10; //角色最大生命值
    private int currentHealth;//角色当前生命值

    private int maxfigure; //角色最大算力
    private int figure;//角色当前算力


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
    public Transform shuxing; //角色面板
        // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
       

    }

    // Update is called once per frame
    void Update()
    {
            
        shuxing.transform.position = Camera.main.WorldToScreenPoint(transform.position+Vector3.up*2);//世界坐标转屏幕坐标
    }
}
