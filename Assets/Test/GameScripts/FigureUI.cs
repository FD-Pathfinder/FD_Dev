using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class FigureUI : MonoBehaviour
{
    public Slider slider;
    public Image _fill;
    public Transform _transform;    
    [SerializeField] private Vector3 offset;
    void Start()
    {
        slider = GetComponent<Slider>();
        _fill = GetComponent<Image>();      
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = PlayerControl.maxfigure;
        slider.value = PlayerControl.figure*0.5f;
        transform.position = _transform.position + offset;
    }
}
