using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStars : MonoBehaviour
{
    public GameObject[] shootingStar;
    private float xPosRange = 50;
    private float yPosRange = 30;
    private float zPosRange = 100;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShootingStar", 10.0f, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnShootingStar()
    {
        float randXPos = Random.Range(-xPosRange, xPosRange);
        int shootingStarIndex = Random.Range(0, shootingStar.Length);
        Vector3 randPos = new Vector3(randXPos, yPosRange, zPosRange);
        Instantiate(shootingStar[shootingStarIndex], randPos,
            shootingStar[shootingStarIndex].transform.rotation);
    }
}
