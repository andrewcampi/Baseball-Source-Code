using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchBall : MonoBehaviour
{
    public string positionName;
    public GameObject ball;
    public GameObject hitCameraGameObject;
    public bool justCaughtBall = false;
    public float distanceToBall = 10000f;
    public Vector3 ballOriginalPosition;

    void Start()
    {
        ballOriginalPosition = ball.transform.position;
    }

    public IEnumerator changeValueJustCaughtBall()
    {
        // Set "justCaughtBall" to true. Then in 2 seconds, set back to false.
        justCaughtBall = true;
        yield return new WaitForSeconds(2);
        justCaughtBall = false;
    }

    void Update()
    {
        // Get current distance between the ball and self
        distanceToBall = Vector3.Distance(ball.transform.position, transform.position);
        // If distanceToBall is less than 3.5, then self caught the ball
        if (distanceToBall <= 3.5f)
        {
            StartCoroutine("changeValueJustCaughtBall");
            distanceToBall = 10000f;
            hitCameraGameObject.GetComponent<hitCamera>().targetName = positionName;
            ball.transform.position = new Vector3(56f, 1f, 148f);
            ball.SetActive(false);
            hitCameraGameObject.GetComponent<hitCamera>().targetName = positionName;
        }
    }
}
