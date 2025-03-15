using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController_Scene1 : MonoBehaviour
{
    private Slider slider;
    private float maxValue;
    private GameObject obj;
    private Image image;

    private float constt = 255f / 3;

    private void Start()
    {
        slider = GetComponent<Slider>();
        maxValue = 3f;
        slider.maxValue = maxValue;
        slider.value = 0;
        obj = transform.GetChild(2).GetChild(0).GetChild(1).gameObject;
        image = obj.GetComponent<Image>();
    }

    private void Update()
    {
        image.color = new Color();
    }
}
