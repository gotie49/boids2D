using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public TMP_Text boostText;
    public Slider slider;

    private void Awake()
    {
        boostText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        boostText.text = Mathf.RoundToInt(slider.value).ToString();
        //Debug.Log(slider.value);
    }
}
