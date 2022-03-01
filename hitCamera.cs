using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitCamera : MonoBehaviour
{
    public GameObject ball;
    public GameObject firstBaseman;
    public GameObject secondBaseman;
    public GameObject thirdBaseman;
    public GameObject catcher;
    public string targetName = "ball";

    // Update is called once per frame
    void Update()
    {
        //Look at target everyframe
        if (string.Equals(targetName, "ball"))
        {
            transform.LookAt(ball.transform.position);
        }
        else if (string.Equals(targetName, "firstBaseman"))
        {
            transform.LookAt(firstBaseman.transform.position);
        }
        else if (string.Equals(targetName, "secondBaseman"))
        {
            transform.LookAt(secondBaseman.transform.position);
        }
        else if (string.Equals(targetName, "thirdBaseman"))
        {
            transform.LookAt(thirdBaseman.transform.position);
        }
        else if (string.Equals(targetName, "catcher"))
        {
            transform.LookAt(catcher.transform.position);
        }

        // Zoom in Camera 
        if (GetComponent<Camera>().fieldOfView > 15f)
        {
            GetComponent<Camera>().fieldOfView -= 0.1f;
        }
    }
}
