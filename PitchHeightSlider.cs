using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitchHeightSlider : MonoBehaviour
{
    public GameObject Ball;
    public GameObject BallTarget;
    public int SelectedPitch = 1;

    public void moveBallTarget(Scrollbar scrollbar)
    {
        // If the scrollbar is at its highest point (value 0) ...
        if (scrollbar.value == 0)
        {
            // Move the ball target to be a high strike
            BallTarget.transform.position = new Vector3(57.24f, 1.73f, -25);
            // Current pitch is "StrikeHigh"
            SelectedPitch = 1;
        }
        // If the scrollbar is at its second highest point (value 0.3333333) ...
        else if (scrollbar.value > 0.32 && scrollbar.value < 0.4)
        { 
            // Move the ball target to be a middle strike
            BallTarget.transform.position = new Vector3(57.24f, 1.5f, -25);
            // Current pitch is "StrikeMiddle"
            SelectedPitch = 2;
        }
        // If the scrollbar value is at its second lowest point (value 0.6666667) ...
        else if (scrollbar.value > 0.65 && scrollbar.value < 0.7)
        {
            // Move the ball target to be a low strike
            BallTarget.transform.position = new Vector3(57.24f, 1.14f, -25);
            // Current pitch is "StrikeLow"
            SelectedPitch = 3;
        }
        // If the scrollbar value is at its lowest point (value 1) ...
        else if (scrollbar.value == 1)
        {
            // Move the ball target to be a low ball
            BallTarget.transform.position = new Vector3(57.24f, 0.8f, -25);
            // Current pitch is "StrikeLow"
            SelectedPitch = 4;
        }
    }
}
