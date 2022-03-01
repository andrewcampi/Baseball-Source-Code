using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatHeightSlider : MonoBehaviour
{
    public GameObject Bat;
    public GameObject BatProjection;
    public GameObject BatRotateAroundPoint;

    public void moveBat(Scrollbar scrollbar)
    {
        Bat.transform.position = new Vector3(56, -scrollbar.value + 2, -26);
        BatProjection.transform.position = new Vector3(57, -scrollbar.value + 2, -25);
        BatRotateAroundPoint.transform.position = new Vector3(56, -scrollbar.value + 2, -25);
    }

    public void moveBatManually(float height)
    {
        Bat.transform.position = new Vector3(56, -height + 2, -26);
        BatProjection.transform.position = new Vector3(57, -height + 2, -25);
        BatRotateAroundPoint.transform.position = new Vector3(56, -height + 2, -25);
    }
}
