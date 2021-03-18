using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    // Used Brackeys video to help setup my oxygen UI with modifications
    // Link: https://www.youtube.com/watch?v=BLfNP4Sc_iA

    public Slider slider;
    // Reference the slider component to access the value for my oxygen level

    public Gradient gradient;
    public Image fill;
    //internal functions in Unity that can be used to access the components on the Oxygen Bar UI

    public void SetMaxOxygen(float oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
        //references the max value and value components on the slider

        fill.color = gradient.Evaluate(1f);
        //To have the image change color based off the gradient using the evaluate function, to start at blue
    }

    public void SetOxygen(float oxygen)
    {
        slider.value = oxygen;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        //Updates the bar color
    }
}
