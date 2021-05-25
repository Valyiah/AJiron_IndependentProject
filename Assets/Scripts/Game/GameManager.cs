using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] starShards;
    public GameObject player;
    private PlayerController playerScript;

    public GameObject winMenu;
    
    public bool win;

    public AudioSource levelMusic;
    public AudioSource loseMusic;
    public AudioSource winMusic;

    public bool levelSong = true;
    public bool loseSong = false;
    public bool winSong = false;

    private void Start()
    {
        playerScript = player.GetComponent<PlayerController>();
        Cursor.lockState = CursorLockMode.Locked;
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
            if (starShards[0] == null && starShards[1] == null && starShards[2] == null && starShards[3] == null && playerScript.triggerEntered == true)
            {
                winMenu.SetActive(true);
                WinMusic();
                Cursor.lockState = CursorLockMode.None;
                playerScript.walkSpeed = 0;
                playerScript.runSpeed = 0;
            }
        }

        if (playerScript.gameOver == true)
        {
            LoseMusic();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Astroduck");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Title Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelMusic()
    {
        levelSong = true;
        loseSong = false;
        winSong = false;
        levelMusic.Play();
    }

    public void LoseMusic()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if(!loseMusic.isPlaying && loseSong == false)
        {
            Cursor.lockState = CursorLockMode.None;
            loseMusic.Play();
            loseSong = true;
        }
    }

    public void WinMusic()
    {
        if (levelMusic.isPlaying)
            levelSong = false;
        {
            levelMusic.Stop();
        }
        if (!winMusic.isPlaying && winSong == false)
        {
            winMusic.Play();
            winSong = true;
        }
    }

    /* After trying to figure out how to process the array as one instead of 
    every element individually, I finally found out about &&.
    It would be nice to find a better way of writing this idea and something more efficient
    to not have the console get overloaded by all the messages but for now this works.*/
}
