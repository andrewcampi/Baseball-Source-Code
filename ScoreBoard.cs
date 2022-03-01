using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public GameObject ManagerGameObject;
    private float inning;
    public Text inningText;
    private int balls;
    public Text ballsText;
    private int strikes;
    public Text strikesText;
    private int outs;
    public Text outsText;
    private int yankeesRuns;
    public Text yankeesRunsText;
    private int redSoxRuns;
    public Text redSoxRunsText;

    // Update is called once per frame
    void Update()
    {
        //Update values
        inning = ManagerGameObject.GetComponent<Manager>().Inning;
        balls = ManagerGameObject.GetComponent<Manager>().Balls;
        strikes = ManagerGameObject.GetComponent<Manager>().Strikes;
        outs = ManagerGameObject.GetComponent<Manager>().Outs;
        yankeesRuns = ManagerGameObject.GetComponent<Manager>().YankeesRuns;
        redSoxRuns = ManagerGameObject.GetComponent<Manager>().RedSoxRuns;
        //Show updated values
        inningText.text = inning.ToString();
        ballsText.text = balls.ToString();
        strikesText.text = strikes.ToString();
        outsText.text = outs.ToString();
        yankeesRunsText.text = yankeesRuns.ToString();
        redSoxRunsText.text = redSoxRuns.ToString();
    }
}
