using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingSpaceBar : MonoBehaviour
{
    public int resetBatAfterSeconds = 1;
    public GameObject Bat;


    public void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Bat.GetComponent<SwingBat>().swung = true;
            StartCoroutine(resetBat(Bat));
        }
    }


    IEnumerator resetBat(GameObject Bat)
    {
        yield return new WaitForSeconds(resetBatAfterSeconds);
        Bat.GetComponent<SwingBat>().resetSwing();
    }
}
