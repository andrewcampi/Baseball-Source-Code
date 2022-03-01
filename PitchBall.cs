using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchBall : MonoBehaviour
{
    public float thrustx = 1.0f;
    public float thrusty = 1.0f;
    public float thrustz = 1.0f;
    public Rigidbody rb;
    Vector3 originalPosition;
    Vector3 originalPositionBallTarget;
    public Transform ballTarget;

    void Start()
    {
        //Get original position
        originalPosition = transform.position;
        originalPositionBallTarget = ballTarget.position;
        //StartCoroutine("pitchAfterTime");
    }

    IEnumerator pitchAfterTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            selectRandomPitch();
        }
        
    }

    public void pitch(string pitchName)
    {
        if (string.Equals(pitchName, "StrikeHigh"))
        {
            StartCoroutine("pitchStrikeHigh");
        }
        else if (string.Equals(pitchName, "StrikeMiddle"))
        {
            StartCoroutine("pitchStrikeMiddle");
        }
        else if (string.Equals(pitchName, "StrikeLow"))
        {
            StartCoroutine("pitchStrikeLow");
        }
        else if (string.Equals(pitchName, "BallLow"))
        {
            StartCoroutine("pitchBallLow");
        }
    }

    public string selectRandomPitch()
    {
        int choice = Random.Range(1, 9);
        if (choice == 1)
        {
            StartCoroutine("pitchStrikeLow");
            return "StrikeLow";
        }
        else if (choice == 2)
        {
            StartCoroutine("pitchStrikeHigh");
            return "StrikeHigh";
        }
        else if (choice == 3)
        {
            StartCoroutine("pitchStrikeMiddle");
            return "StrikeMiddle";
        }
        else if (choice == 4)
        {
            StartCoroutine("pitchBallHigh");
            return "BallHigh";
        }
        else if (choice == 5)
        {
            StartCoroutine("pitchBallLow");
            return "BallLow";
        }
        else if (choice == 6)
        {
            StartCoroutine("pitchBallOutside");
            return "BallOutside";
        }
        else if (choice == 7)
        {
            StartCoroutine("pitchStrikeLow");
            return "StrikeLow";
        }
        else if (choice == 8)
        {
            StartCoroutine("pitchStrikeMiddle");
            return "StrikeMiddle";
        }
        else if (choice == 9)
        {
            StartCoroutine("pitchStrikeHigh");
            return "StrikeHigh";
        }
        return "error";
    }

    public IEnumerator pitchStrikeLow()
    {
        // set ballTarget to original position
        ballTarget.position = originalPositionBallTarget;
        // move ballTarget position to (57.25, 1.15, -25)
        ballTarget.position = new Vector3(57.25f, 1.15f, -25f);
        // Wait 2 seconds to allow player to move slider to ball
        yield return new WaitForSeconds(2);
        //Move ball to original position
        transform.position = originalPosition;
        //Remove any initial forces
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // set z thrust
        thrustx = 1f;
        // set y thrust
        thrusty = 5.6f;
        // set x thrust
        thrustz = -20f;
        // Apply forces
        rb.AddForce(thrustx, thrusty, thrustz, ForceMode.Impulse);

    }

    public IEnumerator pitchStrikeHigh()
    {
        // set ballTarget to original position
        ballTarget.position = originalPositionBallTarget;
        // move ballTarget position to (57.25, 1.75, -25)
        ballTarget.position = new Vector3(57.25f, 1.75f, -25f);
        // Wait 2 seconds to allow player to move slider to ball
        yield return new WaitForSeconds(2);
        //Move ball to original position
        transform.position = originalPosition;
        //Remove any initial forces
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // set z thrust
        thrustx = 1f;
        // set y thrust
        thrusty = 6.1f;
        // set x thrust
        thrustz = -20f;
        // Apply forces
        rb.AddForce(thrustx, thrusty, thrustz, ForceMode.Impulse);
    }

    public IEnumerator pitchStrikeMiddle()
    {
        // set ballTarget to original position
        // ballTarget original position is in the middle of the strike zone
        ballTarget.position = originalPositionBallTarget;
        // move ballTarget position to (57.25, 1.5, -25)
        ballTarget.position = new Vector3(57.25f, 1.5f, -25f);
        // Wait 2 seconds to allow player to move slider to ball
        yield return new WaitForSeconds(2);
        //Move ball to original position
        transform.position = originalPosition;
        //Remove any initial forces
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // set z thrust
        thrustx = 1f;
        // set y thrust
        thrusty = 5.9f;
        // set x thrust
        thrustz = -20f;
        // Apply forces
        rb.AddForce(thrustx, thrusty, thrustz, ForceMode.Impulse);
    }

    public IEnumerator pitchBallHigh()
    {
        // set ballTarget to original position
        ballTarget.position = originalPositionBallTarget;
        // move ballTarget position to (57.25, 2, -25)
        ballTarget.position = new Vector3(57.25f, 2f, -25f);
        // Wait 2 seconds to allow player to move slider to ball
        yield return new WaitForSeconds(2);
        //Move ball to original position
        transform.position = originalPosition;
        //Remove any initial forces
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // set z thrust
        thrustx = 1f;
        // set y thrust
        thrusty = 6.4f;
        // set x thrust
        thrustz = -20f;
        // Apply forces
        rb.AddForce(thrustx, thrusty, thrustz, ForceMode.Impulse);
    }

    public IEnumerator pitchBallLow()
    {
        // set ballTarget to original position
        ballTarget.position = originalPositionBallTarget;
        // move ballTarget position to (57.25, 0.85, -25)
        ballTarget.position = new Vector3(57.25f, 0.85f, -25f);
        // Wait 2 seconds to allow player to move slider to ball
        yield return new WaitForSeconds(2);
        //Move ball to original position
        transform.position = originalPosition;
        //Remove any initial forces
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // set z thrust
        thrustx = 1f;
        // set y thrust
        thrusty = 5.4f;
        // set x thrust
        thrustz = -20f;
        // Apply forces
        rb.AddForce(thrustx, thrusty, thrustz, ForceMode.Impulse);
    }

    public IEnumerator pitchBallOutside()
    {
        // set ballTarget to original position
        ballTarget.position = originalPositionBallTarget;
        // move ballTarget position to (58, 1.5, -25)
        ballTarget.position = new Vector3(58f, 1.5f, -25f);
        // Wait 2 seconds to allow player to move slider to ball
        yield return new WaitForSeconds(2);
        //Move ball to original position
        transform.position = originalPosition;
        //Remove any initial forces
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        // set z thrust
        thrustx = 1.75f;
        // set y thrust
        thrusty = 6f;
        // set x thrust
        thrustz = -20f;
        // Apply forces
        rb.AddForce(thrustx, thrusty, thrustz, ForceMode.Impulse);
    }
}
