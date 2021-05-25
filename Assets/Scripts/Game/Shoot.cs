using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 30.0f;

    private float edgeOfScene = -500.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        if (transform.position.z < edgeOfScene)
        {
            Destroy(gameObject);
        }
    }
}
