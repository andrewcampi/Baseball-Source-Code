using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeRunDetect : MonoBehaviour
{
    public bool justHitHomeRun = false;
    public GameObject homeRunDetectManager;


    void OnCollisionEnter(Collision col)
    {
        justHitHomeRun = true;
        homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun = true;
    }

    IEnumerator justHitHomeRunFunction()
    {
        justHitHomeRun = true;
        homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun = true;
        yield return new WaitForSeconds(8);
        justHitHomeRun = false;
        homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun = true;
    }
}
