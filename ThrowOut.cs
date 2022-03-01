using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThrowOut : MonoBehaviour
{
    public GameObject managerGameObject;
    public GameObject firstBaseman;
    public GameObject secondBaseman;
    public GameObject thirdBaseman;
    public GameObject catcher;
    public GameObject runner1;
    public GameObject yankeeRunner1BenchMarker;
    public bool justGotRunnerOut = false;
    public AudioSource HeIsOutAudio;
    public AudioSource HeIsSafeAudio;
    public AudioSource CatchAudio;
    NavMeshAgent runner1Agent;

    void Start()
    {
        runner1Agent = runner1.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (justGotRunnerOut == false)
        {
            //Check if a fielder just caught the ball
            if ((firstBaseman.GetComponent<CatchBall>().justCaughtBall == true) || (secondBaseman.GetComponent<CatchBall>().justCaughtBall == true) || (thirdBaseman.GetComponent<CatchBall>().justCaughtBall == true) || (catcher.GetComponent<CatchBall>().justCaughtBall == true))
            {
                // Play catch ball sound
                CatchAudio.Play();
                //Check if runner1 is not at target base
                if (runner1.GetComponent<Runner>().atTargetBase == false)
                {
                    // Runner is not at base yet, and the fielder caught the ball. Runner is out.
                    // Add one out to the scoreboard
                    managerGameObject.GetComponent<Manager>().Outs += 1;
                    // Stop the runner from running by disabling his "Runner" component.
                    runner1.GetComponent<Runner>().enabled = false;
                    // Send Runner1 to his bench position.
                    runner1Agent.SetDestination(yankeeRunner1BenchMarker.transform.position);
                    // change "justGotRunnerOut to true for 5 seconds
                    StartCoroutine("justGotRunnerOutFunction");
                    // Announce that the runner is out
                    HeIsOutAudio.Play();
                }
                else
                {
                    // Announce that the runner is safe
                    HeIsSafeAudio.Play();
                }
            }
        }
    }

    IEnumerator justGotRunnerOutFunction()
    {
        justGotRunnerOut = true;
        yield return new WaitForSeconds(5);
        justGotRunnerOut = false;
    }
}
