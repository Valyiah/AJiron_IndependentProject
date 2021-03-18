using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShards : MonoBehaviour
{
    public GameObject[] starShards;

    // Update is called once per frame
    void Update()
    {
        CheckArray();
    }

    void CheckArray()
    {
        for (int i = 0; i < starShards.Length; i++)
        {
            if (starShards[i] == null)
            {
                Debug.Log("Empty!: " + i);
            }
            else if (starShards[i] != null)
            {
                Debug.Log("Not Empty: " + i);
            }
            // checks each array element individually

            if (starShards[0] == null && starShards[1] == null && starShards[2] == null && starShards[3] == null)
            {
                Debug.Log("You got all the Stars!");
            }
        }
    }

    /* After trying to figure out how to process the array as one instead of 
    every element individually, I finally found out about &&.
    It would be nice to find a better way of writing this idea and something more efficient
    to not have the console get overloaded by all the messages but for now this works.*/
}
