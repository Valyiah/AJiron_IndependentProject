using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePickup : MonoBehaviour
{
    //With some help from a youtuber named Thinkbot Labs but modified to fit my project
    //Link to video: https://www.youtube.com/watch?v=TQhzBAKaOTE

    DepleteOxygen depleteOxygen;

    public float bubbleBonus = 40f;
    //Oxgyen bubbles will restore 50 points

    private void Awake()
    {
        depleteOxygen = FindObjectOfType<DepleteOxygen>();
        //finds the script to avoid making it public
    }

    void OnTriggerEnter(Collider other)
    {
        if(depleteOxygen.curOxygen < depleteOxygen.maxOxygen)
        {
            Destroy(gameObject);
            depleteOxygen.curOxygen = depleteOxygen.curOxygen + bubbleBonus;
            //adds the bubble bonus of 40 points to the current oxygen level
        }
    }
}
