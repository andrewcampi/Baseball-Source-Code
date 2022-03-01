using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingButton : MonoBehaviour
{
    public int resetBatAfterSeconds = 2;
    public void takeASwing(GameObject Bat)
    {

        Bat.GetComponent<SwingBat>().swung = true;
        StartCoroutine(resetBat(Bat));
    }


    IEnumerator resetBat(GameObject Bat)
    {
        yield return new WaitForSeconds(resetBatAfterSeconds);
        Bat.GetComponent<SwingBat>().resetSwing();
    }

}
