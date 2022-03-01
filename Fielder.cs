using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fielder : MonoBehaviour
{
    NavMeshAgent myAgent;
    public Transform ball;
    public GameObject ballGameObject;
    public float startTrackingWithinRange = 30f;
    private float distanceBallandFielder;
    public string baseToThrowTo = "firstBase";
    public Transform FirstBase;
    public Transform SecondBase;
    public Transform ThirdBase;
    public Transform HomePlate;
    private float xDistanceToBase;
    private float zDistanceToBase;
    private float xyzDistanceToBase;

    void OnEnable()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Get distance between ball and player
        distanceBallandFielder = Vector3.Distance(ball.position, transform.position);
        // If Ball within tracking range...
        if (distanceBallandFielder < startTrackingWithinRange)
        {
            //Run to ball
            myAgent.SetDestination(ball.position);
            //If at ball ...
            if (distanceBallandFielder <= 2f)
            {
                //Move ball 1.5 y units up so that the fielder is not in the way
                ball.position += new Vector3(0f, 1.5f, 0f);
                //Remove any forces
                //Remove any initial forces
                ballGameObject.GetComponent<PitchBall>().rb.velocity = Vector3.zero;
                ballGameObject.GetComponent<PitchBall>().rb.angularVelocity = Vector3.zero;
                // Choose which base to throw the ball to
                // If throwing to "firstbase"...
                if (string.Equals(baseToThrowTo, "firstBase"))
                {
                    //Determine xyz distance to first base
                    xDistanceToBase = ball.position.x - FirstBase.position.x;
                    zDistanceToBase = ball.position.z - FirstBase.position.z;
                    // if far away ...
                    if (Mathf.Abs(xDistanceToBase) >= 50f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 3, 2f, -zDistanceToBase / 3, ForceMode.Impulse);
                    }
                    // if medium distance...
                    else if (Mathf.Abs(xDistanceToBase) > 25f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 2, 0.66f, -zDistanceToBase / 2, ForceMode.Impulse);
                    }
                    // if close ...
                    else
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase, 0f, -zDistanceToBase, ForceMode.Impulse);
                    }
                }
                else if (string.Equals(baseToThrowTo, "secondBase"))
                {
                    //Determine xyz distance to first base
                    xDistanceToBase = ball.position.x - SecondBase.position.x;
                    zDistanceToBase = ball.position.z - SecondBase.position.z;
                    // if far away ...
                    if (Mathf.Abs(xDistanceToBase) >= 50f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 3, 2f, -zDistanceToBase / 3, ForceMode.Impulse);
                    }
                    // if medium distance...
                    else if (Mathf.Abs(xDistanceToBase) > 25f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 2, 0.66f, -zDistanceToBase / 2, ForceMode.Impulse);
                    }
                    // if close ...
                    else
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase, 0f, -zDistanceToBase, ForceMode.Impulse);
                    }
                }
                else if (string.Equals(baseToThrowTo, "thirdBase"))
                {
                    //Determine xyz distance to first base
                    xDistanceToBase = ball.position.x - ThirdBase.position.x;
                    zDistanceToBase = ball.position.z - ThirdBase.position.z;
                    // if far away ...
                    if (Mathf.Abs(xDistanceToBase) >= 50f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 3, 2f, -zDistanceToBase / 3, ForceMode.Impulse);
                    }
                    // if medium distance...
                    else if (Mathf.Abs(xDistanceToBase) > 25f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 2, 0.66f, -zDistanceToBase / 2, ForceMode.Impulse);
                    }
                    // if close ...
                    else
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase, 0f, -zDistanceToBase, ForceMode.Impulse);
                    }
                }
                else if (string.Equals(baseToThrowTo, "homePlate"))
                {
                    //Determine xyz distance to first base
                    xDistanceToBase = ball.position.x - HomePlate.position.x;
                    zDistanceToBase = ball.position.z - HomePlate.position.z;
                    // if far away ...
                    if (Mathf.Abs(xDistanceToBase) >= 50f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 3, 2f, -zDistanceToBase / 3, ForceMode.Impulse);
                    }
                    // if medium distance...
                    else if (Mathf.Abs(xDistanceToBase) > 25f)
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase / 2, 0.66f, -zDistanceToBase / 2, ForceMode.Impulse);
                    }
                    // if close ...
                    else
                    {
                        ballGameObject.GetComponent<PitchBall>().rb.AddForce(-xDistanceToBase, 0f, -zDistanceToBase, ForceMode.Impulse);
                    }
                }
            }
        }
    }
}
