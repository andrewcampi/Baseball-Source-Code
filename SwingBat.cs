using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingBat : MonoBehaviour
{
    public GameObject ball;
    public GameObject rotateAroundObject;
    public int swingSpeed = 1100;
    public float swingStopAngle = -0.05f;
    public float swingPower = 3000f;
    public GameObject mainCamera;
    public GameObject hitCamera;
    public bool justMadeContact = false;
    public bool justSwung = false;
    [HideInInspector] public bool swung = false;
    Vector3 originalPosition;
    Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (swung)
        {
            justSwung = true;
            // Spin bat until it reaches -60 y rotation
            if (transform.rotation.y > swingStopAngle)
            {
                // Spin the object around the target at 20 degrees/second
                transform.RotateAround(rotateAroundObject.transform.position, Vector3.down, swingSpeed * Time.deltaTime);
            }
            else
            {
                StartCoroutine("justSwungFunction");
                swung = false;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // If bat collides with ball...
        if (col.gameObject.tag == "Ball")
        {
            justMadeContact = true;
            // 1000f for smallest hit, 4000f for homerun
            swingPower = changeSwingPower();
            var force = transform.position - ball.transform.position;
            force.Normalize();
            ball.GetComponent<Rigidbody>().AddForce(-force * swingPower);
            //Add random ball side force (to go different directions in the field)
            addSideForce();
            //Change Cameras then change them back
            StartCoroutine("changeCameras");
        }
    }

    IEnumerator justSwungFunction()
    {
        yield return new WaitForSeconds(2);
        justSwung = false;
    }

    IEnumerator changeValuesJustSwung()
    {
        justSwung = true;
        yield return new WaitForSeconds(2f);
        justSwung = false;
    }

    IEnumerator justMadeContactFunction()
    {
        //If this function is called, set "justMadeContact" to true for 2 seconds, then switch back to false
        justMadeContact = true;
        yield return new WaitForSecondsRealtime(2);
        justMadeContact = false;
    }

    public void resetSwing()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
        //Match current y position of "rotateAroundObject"
        transform.position = new Vector3(transform.position.x, rotateAroundObject.transform.position.y, transform.position.z);
    }

    IEnumerator changeCameras()
    {
        mainCamera.SetActive(false);
        hitCamera.SetActive(true);
        hitCamera.GetComponent<Camera>().fieldOfView = 60f;
        yield return new WaitForSeconds(1);
    }

    public void addSideForce()
    {
        // Create a list of possible side forces. This will make the ball go left, straight, or right. 
        List<float> choices = new List<float>();
        choices.Add(-3000f);
        choices.Add(-2500f);
        choices.Add(-2000f);
        choices.Add(-1500f);
        choices.Add(-1000f);
        choices.Add(-500f);
        choices.Add(0f);
        choices.Add(500f);
        choices.Add(1000f);
        //Make a random choice for a side force, then apply it
        int choice = Random.Range(0, choices.Count);
        ball.GetComponent<Rigidbody>().AddForce(choices[choice], 0, 0);
    }

    public float changeSwingPower()
    {
        // Create a list of possible swing powers. This will make the ball go shorter or further.
        // 1000f for small hit, 3500f for homerun
        List<float> choices = new List<float>();
        //Add more small hits in list to lower probability of homerun
        choices.Add(1000f);
        choices.Add(1250f);
        choices.Add(1500f);
        choices.Add(2000f);
        choices.Add(2500f);
        choices.Add(3000f);
        choices.Add(3000f);
        choices.Add(3500f);
        //Make a random choice for a bat power, then return it
        int choice = Random.Range(0, choices.Count);
        return choices[choice];
    }
}
