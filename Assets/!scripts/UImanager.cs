using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField] private Slider sliderLeft;
    [SerializeField] private Slider sliderRight;

    [SerializeField] private Image sliderLeftImage;
    [SerializeField] private Image sliderRightImage;
    [SerializeField] private TextMeshProUGUI score;
    private float scoreVal = 0;



    private void Start()
    {
        sliderLeft.direction = Slider.Direction.RightToLeft;
        sliderRight.direction = Slider.Direction.LeftToRight;
    }

    public void ChangeBarValue(float i)
    {
        sliderLeft.value = i;
        sliderRight.value = i;
        Color color = new Color32((byte) (255*i), (byte) (150-150*i), Byte.MinValue, Byte.MaxValue);
        sliderLeftImage.color = color;
        sliderRightImage.color = color;
    }

    public void UpdateScore(float i)
    {
        scoreVal += i;
        score.text = Mathf.FloorToInt(scoreVal).ToString();
    }
}
