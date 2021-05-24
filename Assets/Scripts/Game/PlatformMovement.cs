using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    //With help from youtuber Dogma427
    //Link: https://www.youtube.com/watch?v=Ig4Gsm1QwoU
    //Changed a few things to fit my game

    public float speed;
    public Transform startPoint, endPoint;
    public float changeDirectionDelay;

    private Transform destinationTarget, departTarget;
    private float startTime;
    private float journeyLength;

    bool isWaiting;

    void Start()
    {
        departTarget = startPoint;
        destinationTarget = endPoint;

        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
    }


    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!isWaiting)
        {
            if (Vector3.Distance(transform.position, destinationTarget.position) > 0.01f)
            {
                float distCovered = (Time.time - startTime) * speed;

                float fractionOfJourney = distCovered / journeyLength;

                transform.position = Vector3.Lerp(departTarget.position, destinationTarget.position, fractionOfJourney);
            }
            else
            {
                isWaiting = true;
                StartCoroutine(PlatformDelay());
            }
        }
    }

    void ChangeDestination()
    {

        if (departTarget == endPoint && destinationTarget == startPoint)
        {
            departTarget = startPoint;
            destinationTarget = endPoint;
        }
        else
        {
            departTarget = endPoint;
            destinationTarget = startPoint;
        }
        //Change direction to go back to the start point
    }

    IEnumerator PlatformDelay()
    {
        yield return new WaitForSeconds(changeDirectionDelay);
        ChangeDestination();
        startTime = Time.time;
        journeyLength = Vector3.Distance(departTarget.position, destinationTarget.position);
        isWaiting = false;
        //Delay for the platform
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        } // So the player can stay on the platform while it moves
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        } // Prevents the player from staying on the platform forever
    }
}
