using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runner : MonoBehaviour
{
    NavMeshAgent myAgent;
    public GameObject firstBase;
    public GameObject secondBase;
    public GameObject thirdBase;
    public GameObject homePlate;
    public string baseToRunTo = "firstBase";
    public bool atTargetBase = false;
    public string currentBase = "homePlate";

    void OnEnable()
    {
        myAgent = GetComponent<NavMeshAgent>();
        atTargetBase = false;
        //If running to first, then runner is currently on bench...
        if (string.Equals(baseToRunTo, "firstBase"))
        {
            //Move transform from bench to homePlate
            transform.position = new Vector3(homePlate.transform.position.x, 2, homePlate.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (string.Equals(baseToRunTo, "firstBase"))
        {
            myAgent.SetDestination(firstBase.transform.position);
            if (Vector3.Distance(transform.position, firstBase.transform.position) < 2f)
            {
                atTargetBase = true;
                currentBase = "firstBase";
            }
            else
            {
                atTargetBase = false;
            }
        }
        else if (string.Equals(baseToRunTo, "secondBase"))
        {
            myAgent.SetDestination(secondBase.transform.position);
            if (Vector3.Distance(transform.position, secondBase.transform.position) < 2f)
            {
                atTargetBase = true;
                currentBase = "secondBase";
            }
            else
            {
                atTargetBase = false;
            }
        }
        else if (string.Equals(baseToRunTo, "thirdBase"))
        {
            myAgent.SetDestination(thirdBase.transform.position);
            if (Vector3.Distance(transform.position, thirdBase.transform.position) < 2f)
            {
                atTargetBase = true;
                currentBase = "thirdBase";
            }
            else
            {
                atTargetBase = false;
            }
        }
        else if (string.Equals(baseToRunTo, "homePlate"))
        {
            myAgent.SetDestination(homePlate.transform.position);
            if (Vector3.Distance(transform.position, homePlate.transform.position) < 2f)
            {
                atTargetBase = true;
                currentBase = "homePlate";
            }
            else
            {
                atTargetBase = false;
            }
        }
    }
}
