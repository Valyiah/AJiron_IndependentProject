using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 30.0f;

    private float edgeOfScene = -500.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (transform.position.z < edgeOfScene)
        {
            Destroy(gameObject);
            Debug.Log("Shooting Star Destroyed!");
        }
    }
}
