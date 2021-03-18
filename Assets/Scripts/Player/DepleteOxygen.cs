using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepleteOxygen : MonoBehaviour
{
    /*I used a script from a Unity forum and combined it with Brackeys
    Modified it for an oxygen meter and for a faster depletion and to pause the oxygen from 
    depleting further after 0, or from gaining more than 100 oxygen points
    Link to forum: https://answers.unity.com/questions/1381157/health-bar-goes-down-with-time.html
    Link to video: https://www.youtube.com/watch?v=BLfNP4Sc_iA */

    public float maxOxygen = 100f;
    public float curOxygen;

    public OxygenBar oxygenBar;
    //reference to access the OxygenBar script

    private void Start()
    {
        oxygenBar.SetMaxOxygen(maxOxygen);
        curOxygen = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        OxygenDeplete();

        if (curOxygen >= maxOxygen)
        {
            curOxygen = maxOxygen;
        }
        //to prevent the abuse of over collecting bubbles to go over the max oxygen level

        else if (curOxygen <= 0)
        {
            curOxygen = 0f;
        }
        //will keep the oxygen from going to the negatives to avoid issues with pickups if it is needed
    }

    void OxygenDeplete()
    {
        curOxygen -= Time.deltaTime;
        //will decrease the player oxygen by 1 every second
        oxygenBar.SetOxygen(curOxygen);
        //so the fill will follow the current oxygen level
    }
}
