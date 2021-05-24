using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] starShards;
    public GameObject player;
    private PlayerController playerScript;
    //public bool win;
    //public bool lose;

    private void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
    }

    //Update is called once per frame
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
            } //checks each array element individually

            if (starShards[0] == null && starShards[1] == null && starShards[2] == null && starShards[3] == null && playerScript.triggerEntered == true)
            {

                Debug.Log("You got all the Stars!");
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Astroduck");
    }

    /* After trying to figure out how to process the array as one instead of 
    every element individually, I finally found out about &&.
    It would be nice to find a better way of writing this idea and something more efficient
    to not have the console get overloaded by all the messages but for now this works.*/
}
