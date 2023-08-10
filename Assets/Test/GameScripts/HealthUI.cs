using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Transform target;
    public Gradient gradient;
    [SerializeField] public Vector3 offset;
     void Start()
    {
        slider = GetComponent<Slider>();
        fill = GetComponent<Image>();
        fill.color = gradient.Evaluate(1f);
    }
    void Update()
    {
        slider.maxValue = PlayerControl.maxHealth;
        slider.value = PlayerControl.currentHealth;        
        transform.position = target.position+offset;
        slider.GetComponentInChildren<Image>(fill).color = gradient.Evaluate(slider.normalizedValue);
    }  
}
