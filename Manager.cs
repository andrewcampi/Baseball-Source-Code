using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Manager : MonoBehaviour
{
    // Get GameObjects and Buttons from scene
    public GameObject SwingManager;
    public GameObject BatHeightManager;
    public GameObject mainCamera;
    public GameObject hitCameraGameObject;
    public GameObject inningChangeCamera;
    public GameObject walkCamera;
    public GameObject Bat;
    public GameObject BatTarget;
    public GameObject BatRotateAround;
    public GameObject Ball;
    public GameObject BallTarget;
    public GameObject LeftFielder;
    public GameObject CenterFielder;
    public GameObject RightFielder;
    public GameObject ThirdBaseman;
    public GameObject Shortstop;
    public GameObject SecondBaseman;
    public GameObject FirstBaseman;
    public GameObject Pitcher;
    public GameObject Catcher;
    public GameObject Hitter;
    public GameObject Runner1;
    public GameObject Runner2;
    public GameObject Runner3;
    public GameObject Runner4;
    public GameObject FirstBase;
    public GameObject SecondBase;
    public GameObject ThirdBase;
    public GameObject HomePlate;
    public GameObject PitchersMound;
    public Button nextPitchButton;
    public GameObject nextPitchButtonGameObject;
    public GameObject BatScrollBarGameObject;
    public Button throwButton;
    public GameObject throwButtonGameObject;
    public GameObject PitchScrollBarGameObject;
    public GameObject LeftFielderPositionMarker;
    public GameObject CenterFielderPositionMarker;
    public GameObject RightFielderPositionMarker;
    public GameObject ThirdBasemanPositionMarker;
    public GameObject ShortstopPositionMarker;
    public GameObject SecondBasemanPositionMarker;
    public GameObject FirstBasemanPositionMarker;
    public GameObject PitcherPositionMarker;
    public GameObject CatcherPositionMarker;
    public GameObject BatterPositionMarker;
    public GameObject YankeeBatterBenchMarker;
    public GameObject YankeeRunner1BenchMarker;
    public GameObject YankeeRunner2BenchMarker;
    public GameObject YankeeRunner3BenchMarker;
    public GameObject YankeeRunner4BenchMarker;
    public GameObject YankeeLeftFielderBenchMarker;
    public GameObject YankeeCenterFielderBenchMarker;
    public GameObject YankeeRightFielderBenchMarker;
    public GameObject YankeeThirdBasemanBenchMarker;
    public GameObject YankeeShortstopBenchMarker;
    public GameObject YankeeSecondBasemanBenchMarker;
    public GameObject YankeeFirstBasemanBenchMarker;
    public GameObject YankeePitcherBenchMarker;
    public GameObject YankeeCatcherBenchMarker;
    public GameObject RedSoxBatterBenchMarker;
    public GameObject RedSoxRunner1BenchMarker;
    public GameObject RedSoxRunner2BenchMarker;
    public GameObject RedSoxRunner3BenchMarker;
    public GameObject RedSoxRunner4BenchMarker;
    public GameObject RedSoxLeftFielderBenchMarker;
    public GameObject RedSoxCenterFielderBenchMarker;
    public GameObject RedSoxRightFielderBenchMarker;
    public GameObject RedSoxThirdBasemanBenchMarker;
    public GameObject RedSoxShortstopBenchMarker;
    public GameObject RedSoxSecondBasemanBenchMarker;
    public GameObject RedSoxFirstBasemanBenchMarker;
    public GameObject RedSoxPitcherBenchMarker;
    public GameObject RedSoxCatcherBenchMarker;
    public GameObject homeRunDetectManager;
    public AudioSource CheerAudio;
    public AudioSource PitchBaseballAudio;
    public AudioSource WoodBatHitBallAudio;
    public AudioSource BasesLoadedHereAudio;
    public AudioSource HeIsOutAudio;
    public AudioSource HeIsSafeAudio;
    public AudioSource HomeRunAudio;
    public AudioSource ManOnFirstAudio;
    public AudioSource MenOnFirstAndSecondAudio;
    public AudioSource NoOneOnAudio;
    public AudioSource NoOutsAudio;
    public AudioSource OneOutAudio;
    public AudioSource ShortHitBallAudio;
    public AudioSource ThatIsAHardHitBallAudio;
    public AudioSource ThatIsAWalkAudio;
    public AudioSource ThreeOutsAudio;
    public AudioSource TwoOutsAudio;
    public AudioSource CatchAudio;
    public AudioSource RunScoredAudio;
    public AudioSource BallOneAudio;
    public AudioSource BallTwoAudio;
    public AudioSource BallThreeAudio;
    public AudioSource BallFourAudio;
    public AudioSource StrikeOneAudio;
    public AudioSource StrikeTwoAudio;
    public AudioSource StrikeThreeAudio;
    public AudioSource HelloAndWelcomeAudio;
    public AudioSource YankeesWinAudio;
    public AudioSource RedSoxWinAudio;
    public AudioSource ChargeOrganAudio;
    // Set some important variables to starting values
    public bool SinglePlayerMode = false;
    public int YankeesRuns = 0;
    public int RedSoxRuns = 0;
    public int Balls = 0;
    public int Strikes = 0;
    public int Outs = 0;
    public float Inning = 1f;
    public bool PlayerIsBatting = true;
    public bool manOnFirst = false;
    public bool manOnSecond = false;
    public bool manOnThird = false;
    public bool manAtHome = false;
    public bool YankeesAreBatting = true;
    // Create navMeshAgents
    NavMeshAgent LeftFielderAgent;
    NavMeshAgent CenterFielderAgent;
    NavMeshAgent RightFielderAgent;
    NavMeshAgent ThirdBasemanAgent;
    NavMeshAgent ShortstopAgent;
    NavMeshAgent SecondBasemanAgent;
    NavMeshAgent FirstBasemanAgent;
    NavMeshAgent PitcherAgent;
    NavMeshAgent CatcherAgent;
    NavMeshAgent Runner1Agent;
    NavMeshAgent Runner2Agent;
    NavMeshAgent Runner3Agent;
    NavMeshAgent Runner4Agent;

    // Start is called before the first frame update
    void Start()
    {
        //Disable pitch scrollbar
        PitchScrollBarGameObject.SetActive(false);
        //Disable the throw button
        throwButtonGameObject.SetActive(false);
        //Create NavMeshAgents
        LeftFielderAgent = LeftFielder.GetComponent<NavMeshAgent>();
        CenterFielderAgent = CenterFielder.GetComponent<NavMeshAgent>();
        RightFielderAgent = RightFielder.GetComponent<NavMeshAgent>();
        ThirdBasemanAgent = ThirdBaseman.GetComponent<NavMeshAgent>();
        ShortstopAgent = Shortstop.GetComponent<NavMeshAgent>();
        SecondBasemanAgent = SecondBaseman.GetComponent<NavMeshAgent>();
        FirstBasemanAgent = FirstBaseman.GetComponent<NavMeshAgent>();
        PitcherAgent = Pitcher.GetComponent<NavMeshAgent>();
        CatcherAgent = Catcher.GetComponent<NavMeshAgent>();
        Runner1Agent = Runner1.GetComponent<NavMeshAgent>();
        Runner2Agent = Runner2.GetComponent<NavMeshAgent>();
        Runner3Agent = Runner3.GetComponent<NavMeshAgent>();
        Runner4Agent = Runner4.GetComponent<NavMeshAgent>();
        //Play Ball!
        if (SinglePlayerMode == false)
        {
            StartCoroutine("playBall");
        }
        else
        {
            StartCoroutine("playBallSinglePlayer");
        }
    }

    // Check who is on what base
    void Update()
    {
        // Check where Runner1 is ...
        if (Runner1.GetComponent<Runner>().atTargetBase)
        {
            //Runner1 reached his target base. Check which base Runner1 is on.
            if (string.Equals(Runner1.GetComponent<Runner>().currentBase, "firstBase")) {
                manOnFirst = true;
            }
            else if (string.Equals(Runner1.GetComponent<Runner>().currentBase, "secondBase")) {
                manOnSecond = true;
            }
            else if (string.Equals(Runner1.GetComponent<Runner>().currentBase, "thirdBase")) {
                manOnThird = true;
            }
            else if (string.Equals(Runner1.GetComponent<Runner>().currentBase, "homePlate")) {
                manAtHome = true;
            }
        }
        // Check where Runner2 is ...
        if (Runner2.GetComponent<Runner>().atTargetBase)
        {
            //Runner2 reached his target base. Check which base Runner2 is on.
            if (string.Equals(Runner2.GetComponent<Runner>().currentBase, "firstBase")) {
                manOnFirst = true;
            }
            else if (string.Equals(Runner2.GetComponent<Runner>().currentBase, "secondBase")) {
                manOnSecond = true;
            }
            else if (string.Equals(Runner2.GetComponent<Runner>().currentBase, "thirdBase")) {
                manOnThird = true;
            }
            else if (string.Equals(Runner2.GetComponent<Runner>().currentBase, "homePlate")) {
                manAtHome = true;
            }
        }
        // Check where Runner3 is ...
        if (Runner3.GetComponent<Runner>().atTargetBase)
        {
            //Runner3 reached his target base. Check which base Runner3 is on.
            if (string.Equals(Runner3.GetComponent<Runner>().currentBase, "firstBase")) {
                manOnFirst = true;
            }
            else if (string.Equals(Runner3.GetComponent<Runner>().currentBase, "secondBase")) {
                manOnSecond = true;
            }
            else if (string.Equals(Runner3.GetComponent<Runner>().currentBase, "thirdBase")) {
                manOnThird = true;
            }
            else if (string.Equals(Runner3.GetComponent<Runner>().currentBase, "homePlate")) {
                manAtHome = true;
            }
        }
        // Check where Runner4 is ...
        if (Runner1.GetComponent<Runner>().atTargetBase)
        {
            //Runner4 reached his target base. Check which base Runner4 is on.
            if (string.Equals(Runner4.GetComponent<Runner>().currentBase, "firstBase")) {
                manOnFirst = true;
            }
            else if (string.Equals(Runner4.GetComponent<Runner>().currentBase, "secondBase")) {
                manOnSecond = true;
            }
            else if (string.Equals(Runner4.GetComponent<Runner>().currentBase, "thirdBase")){
                manOnThird = true;
            }
            else if (string.Equals(Runner4.GetComponent<Runner>().currentBase, "homePlate")) {
                manAtHome = true;
            }
        }
        //Debug.Log("First = " + manOnFirst + " : Second = " + manOnSecond + " : Third = " + manOnThird + " : Home = " + manAtHome);
    }

    public IEnumerator playBallSinglePlayer()
    {
        //Play "Hello and welcome" audio
        HelloAndWelcomeAudio.Play();
        while (Inning < 10)
        {
            // --------- Yankees are batting / Red Sox are fielding ----------
            YankeesAreBatting = true;
            // Change fielders to be red
            LeftFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            CenterFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            RightFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            ThirdBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Shortstop.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            SecondBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            FirstBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Pitcher.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Catcher.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            // Change batter and runners to be blue
            Hitter.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner1.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner3.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner4.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            //To start inning, show the inning change camera. Also, disable the next pitch button and the bat scroll bar
            mainCamera.SetActive(false);
            inningChangeCamera.SetActive(true);
            nextPitchButtonGameObject.SetActive(false);
            BatScrollBarGameObject.SetActive(false);
            //Start each Red Sox fielder at their bench position so it looks like they are taking the field
            LeftFielder.transform.position = new Vector3(RedSoxLeftFielderBenchMarker.transform.position.x, 1f, RedSoxLeftFielderBenchMarker.transform.position.z);
            CenterFielder.transform.position = new Vector3(RedSoxCenterFielderBenchMarker.transform.position.x, 1f, RedSoxCenterFielderBenchMarker.transform.position.z);
            RightFielder.transform.position = new Vector3(RedSoxRightFielderBenchMarker.transform.position.x, 1f, RedSoxRightFielderBenchMarker.transform.position.z);
            ThirdBaseman.transform.position = new Vector3(RedSoxThirdBasemanBenchMarker.transform.position.x, 1f, RedSoxThirdBasemanBenchMarker.transform.position.z);
            Shortstop.transform.position = new Vector3(RedSoxShortstopBenchMarker.transform.position.x, 1f, RedSoxShortstopBenchMarker.transform.position.z);
            SecondBaseman.transform.position = new Vector3(RedSoxSecondBasemanBenchMarker.transform.position.x, 1f, RedSoxSecondBasemanBenchMarker.transform.position.z);
            FirstBaseman.transform.position = new Vector3(RedSoxFirstBasemanBenchMarker.transform.position.x, 1f, RedSoxFirstBasemanBenchMarker.transform.position.z);
            Pitcher.transform.position = new Vector3(RedSoxPitcherBenchMarker.transform.position.x, 1f, RedSoxPitcherBenchMarker.transform.position.z);
            Catcher.transform.position = new Vector3(RedSoxCatcherBenchMarker.transform.position.x, 1f, RedSoxCatcherBenchMarker.transform.position.z);
            //Start Yankee runners in the Yankee dugout
            Runner1.GetComponent<Runner>().currentBase = "homePlate";
            Runner2.GetComponent<Runner>().currentBase = "homePlate";
            Runner3.GetComponent<Runner>().currentBase = "homePlate";
            Runner4.GetComponent<Runner>().currentBase = "homePlate";
            Runner1.GetComponent<Runner>().enabled = false;
            Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
            Runner2.GetComponent<Runner>().enabled = false;
            Runner2Agent.SetDestination(YankeeRunner2BenchMarker.transform.position);
            Runner3.GetComponent<Runner>().enabled = false;
            Runner3Agent.SetDestination(YankeeRunner3BenchMarker.transform.position);
            Runner4.GetComponent<Runner>().enabled = false;
            Runner4Agent.SetDestination(YankeeRunner4BenchMarker.transform.position);
            Runner1.transform.position = new Vector3(YankeeRunner1BenchMarker.transform.position.x, 1f, YankeeRunner1BenchMarker.transform.position.z);
            Runner2.transform.position = new Vector3(YankeeRunner2BenchMarker.transform.position.x, 1f, YankeeRunner2BenchMarker.transform.position.z);
            Runner3.transform.position = new Vector3(YankeeRunner3BenchMarker.transform.position.x, 1f, YankeeRunner3BenchMarker.transform.position.z);
            Runner4.transform.position = new Vector3(YankeeRunner4BenchMarker.transform.position.x, 1f, YankeeRunner4BenchMarker.transform.position.z);
            //Disable fielding
            disableAllFielders();
            //Send players to positions
            playersToPositions();
            // Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
            // Play organ music
            ChargeOrganAudio.Play();
            //Wait 10 seconds
            yield return new WaitForSeconds(10);
            //Switch back cameras
            inningChangeCamera.SetActive(false);
            mainCamera.SetActive(true);
            // Enable the space bar swinger
            SwingManager.SetActive(true);
            // While still in inning...
            while (Outs < 3)
            {
                //Disable runners
                disableAllRunners();
                //Pitch to player
                yield return StartCoroutine("pitchToBatter");
                // Check if lead runner is standing on homeplate (current base is homePlate and runner is at target base)...
                if (Runner1.GetComponent<Runner>().atTargetBase && string.Equals(Runner1.GetComponent<Runner>().currentBase, "homePlate"))
                {
                    // Add 1 to score
                    YankeesRuns += 1;
                    // Send Runner1 to bench
                    Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
                    // Announce that a run scored
                    RunScoredAudio.Play();
                }
            }
            //Reset out count
            Outs = 0;
            //Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
            //Start next half of the inning
            Inning += 0.5f;
            // --------- Yankees are fielding / Red Sox are batting ----------
            YankeesAreBatting = false;
            // Change fielders to be blue
            LeftFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            CenterFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            RightFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            ThirdBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Shortstop.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            SecondBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            FirstBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Pitcher.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Catcher.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            // Change batter and runners to be red
            Hitter.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner3.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner4.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            //To start inning, show the inning change camera. Also, disable the next pitch button and the bat scroll bar
            mainCamera.SetActive(false);
            inningChangeCamera.SetActive(true);
            nextPitchButtonGameObject.SetActive(false);
            BatScrollBarGameObject.SetActive(false);
            //Start each Yankee fielder at their bench position so it looks like they are taking the field
            LeftFielder.transform.position = new Vector3(YankeeLeftFielderBenchMarker.transform.position.x, 1f, YankeeLeftFielderBenchMarker.transform.position.z);
            CenterFielder.transform.position = new Vector3(YankeeCenterFielderBenchMarker.transform.position.x, 1f, YankeeCenterFielderBenchMarker.transform.position.z);
            RightFielder.transform.position = new Vector3(YankeeRightFielderBenchMarker.transform.position.x, 1f, YankeeRightFielderBenchMarker.transform.position.z);
            ThirdBaseman.transform.position = new Vector3(YankeeThirdBasemanBenchMarker.transform.position.x, 1f, YankeeThirdBasemanBenchMarker.transform.position.z);
            Shortstop.transform.position = new Vector3(YankeeShortstopBenchMarker.transform.position.x, 1f, YankeeShortstopBenchMarker.transform.position.z);
            SecondBaseman.transform.position = new Vector3(YankeeSecondBasemanBenchMarker.transform.position.x, 1f, YankeeSecondBasemanBenchMarker.transform.position.z);
            FirstBaseman.transform.position = new Vector3(YankeeFirstBasemanBenchMarker.transform.position.x, 1f, YankeeFirstBasemanBenchMarker.transform.position.z);
            Pitcher.transform.position = new Vector3(YankeePitcherBenchMarker.transform.position.x, 1f, YankeePitcherBenchMarker.transform.position.z);
            Catcher.transform.position = new Vector3(YankeeCatcherBenchMarker.transform.position.x, 1f, YankeeCatcherBenchMarker.transform.position.z);
            //Start Red Sox runners in the Red Sox dugout
            Runner1.GetComponent<Runner>().currentBase = "homePlate";
            Runner2.GetComponent<Runner>().currentBase = "homePlate";
            Runner3.GetComponent<Runner>().currentBase = "homePlate";
            Runner4.GetComponent<Runner>().currentBase = "homePlate";
            Runner1.GetComponent<Runner>().enabled = false;
            Runner1Agent.SetDestination(RedSoxRunner1BenchMarker.transform.position);
            Runner2.GetComponent<Runner>().enabled = false;
            Runner2Agent.SetDestination(RedSoxRunner2BenchMarker.transform.position);
            Runner3.GetComponent<Runner>().enabled = false;
            Runner3Agent.SetDestination(RedSoxRunner3BenchMarker.transform.position);
            Runner4.GetComponent<Runner>().enabled = false;
            Runner4Agent.SetDestination(RedSoxRunner4BenchMarker.transform.position);
            Runner1.transform.position = new Vector3(RedSoxRunner1BenchMarker.transform.position.x, 1f, YankeeRunner1BenchMarker.transform.position.z);
            Runner2.transform.position = new Vector3(RedSoxRunner2BenchMarker.transform.position.x, 1f, YankeeRunner2BenchMarker.transform.position.z);
            Runner3.transform.position = new Vector3(RedSoxRunner3BenchMarker.transform.position.x, 1f, YankeeRunner3BenchMarker.transform.position.z);
            Runner4.transform.position = new Vector3(RedSoxRunner4BenchMarker.transform.position.x, 1f, YankeeRunner4BenchMarker.transform.position.z);
            //Disable fielding
            disableAllFielders();
            //Send players to positions
            playersToPositions();
            // Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
            // Play organ music
            ChargeOrganAudio.Play();
            //Wait 10 seconds
            yield return new WaitForSeconds(10);
            //Switch back cameras
            inningChangeCamera.SetActive(false);
            mainCamera.SetActive(true);
            // Disable the space bar swinger
            SwingManager.SetActive(false);
            // While still in inning...
            while (Outs < 3)
            {
                //Disable runners
                disableAllRunners();
                yield return StartCoroutine("pitchToBatterSinglePlayer");
                // Check if lead runner is standing on homeplate (current base is homePlate and runner is at target base)...
                if (Runner1.GetComponent<Runner>().atTargetBase && string.Equals(Runner1.GetComponent<Runner>().currentBase, "homePlate"))
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 1;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 1;
                    }
                    // Send Runner1 to bench
                    Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
                    // Announce that a run scored
                    RunScoredAudio.Play();
                }
            }
            //Reset out count
            Outs = 0;
            //Start next half of the inning
            Inning += 0.5f;
            // Reset runners
            Runner1.GetComponent<Runner>().currentBase = "homePlate";
            Runner2.GetComponent<Runner>().currentBase = "homePlate";
            Runner3.GetComponent<Runner>().currentBase = "homePlate";
            Runner4.GetComponent<Runner>().currentBase = "homePlate";
            Runner1.GetComponent<Runner>().enabled = false;
            Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
            Runner2.GetComponent<Runner>().enabled = false;
            Runner2Agent.SetDestination(YankeeRunner2BenchMarker.transform.position);
            Runner3.GetComponent<Runner>().enabled = false;
            Runner3Agent.SetDestination(YankeeRunner3BenchMarker.transform.position);
            Runner4.GetComponent<Runner>().enabled = false;
            // Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
            // Enable the space bar swinger
            SwingManager.SetActive(true);
        }
        //Determine a winner
        if (YankeesRuns >= RedSoxRuns)
        {
            YankeesWinAudio.Play();
        }
        else
        {
            RedSoxWinAudio.Play();
        }
    }

    public IEnumerator playBall()
    {
        //Play "Hello and welcome" audio
        HelloAndWelcomeAudio.Play();
        while (Inning < 10)
        {
            // --------- Yankees are batting / Red Sox are fielding ----------
            YankeesAreBatting = true;
            // Change fielders to be red
            LeftFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            CenterFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            RightFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            ThirdBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Shortstop.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            SecondBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            FirstBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Pitcher.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Catcher.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            // Change batter and runners to be blue
            Hitter.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner1.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner3.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Runner4.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            //To start inning, show the inning change camera. Also, disable the next pitch button and the bat scroll bar
            mainCamera.SetActive(false);
            inningChangeCamera.SetActive(true);
            nextPitchButtonGameObject.SetActive(false);
            BatScrollBarGameObject.SetActive(false);
            //Start each Red Sox fielder at their bench position so it looks like they are taking the field
            LeftFielder.transform.position = new Vector3(RedSoxLeftFielderBenchMarker.transform.position.x, 1f, RedSoxLeftFielderBenchMarker.transform.position.z);
            CenterFielder.transform.position = new Vector3(RedSoxCenterFielderBenchMarker.transform.position.x, 1f, RedSoxCenterFielderBenchMarker.transform.position.z);
            RightFielder.transform.position = new Vector3(RedSoxRightFielderBenchMarker.transform.position.x, 1f, RedSoxRightFielderBenchMarker.transform.position.z);
            ThirdBaseman.transform.position = new Vector3(RedSoxThirdBasemanBenchMarker.transform.position.x, 1f, RedSoxThirdBasemanBenchMarker.transform.position.z);
            Shortstop.transform.position = new Vector3(RedSoxShortstopBenchMarker.transform.position.x, 1f, RedSoxShortstopBenchMarker.transform.position.z);
            SecondBaseman.transform.position = new Vector3(RedSoxSecondBasemanBenchMarker.transform.position.x, 1f, RedSoxSecondBasemanBenchMarker.transform.position.z);
            FirstBaseman.transform.position = new Vector3(RedSoxFirstBasemanBenchMarker.transform.position.x, 1f, RedSoxFirstBasemanBenchMarker.transform.position.z);
            Pitcher.transform.position = new Vector3(RedSoxPitcherBenchMarker.transform.position.x, 1f, RedSoxPitcherBenchMarker.transform.position.z);
            Catcher.transform.position = new Vector3(RedSoxCatcherBenchMarker.transform.position.x, 1f, RedSoxCatcherBenchMarker.transform.position.z);
            //Start Yankee runners in the Yankee dugout
            Runner1.GetComponent<Runner>().currentBase = "homePlate";
            Runner2.GetComponent<Runner>().currentBase = "homePlate";
            Runner3.GetComponent<Runner>().currentBase = "homePlate";
            Runner4.GetComponent<Runner>().currentBase = "homePlate";
            Runner1.GetComponent<Runner>().enabled = false;
            Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
            Runner2.GetComponent<Runner>().enabled = false;
            Runner2Agent.SetDestination(YankeeRunner2BenchMarker.transform.position);
            Runner3.GetComponent<Runner>().enabled = false;
            Runner3Agent.SetDestination(YankeeRunner3BenchMarker.transform.position);
            Runner4.GetComponent<Runner>().enabled = false;
            Runner4Agent.SetDestination(YankeeRunner4BenchMarker.transform.position);
            Runner1.transform.position = new Vector3(YankeeRunner1BenchMarker.transform.position.x, 1f, YankeeRunner1BenchMarker.transform.position.z);
            Runner2.transform.position = new Vector3(YankeeRunner2BenchMarker.transform.position.x, 1f, YankeeRunner2BenchMarker.transform.position.z);
            Runner3.transform.position = new Vector3(YankeeRunner3BenchMarker.transform.position.x, 1f, YankeeRunner3BenchMarker.transform.position.z);
            Runner4.transform.position = new Vector3(YankeeRunner4BenchMarker.transform.position.x, 1f, YankeeRunner4BenchMarker.transform.position.z);
            //Disable fielding
            disableAllFielders();
            //Send players to positions
            playersToPositions();
            // Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
            // Play organ music
            ChargeOrganAudio.Play();
            //Wait 10 seconds
            yield return new WaitForSeconds(10);
            //Switch back cameras
            inningChangeCamera.SetActive(false);
            mainCamera.SetActive(true);
            // While still in inning...
            while (Outs < 3)
            {
                //Disable runners
                disableAllRunners();
                //Pitch to player
                yield return StartCoroutine("pitchToBatter");
                // Check if lead runner is standing on homeplate (current base is homePlate and runner is at target base)...
                if (Runner1.GetComponent<Runner>().atTargetBase && string.Equals(Runner1.GetComponent<Runner>().currentBase, "homePlate"))
                {
                    // Add 1 to score
                    YankeesRuns += 1;
                    // Send Runner1 to bench
                    Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
                    // Announce that a run scored
                    RunScoredAudio.Play();
                }
            }
            //Reset out count
            Outs = 0;
            //Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
            //Start next half of the inning
            Inning += 0.5f;
            // --------- Yankees are fielding / Red Sox are batting ----------
            YankeesAreBatting = false;
            // Change fielders to be blue
            LeftFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            CenterFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            RightFielder.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            ThirdBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Shortstop.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            SecondBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            FirstBaseman.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Pitcher.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            Catcher.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            // Change batter and runners to be red
            Hitter.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner3.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Runner4.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            //To start inning, show the inning change camera. Also, disable the next pitch button and the bat scroll bar
            mainCamera.SetActive(false);
            inningChangeCamera.SetActive(true);
            nextPitchButtonGameObject.SetActive(false);
            BatScrollBarGameObject.SetActive(false);
            //Start each Yankee fielder at their bench position so it looks like they are taking the field
            LeftFielder.transform.position = new Vector3(YankeeLeftFielderBenchMarker.transform.position.x, 1f, YankeeLeftFielderBenchMarker.transform.position.z);
            CenterFielder.transform.position = new Vector3(YankeeCenterFielderBenchMarker.transform.position.x, 1f, YankeeCenterFielderBenchMarker.transform.position.z);
            RightFielder.transform.position = new Vector3(YankeeRightFielderBenchMarker.transform.position.x, 1f, YankeeRightFielderBenchMarker.transform.position.z);
            ThirdBaseman.transform.position = new Vector3(YankeeThirdBasemanBenchMarker.transform.position.x, 1f, YankeeThirdBasemanBenchMarker.transform.position.z);
            Shortstop.transform.position = new Vector3(YankeeShortstopBenchMarker.transform.position.x, 1f, YankeeShortstopBenchMarker.transform.position.z);
            SecondBaseman.transform.position = new Vector3(YankeeSecondBasemanBenchMarker.transform.position.x, 1f, YankeeSecondBasemanBenchMarker.transform.position.z);
            FirstBaseman.transform.position = new Vector3(YankeeFirstBasemanBenchMarker.transform.position.x, 1f, YankeeFirstBasemanBenchMarker.transform.position.z);
            Pitcher.transform.position = new Vector3(YankeePitcherBenchMarker.transform.position.x, 1f, YankeePitcherBenchMarker.transform.position.z);
            Catcher.transform.position = new Vector3(YankeeCatcherBenchMarker.transform.position.x, 1f, YankeeCatcherBenchMarker.transform.position.z);
            //Start Red Sox runners in the Red Sox dugout
            Runner1.GetComponent<Runner>().currentBase = "homePlate";
            Runner2.GetComponent<Runner>().currentBase = "homePlate";
            Runner3.GetComponent<Runner>().currentBase = "homePlate";
            Runner4.GetComponent<Runner>().currentBase = "homePlate";
            Runner1.GetComponent<Runner>().enabled = false;
            Runner1Agent.SetDestination(RedSoxRunner1BenchMarker.transform.position);
            Runner2.GetComponent<Runner>().enabled = false;
            Runner2Agent.SetDestination(RedSoxRunner2BenchMarker.transform.position);
            Runner3.GetComponent<Runner>().enabled = false;
            Runner3Agent.SetDestination(RedSoxRunner3BenchMarker.transform.position);
            Runner4.GetComponent<Runner>().enabled = false;
            Runner4Agent.SetDestination(RedSoxRunner4BenchMarker.transform.position);
            Runner1.transform.position = new Vector3(RedSoxRunner1BenchMarker.transform.position.x, 1f, YankeeRunner1BenchMarker.transform.position.z);
            Runner2.transform.position = new Vector3(RedSoxRunner2BenchMarker.transform.position.x, 1f, YankeeRunner2BenchMarker.transform.position.z);
            Runner3.transform.position = new Vector3(RedSoxRunner3BenchMarker.transform.position.x, 1f, YankeeRunner3BenchMarker.transform.position.z);
            Runner4.transform.position = new Vector3(RedSoxRunner4BenchMarker.transform.position.x, 1f, YankeeRunner4BenchMarker.transform.position.z);
            //Disable fielding
            disableAllFielders();
            //Send players to positions
            playersToPositions();
            // Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
            // Play organ music
            ChargeOrganAudio.Play();
            //Wait 10 seconds
            yield return new WaitForSeconds(10);
            //Switch back cameras
            inningChangeCamera.SetActive(false);
            mainCamera.SetActive(true);
            // While still in inning...
            while (Outs < 3)
            {
                //Disable runners
                disableAllRunners();
                //Pitch to player
                yield return StartCoroutine("pitchToBatter");
                // Check if lead runner is standing on homeplate (current base is homePlate and runner is at target base)...
                if (Runner1.GetComponent<Runner>().atTargetBase && string.Equals(Runner1.GetComponent<Runner>().currentBase, "homePlate"))
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 1;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 1;
                    }
                    // Send Runner1 to bench
                    Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
                    // Announce that a run scored
                    RunScoredAudio.Play();
                }
            }
            //Reset out count
            Outs = 0;
            //Start next half of the inning
            Inning += 0.5f;
            // Reset runners
            Runner1.GetComponent<Runner>().currentBase = "homePlate";
            Runner2.GetComponent<Runner>().currentBase = "homePlate";
            Runner3.GetComponent<Runner>().currentBase = "homePlate";
            Runner4.GetComponent<Runner>().currentBase = "homePlate";
            Runner1.GetComponent<Runner>().enabled = false;
            Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
            Runner2.GetComponent<Runner>().enabled = false;
            Runner2Agent.SetDestination(YankeeRunner2BenchMarker.transform.position);
            Runner3.GetComponent<Runner>().enabled = false;
            Runner3Agent.SetDestination(YankeeRunner3BenchMarker.transform.position);
            Runner4.GetComponent<Runner>().enabled = false;
            // Clear the bases
            manOnFirst = false;
            manOnSecond = false;
            manOnThird = false;
            manAtHome = false;
        }
        //Determine a winner
        if (YankeesRuns >= RedSoxRuns)
        {
            YankeesWinAudio.Play();
        }
        else
        {
            RedSoxWinAudio.Play();
        }
    }

    public IEnumerator pitchToBatterSinglePlayer()
    {
        bool batterHitTheBall = false;
        // Pitch balls until balls = 4 or strikes = 3
        while (Balls < 4 && Strikes < 3 && batterHitTheBall == false)
        {
            //Disable the pitch scrollbar
            PitchScrollBarGameObject.SetActive(false);
            //Disable the throw button
            throwButtonGameObject.SetActive(false);
            //Set "justHitHomeRun" to false
            homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun = false;
            //Enable Ball, Hitter, bat, bat target, and bat rotate around object
            Ball.SetActive(true);
            Hitter.SetActive(true);
            Bat.SetActive(true);
            BatTarget.SetActive(true);
            BatRotateAround.SetActive(true);
            //Disable runners
            disableAllRunners();
            // Enable the button
            nextPitchButtonGameObject.SetActive(true);
            // Disable the Slider
            BatScrollBarGameObject.SetActive(false);
            // Wait for player to hit "next pitch" UI button before throwing next pitch
            var waitForButton = new WaitForUIButtons(nextPitchButton, throwButton);
            yield return waitForButton.Reset();
            // Disable button so that player does not press it more than once
            nextPitchButtonGameObject.SetActive(false);
            // Disable fielders and return them to their spots
            disableAllFielders();
            // Wait for 4 seconds
            yield return new WaitForSeconds(4);
            // Reset to the correct camera
            hitCameraGameObject.SetActive(false);
            mainCamera.SetActive(true);
            // Set hitCamera focus to ball
            hitCameraGameObject.GetComponent<hitCamera>().targetName = "ball";
            // Enable the Pitch Scroll Bar
            PitchScrollBarGameObject.SetActive(true);
            //Enable the throw button
            throwButtonGameObject.SetActive(true);
            // Pitcher can now manually adjust where the pitch is going to be
            // Wait for "throw" button to be pressed
            yield return waitForButton.Reset();
            Ball.SetActive(true);
            string pitchThrown = "error";
            if (gameObject.GetComponent<PitchHeightSlider>().SelectedPitch == 1)
            {
                //Throw "StrikeHigh" pitch
                Ball.GetComponent<PitchBall>().pitch("StrikeHigh");
                pitchThrown = "StrikeHigh";
            }
            else if (gameObject.GetComponent<PitchHeightSlider>().SelectedPitch == 2)
            {
                //Throw "StrikeMiddle" pitch
                Ball.GetComponent<PitchBall>().pitch("StrikeMiddle");
                pitchThrown = "StrikeMiddle";
            }
            else if (gameObject.GetComponent<PitchHeightSlider>().SelectedPitch == 3)
            {
                //Throw "StrikeLow" pitch
                Ball.GetComponent<PitchBall>().pitch("StrikeLow");
                pitchThrown = "StrikeLow";
            }
            else if (gameObject.GetComponent<PitchHeightSlider>().SelectedPitch == 4)
            {
                //Throw "BallLow" pitch
                Ball.GetComponent<PitchBall>().pitch("BallLow");
                pitchThrown = "BallLow";
            }
            // Disable the Pitch Scroll Bar
            PitchScrollBarGameObject.SetActive(false);
            //disable the throw button
            throwButtonGameObject.SetActive(false);
            // Announce who is on base
            if (manOnFirst == false && manOnSecond == false && manOnThird == false)
            {
                NoOneOnAudio.Play();
            }
            else if (manOnFirst == true && manOnSecond == false && manOnThird == false)
            {
                ManOnFirstAudio.Play();
            }
            else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
            {
                MenOnFirstAndSecondAudio.Play();
            }
            else
            {
                BasesLoadedHereAudio.Play();
            }
            // Play pitch audio
            PitchBaseballAudio.Play();
            // Determine if bot batter will guess the right pitch
            bool[] choices = new bool[] { true, false };
            int choice = Random.Range(0, 2);
            bool guessRightPitch = choices[choice];
            // Wait 2.9 seconds
            yield return new WaitForSeconds(2.9f);
            // Determine which pitch is thrown so that bat can move ...
            if (gameObject.GetComponent<PitchHeightSlider>().SelectedPitch == 1)
            {
                // If guessed the right pitch ...
                if (guessRightPitch == true)
                {
                    // Guess correct. Move bat to high position
                    BatHeightManager.GetComponent<BatHeightSlider>().moveBatManually(0.27f);
                }
                else
                {
                    // Guess wrong. Move bat to middle position
                    BatHeightManager.GetComponent<BatHeightSlider>().moveBatManually(0.42f);
                }
                // Have AI swing bat
                Bat.GetComponent<SwingBat>().swung = true;
            }
            else if (gameObject.GetComponent<PitchHeightSlider>().SelectedPitch == 2)
            {
                // If guessed the right pitch ...
                if (guessRightPitch == true)
                {
                    // Guess correct. Move bat to middle position
                    BatHeightManager.GetComponent<BatHeightSlider>().moveBatManually(0.42f);
                }
                else
                {
                    // Guess wrong. Move bat to high position
                    BatHeightManager.GetComponent<BatHeightSlider>().moveBatManually(0.27f);
                }
                // Have AI swing bat
                Bat.GetComponent<SwingBat>().swung = true;
            }
            else if (gameObject.GetComponent<PitchHeightSlider>().SelectedPitch == 3)
            {
                // If guessed the right pitch ...
                if (guessRightPitch == true)
                {
                    // Guess correct. Move bat to low position
                    BatHeightManager.GetComponent<BatHeightSlider>().moveBatManually(0.87f);
                }
                else
                {
                    // Guess wrong. Move bat to middle position
                    BatHeightManager.GetComponent<BatHeightSlider>().moveBatManually(0.42f);
                }
                // Have AI swing bat
                Bat.GetComponent<SwingBat>().swung = true;
            }
            // Wait 0.75 more seconds
            yield return new WaitForSeconds(0.75f);
            if (Bat.GetComponent<SwingBat>().justMadeContact == true)
            {
                // Disable the bat height slider
                BatScrollBarGameObject.SetActive(false);
                //Play bat hit sound effect
                WoodBatHitBallAudio.Play();
                //The crowd cheers because the ball was hit
                CheerAudio.Play();
                //Annouce if Ball was hit hard or not
                if (Bat.GetComponent<SwingBat>().swingPower >= 3000f)
                {
                    //Ball was hit hard
                    ThatIsAHardHitBallAudio.Play();
                }
                else
                {
                    //Ball was hit soft
                    ShortHitBallAudio.Play();

                }
                batterHitTheBall = true;
                Strikes = 0;
                Balls = 0;
                // Disable Hitter, bat, bat target, and bat rotate around object
                Hitter.SetActive(false);
                Bat.SetActive(false);
                BatTarget.SetActive(false);
                BatRotateAround.SetActive(false);
                // Determine who the fielders should throw the ball to
                // If no one on...
                if (manOnFirst == false && manOnSecond == false && manOnThird == false)
                {
                    // Throw to first base
                    enableAllFielders("firstBase");
                    //Runner1 is batting. Move Runner1 to firstBase. Start him running at homePlate.
                    Runner1.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner1.GetComponent<Runner>().enabled = true;
                }
                // If only man on first...
                else if (manOnFirst == true && manOnSecond == false && manOnThird == false)
                {
                    // Throw to second base
                    enableAllFielders("secondBase");
                    //Runner1 is at firstBase. Move Runner1 to secondBase. Start him running at firstBase.
                    Runner1.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "secondBase";
                    Runner1.GetComponent<Runner>().enabled = true;
                    //Runner2 is batting. Move Runner2 to firstBase. Start him running at homePlate.
                    Runner2.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner2.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner2.GetComponent<Runner>().enabled = true;
                }
                // If men on first and second...
                else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
                {
                    // Throw to third base
                    enableAllFielders("thirdBase");
                    //Runner1 is at secondBase. Move Runner1 to thirdBase. Start him running at secondBase.
                    Runner1.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "thirdBase";
                    Runner1.GetComponent<Runner>().enabled = true;
                    //Runner2 is at firstBase. Move Runner2 to secondBase. Start him running at firstBase.
                    Runner2.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                    Runner2.GetComponent<Runner>().baseToRunTo = "secondBase";
                    Runner2.GetComponent<Runner>().enabled = true;
                    //Runner3 is batting. Move Runner3 to firstBase. Start him running at homePlate.
                    Runner3.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner3.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner3.GetComponent<Runner>().enabled = true;
                }
                // If bases loaded ...
                else if (manOnFirst == true && manOnSecond == true && manOnThird == true)
                {
                    // Throw to third base
                    enableAllFielders("homePlate");
                    //Runner1 is at thirdBase. Move Runner1 to homePlate. Start him running at thirdBase.
                    Runner1.transform.position = new Vector3(ThirdBase.transform.position.x, 2, ThirdBase.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "homePlate";
                    Runner1.GetComponent<Runner>().enabled = true;
                    //Runner2 is at secondBase. Move Runner2 to thirdBase. Start him running at secondBase.
                    Runner2.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                    Runner2.GetComponent<Runner>().baseToRunTo = "thirdBase";
                    Runner2.GetComponent<Runner>().enabled = true;
                    //Runner3 is at firstBase. Move Runner3 to secondBase. Start him running at firstBase.
                    Runner3.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                    Runner3.GetComponent<Runner>().baseToRunTo = "secondBase";
                    Runner3.GetComponent<Runner>().enabled = true;
                    //Runner4 is batting. Move Runner4 to firstBase. Start him running at homePlate.
                    Runner4.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner4.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner4.GetComponent<Runner>().enabled = true;
                }
                else
                {
                    // If unknown or error, throw to first base
                    enableAllFielders("firstbase");
                }
            }
            else
            {
                // Batter did not swing at pitch. Determine what type of pitch was thrown (if it was a ball or not).
                // If strike ...
                if (string.Equals(pitchThrown, "StrikeLow") || string.Equals(pitchThrown, "StrikeMiddle") || string.Equals(pitchThrown, "StrikeHigh"))
                {
                    // Add 1 to strike count
                    Strikes += 1;
                    // Announce how many strikes there are (1-2)
                    if (Strikes == 1)
                    {
                        StrikeOneAudio.Play();
                    }
                    else if (Strikes == 2)
                    {
                        StrikeTwoAudio.Play();
                    }
                }
                else
                {
                    Balls += 1;
                    // Annouce how many balls there are (1-3)
                    if (Balls == 1)
                    {
                        BallOneAudio.Play();
                    }
                    else if (Balls == 2)
                    {
                        BallTwoAudio.Play();
                    }
                    else if (Balls == 3)
                    {
                        BallThreeAudio.Play();
                    }
                }
                // Play catch ball audio
                CatchAudio.Play();
            }
            // Wait 3 seconds
            yield return new WaitForSeconds(3);
            // Reset bat
            Bat.GetComponent<SwingBat>().swung = false;
            Bat.GetComponent<SwingBat>().resetSwing();
            // Wait 5 seconds
            yield return new WaitForSeconds(5);
            // Check if batter hit a home run
            if (homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun == true)
            {
                // Announce that a home run was hit
                HomeRunAudio.Play();
                // Depending on who is on base...
                if (manOnFirst == true && manOnSecond == false && manOnThird == false)
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 1;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 1;
                    }
                }
                else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 2;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 2;
                    }
                }
                else if (manOnFirst == true && manOnSecond == true && manOnThird == true)
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 3;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 3;
                    }
                }
                //Send runners to their bench position
                Runner1.GetComponent<Runner>().atTargetBase = false;
                Runner2.GetComponent<Runner>().atTargetBase = false;
                Runner3.GetComponent<Runner>().atTargetBase = false;
                Runner4.GetComponent<Runner>().atTargetBase = false;
                Runner1.GetComponent<Runner>().enabled = false;
                Runner2.GetComponent<Runner>().enabled = false;
                Runner3.GetComponent<Runner>().enabled = false;
                Runner4.GetComponent<Runner>().enabled = false;
                Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
                Runner2Agent.SetDestination(YankeeRunner2BenchMarker.transform.position);
                Runner3Agent.SetDestination(YankeeRunner3BenchMarker.transform.position);
                Runner4Agent.SetDestination(YankeeRunner4BenchMarker.transform.position);
                // Clear the bases
                manOnFirst = false;
                manOnSecond = false;
                manOnThird = false;
                manAtHome = false;
            }
            // Set "justMadeContact" bat to false
            Bat.GetComponent<SwingBat>().justMadeContact = false;
            // Set "justHitHomeRun" to false
            homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun = false;
        }
        // If 3 strikes ...
        if (Strikes == 3)
        {
            // Out! Add one out to the scoreboard
            Outs += 1;
            // Reset strike and balls
            Strikes = 0;
            Balls = 0;
            // Announce that the batter struck out
            StrikeThreeAudio.Play();
        }
        else if (Balls == 4)
        {
            //Announce that the batter walked
            BallFourAudio.Play();
            // Walk the batter. Runners advance 1 base
            // Switch to walk camera
            mainCamera.SetActive(false);
            walkCamera.SetActive(true);
            // Determine where the runners should move to
            // If no one on...
            if (manOnFirst == false && manOnSecond == false && manOnThird == false)
            {
                //Runner1 is batting. Move Runner1 to firstBase. Start him running at homePlate.
                Runner1.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner1.GetComponent<Runner>().enabled = true;
            }
            // If only man on first...
            else if (manOnFirst == true && manOnSecond == false && manOnThird == false)
            {
                //Runner1 is at firstBase. Move Runner1 to secondBase. Start him running at firstBase.
                Runner1.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "secondBase";
                Runner1.GetComponent<Runner>().enabled = true;
                //Runner2 is batting. Move Runner2 to firstBase. Start him running at homePlate.
                Runner2.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner2.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner2.GetComponent<Runner>().enabled = true;
            }
            // If men on first and second...
            else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
            {
                //Runner1 is at secondBase. Move Runner1 to thirdBase. Start him running at secondBase.
                Runner1.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "thirdBase";
                Runner1.GetComponent<Runner>().enabled = true;
                //Runner2 is at firstBase. Move Runner2 to secondBase. Start him running at firstBase.
                Runner2.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                Runner2.GetComponent<Runner>().baseToRunTo = "secondBase";
                Runner2.GetComponent<Runner>().enabled = true;
                //Runner3 is batting. Move Runner3 to firstBase. Start him running at homePlate.
                Runner3.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner3.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner3.GetComponent<Runner>().enabled = true;
            }
            // If bases loaded ...
            else if (manOnFirst == true && manOnSecond == true && manOnThird == true)
            {
                //Runner1 is at thirdBase. Move Runner1 to homePlate. Start him running at thirdBase.
                Runner1.transform.position = new Vector3(ThirdBase.transform.position.x, 2, ThirdBase.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "homePlate";
                Runner1.GetComponent<Runner>().enabled = true;
                //Runner2 is at secondBase. Move Runner2 to thirdBase. Start him running at secondBase.
                Runner2.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                Runner2.GetComponent<Runner>().baseToRunTo = "thirdBase";
                Runner2.GetComponent<Runner>().enabled = true;
                //Runner3 is at firstBase. Move Runner3 to secondBase. Start him running at firstBase.
                Runner3.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                Runner3.GetComponent<Runner>().baseToRunTo = "secondBase";
                Runner3.GetComponent<Runner>().enabled = true;
                //Runner4 is batting. Move Runner4 to firstBase. Start him running at homePlate.
                Runner4.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner4.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner4.GetComponent<Runner>().enabled = true;
            }
            // Wait 6 seconds
            yield return new WaitForSeconds(5);
            // Switch back to main Camera
            walkCamera.SetActive(false);
            mainCamera.SetActive(true);
            // Reset ball and strike count
            Balls = 0;
            Strikes = 0;
        }
    }

    public IEnumerator pitchToBatter()
    {
        bool batterHitTheBall = false;
        // Pitch balls until balls = 4 or strikes = 3
        while (Balls < 4 && Strikes < 3 && batterHitTheBall == false)
        {
            //Set "justHitHomeRun" to false
            homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun = false;
            //Enable Ball, Hitter, bat, bat target, and bat rotate around object
            Ball.SetActive(true);
            Hitter.SetActive(true);
            Bat.SetActive(true);
            BatTarget.SetActive(true);
            BatRotateAround.SetActive(true);
            //Disable runners
            disableAllRunners();
            // Enable the button
            nextPitchButtonGameObject.SetActive(true);
            // Disable the Slider
            BatScrollBarGameObject.SetActive(false);
            // Wait for player to hit "next pitch" UI button before throwing next pitch
            var waitForButton = new WaitForUIButtons(nextPitchButton);
            yield return waitForButton.Reset();
            // Disable button so that player does not press it more than once
            nextPitchButtonGameObject.SetActive(false);
            // Enable the Scroll Bar
            BatScrollBarGameObject.SetActive(true);
            // Disable fielders and return them to their spots
            disableAllFielders();
            // Wait for 4 seconds
            yield return new WaitForSeconds(4);
            // Reset to the correct camera
            hitCameraGameObject.SetActive(false);
            mainCamera.SetActive(true);
            //Set hitCamera focus to ball
            hitCameraGameObject.GetComponent<hitCamera>().targetName = "ball";
            // Throw the pitch
            Ball.SetActive(true);
            string pitchThrown = Ball.GetComponent<PitchBall>().selectRandomPitch();
            // Announce who is on base
            if (manOnFirst == false && manOnSecond == false && manOnThird == false)
            {
                NoOneOnAudio.Play();
            }
            else if (manOnFirst == true && manOnSecond == false && manOnThird == false)
            {
                ManOnFirstAudio.Play();
            }
            else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
            {
                MenOnFirstAndSecondAudio.Play();
            }
            else
            {
                BasesLoadedHereAudio.Play();
            }
            // Wait 3.25 seconds
            yield return new WaitForSeconds(3.25f);
            // Play pitch audio
            PitchBaseballAudio.Play();
            // Determine if batter hit the ball
            // If Batter made contact ...
            if (Bat.GetComponent<SwingBat>().justMadeContact == true)
            {
                // Disable the bat height slider
                BatScrollBarGameObject.SetActive(false);
                //Play bat hit sound effect
                WoodBatHitBallAudio.Play();
                //The crowd cheers because the ball was hit
                CheerAudio.Play();
                //Annouce if Ball was hit hard or not
                if (Bat.GetComponent<SwingBat>().swingPower >= 3000f)
                {
                    //Ball was hit hard
                    ThatIsAHardHitBallAudio.Play();
                }
                else
                {
                    //Ball was hit soft
                    ShortHitBallAudio.Play();

                }
                batterHitTheBall = true;
                Strikes = 0;
                Balls = 0;
                // Disable Hitter, bat, bat target, and bat rotate around object
                Hitter.SetActive(false);
                Bat.SetActive(false);
                BatTarget.SetActive(false);
                BatRotateAround.SetActive(false);
                // Determine who the fielders should throw the ball to
                // If no one on...
                if (manOnFirst == false && manOnSecond == false && manOnThird == false)
                {
                    // Throw to first base
                    enableAllFielders("firstBase");
                    //Runner1 is batting. Move Runner1 to firstBase. Start him running at homePlate.
                    Runner1.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner1.GetComponent<Runner>().enabled = true;
                }
                // If only man on first...
                else if (manOnFirst == true && manOnSecond == false && manOnThird == false)
                {
                    // Throw to second base
                    enableAllFielders("secondBase");
                    //Runner1 is at firstBase. Move Runner1 to secondBase. Start him running at firstBase.
                    Runner1.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "secondBase";
                    Runner1.GetComponent<Runner>().enabled = true;
                    //Runner2 is batting. Move Runner2 to firstBase. Start him running at homePlate.
                    Runner2.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner2.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner2.GetComponent<Runner>().enabled = true;
                }
                // If men on first and second...
                else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
                {
                    // Throw to third base
                    enableAllFielders("thirdBase");
                    //Runner1 is at secondBase. Move Runner1 to thirdBase. Start him running at secondBase.
                    Runner1.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "thirdBase";
                    Runner1.GetComponent<Runner>().enabled = true;
                    //Runner2 is at firstBase. Move Runner2 to secondBase. Start him running at firstBase.
                    Runner2.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                    Runner2.GetComponent<Runner>().baseToRunTo = "secondBase";
                    Runner2.GetComponent<Runner>().enabled = true;
                    //Runner3 is batting. Move Runner3 to firstBase. Start him running at homePlate.
                    Runner3.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner3.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner3.GetComponent<Runner>().enabled = true;
                }
                // If bases loaded ...
                else if (manOnFirst == true && manOnSecond == true && manOnThird == true)
                {
                    // Throw to third base
                    enableAllFielders("homePlate");
                    //Runner1 is at thirdBase. Move Runner1 to homePlate. Start him running at thirdBase.
                    Runner1.transform.position = new Vector3(ThirdBase.transform.position.x, 2, ThirdBase.transform.position.z);
                    Runner1.GetComponent<Runner>().baseToRunTo = "homePlate";
                    Runner1.GetComponent<Runner>().enabled = true;
                    //Runner2 is at secondBase. Move Runner2 to thirdBase. Start him running at secondBase.
                    Runner2.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                    Runner2.GetComponent<Runner>().baseToRunTo = "thirdBase";
                    Runner2.GetComponent<Runner>().enabled = true;
                    //Runner3 is at firstBase. Move Runner3 to secondBase. Start him running at firstBase.
                    Runner3.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                    Runner3.GetComponent<Runner>().baseToRunTo = "secondBase";
                    Runner3.GetComponent<Runner>().enabled = true;
                    //Runner4 is batting. Move Runner4 to firstBase. Start him running at homePlate.
                    Runner4.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                    Runner4.GetComponent<Runner>().baseToRunTo = "firstBase";
                    Runner4.GetComponent<Runner>().enabled = true;
                }
                else
                {
                    // If unknown or error, throw to first base
                    enableAllFielders("firstbase");
                }
            }
            else
            {
                // Batter did not swing at pitch. Determine what type of pitch was thrown (if it was a ball or not).
                // If strike ...
                if (string.Equals(pitchThrown, "StrikeLow") || string.Equals(pitchThrown, "StrikeMiddle") || string.Equals(pitchThrown, "StrikeHigh"))
                {
                    // Add 1 to strike count
                    Strikes += 1;
                    // Announce how many strikes there are (1-2)
                    if (Strikes == 1)
                    {
                        StrikeOneAudio.Play();
                    }
                    else if (Strikes == 2)
                    {
                        StrikeTwoAudio.Play();
                    }
                }
                else
                {
                    Balls += 1;
                    // Annouce how many balls there are (1-3)
                    if (Balls == 1)
                    {
                        BallOneAudio.Play();
                    }
                    else if (Balls == 2)
                    {
                        BallTwoAudio.Play();
                    }
                    else if (Balls == 3)
                    {
                        BallThreeAudio.Play();
                    }
                }
                // Play catch ball audio
                CatchAudio.Play();
            }
            // Wait 5 seconds before showing buttons again
            yield return new WaitForSeconds(8);
            // Check if batter hit a home run
            if (homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun == true)
            {
                // Announce that a home run was hit
                HomeRunAudio.Play();
                // Depending on who is on base...
                if (manOnFirst == true && manOnSecond == false && manOnThird == false)
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 1;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 1;
                    }
                }
                else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 2;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 2;
                    }
                }
                else if (manOnFirst == true && manOnSecond == true && manOnThird == true)
                {
                    if (YankeesAreBatting == true)
                    {
                        // Add 1 to Yankees score
                        YankeesRuns += 3;
                    }
                    else
                    {
                        // Add 1 to Red Sox score
                        RedSoxRuns += 3;
                    }
                }
                //Send runners to their bench position
                Runner1.GetComponent<Runner>().atTargetBase = false;
                Runner2.GetComponent<Runner>().atTargetBase = false;
                Runner3.GetComponent<Runner>().atTargetBase = false;
                Runner4.GetComponent<Runner>().atTargetBase = false;
                Runner1.GetComponent<Runner>().enabled = false;
                Runner2.GetComponent<Runner>().enabled = false;
                Runner3.GetComponent<Runner>().enabled = false;
                Runner4.GetComponent<Runner>().enabled = false;
                Runner1Agent.SetDestination(YankeeRunner1BenchMarker.transform.position);
                Runner2Agent.SetDestination(YankeeRunner2BenchMarker.transform.position);
                Runner3Agent.SetDestination(YankeeRunner3BenchMarker.transform.position);
                Runner4Agent.SetDestination(YankeeRunner4BenchMarker.transform.position);
                // Clear the bases
                manOnFirst = false;
                manOnSecond = false;
                manOnThird = false;
                manAtHome = false;
               }
            // Set "justMadeContact" bat to false
            Bat.GetComponent<SwingBat>().justMadeContact = false;
            // Set "justHitHomeRun" to false
            homeRunDetectManager.GetComponent<homeRunManagerScript>().justHitHomeRun = false;
        }
        // If 3 strikes ...
        if (Strikes == 3)
        {
            // Out! Add one out to the scoreboard
            Outs += 1;
            // Reset strike and balls
            Strikes = 0;
            Balls = 0;
            // Announce that the batter struck out
            StrikeThreeAudio.Play();
        }
        else if (Balls == 4)
        {
            //Announce that the batter walked
            BallFourAudio.Play();
            // Walk the batter. Runners advance 1 base
            // Switch to walk camera
            mainCamera.SetActive(false);
            walkCamera.SetActive(true);
            // Determine where the runners should move to
            // If no one on...
            if (manOnFirst == false && manOnSecond == false && manOnThird == false)
            {
                //Runner1 is batting. Move Runner1 to firstBase. Start him running at homePlate.
                Runner1.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner1.GetComponent<Runner>().enabled = true;
            }
            // If only man on first...
            else if (manOnFirst == true && manOnSecond == false && manOnThird == false)
            {
                //Runner1 is at firstBase. Move Runner1 to secondBase. Start him running at firstBase.
                Runner1.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "secondBase";
                Runner1.GetComponent<Runner>().enabled = true;
                //Runner2 is batting. Move Runner2 to firstBase. Start him running at homePlate.
                Runner2.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner2.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner2.GetComponent<Runner>().enabled = true;
            }
            // If men on first and second...
            else if (manOnFirst == true && manOnSecond == true && manOnThird == false)
            {
                //Runner1 is at secondBase. Move Runner1 to thirdBase. Start him running at secondBase.
                Runner1.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "thirdBase";
                Runner1.GetComponent<Runner>().enabled = true;
                //Runner2 is at firstBase. Move Runner2 to secondBase. Start him running at firstBase.
                Runner2.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                Runner2.GetComponent<Runner>().baseToRunTo = "secondBase";
                Runner2.GetComponent<Runner>().enabled = true;
                //Runner3 is batting. Move Runner3 to firstBase. Start him running at homePlate.
                Runner3.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner3.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner3.GetComponent<Runner>().enabled = true;
            }
            // If bases loaded ...
            else if (manOnFirst == true && manOnSecond == true && manOnThird == true)
            {
                //Runner1 is at thirdBase. Move Runner1 to homePlate. Start him running at thirdBase.
                Runner1.transform.position = new Vector3(ThirdBase.transform.position.x, 2, ThirdBase.transform.position.z);
                Runner1.GetComponent<Runner>().baseToRunTo = "homePlate";
                Runner1.GetComponent<Runner>().enabled = true;
                //Runner2 is at secondBase. Move Runner2 to thirdBase. Start him running at secondBase.
                Runner2.transform.position = new Vector3(SecondBase.transform.position.x, 2, SecondBase.transform.position.z);
                Runner2.GetComponent<Runner>().baseToRunTo = "thirdBase";
                Runner2.GetComponent<Runner>().enabled = true;
                //Runner3 is at firstBase. Move Runner3 to secondBase. Start him running at firstBase.
                Runner3.transform.position = new Vector3(FirstBase.transform.position.x, 2, FirstBase.transform.position.z);
                Runner3.GetComponent<Runner>().baseToRunTo = "secondBase";
                Runner3.GetComponent<Runner>().enabled = true;
                //Runner4 is batting. Move Runner4 to firstBase. Start him running at homePlate.
                Runner4.transform.position = new Vector3(HomePlate.transform.position.x, 2, HomePlate.transform.position.z);
                Runner4.GetComponent<Runner>().baseToRunTo = "firstBase";
                Runner4.GetComponent<Runner>().enabled = true;
            }
            // Wait 6 seconds
            yield return new WaitForSeconds(5);
            // Switch back to main Camera
            walkCamera.SetActive(false);
            mainCamera.SetActive(true);
            // Reset ball and strike count
            Balls = 0;
            Strikes = 0;
        }
    }

    public void disableAllRunners()
    {
        Runner1.GetComponent<Runner>().enabled = false;
        Runner2.GetComponent<Runner>().enabled = false;
        Runner3.GetComponent<Runner>().enabled = false;
        Runner4.GetComponent<Runner>().enabled = false;
    }

    public void enableAllFielders(string baseToThrowTo)
    {
        //Enable the component so that they field the ball when it is near them
        LeftFielder.GetComponent<Fielder>().enabled = true;
        CenterFielder.GetComponent<Fielder>().enabled = true;
        RightFielder.GetComponent<Fielder>().enabled = true;
        ThirdBaseman.GetComponent<Fielder>().enabled = true;
        Shortstop.GetComponent<Fielder>().enabled = true;
        SecondBaseman.GetComponent<Fielder>().enabled = true;
        FirstBaseman.GetComponent<Fielder>().enabled = true;
        Pitcher.GetComponent<Fielder>().enabled = true;
        Catcher.GetComponent<Fielder>().enabled = true;
        //Cover correct base to throw to
        if (string.Equals(baseToThrowTo, "firstBase"))
        {
            //Tell all fielders to throw the ball to firstBase
            LeftFielder.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            CenterFielder.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            RightFielder.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            ThirdBaseman.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            Shortstop.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            SecondBaseman.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            FirstBaseman.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            Pitcher.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            Catcher.GetComponent<Fielder>().baseToThrowTo = "firstBase";
            //Disable first baseman fielding script
            FirstBaseman.GetComponent<Fielder>().enabled = false;
            //Move first baseman to step on first base
            FirstBasemanAgent.SetDestination(FirstBase.transform.position);
            //Enable the first baseman "CatchBall" component
            FirstBaseman.GetComponent<CatchBall>().enabled = true;
        }
        else if (string.Equals(baseToThrowTo, "secondBase"))
        {
            //Tell all fielders to throw the ball to firstBase
            LeftFielder.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            CenterFielder.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            RightFielder.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            ThirdBaseman.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            Shortstop.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            SecondBaseman.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            FirstBaseman.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            Pitcher.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            Catcher.GetComponent<Fielder>().baseToThrowTo = "secondBase";
            //Disable second baseman fielding script
            SecondBaseman.GetComponent<Fielder>().enabled = false;
            //Move second baseman to step on second base
            SecondBasemanAgent.SetDestination(SecondBase.transform.position);
            //Enable the second baseman "CatchBall" component
            SecondBaseman.GetComponent<CatchBall>().enabled = true;
        }
        else if (string.Equals(baseToThrowTo, "thirdBase"))
        {
            //Tell all fielders to throw the ball to firstBase
            LeftFielder.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            CenterFielder.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            RightFielder.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            ThirdBaseman.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            Shortstop.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            SecondBaseman.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            FirstBaseman.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            Pitcher.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            Catcher.GetComponent<Fielder>().baseToThrowTo = "thirdBase";
            //Disable third baseman fielding script
            ThirdBaseman.GetComponent<Fielder>().enabled = false;
            //Move third baseman to step on third base
            ThirdBasemanAgent.SetDestination(ThirdBase.transform.position);
            //Enable the third baseman "CatchBall" component
            ThirdBaseman.GetComponent<CatchBall>().enabled = true;
        }
        else
        {
            //Tell all fielders to throw the ball to firstBase
            LeftFielder.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            CenterFielder.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            RightFielder.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            ThirdBaseman.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            Shortstop.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            SecondBaseman.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            FirstBaseman.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            Pitcher.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            Catcher.GetComponent<Fielder>().baseToThrowTo = "homePlate";
            //Disable catcher fielding script
            Catcher.GetComponent<Fielder>().enabled = false;
            //Move catcher to step on home plate
            CatcherAgent.SetDestination(HomePlate.transform.position);
            //Enable the catcher "CatchBall" component
            Catcher.GetComponent<CatchBall>().enabled = true;
        }
    }

    public void disableAllFielders()
    {
        //Disable the component so that they wait for next pitch
        LeftFielder.GetComponent<Fielder>().enabled = false;
        CenterFielder.GetComponent<Fielder>().enabled = false;
        RightFielder.GetComponent<Fielder>().enabled = false;
        ThirdBaseman.GetComponent<Fielder>().enabled = false;
        Shortstop.GetComponent<Fielder>().enabled = false;
        SecondBaseman.GetComponent<Fielder>().enabled = false;
        FirstBaseman.GetComponent<Fielder>().enabled = false;
        Pitcher.GetComponent<Fielder>().enabled = false;
        Catcher.GetComponent<Fielder>().enabled = false;
        // Reset their positions so that they return to where they are supposed to be
        playersToPositions();
        // Disable all "CatchBall" components
        FirstBaseman.GetComponent<CatchBall>().enabled = false;
        SecondBaseman.GetComponent<CatchBall>().enabled = false;
        ThirdBaseman.GetComponent<CatchBall>().enabled = false;
        Catcher.GetComponent<CatchBall>().enabled = false;
    }

    public void playersToPositions()
    {
        // Set each player's destination to the position's spot
        LeftFielderAgent.SetDestination(LeftFielderPositionMarker.transform.position);
        CenterFielderAgent.SetDestination(CenterFielderPositionMarker.transform.position);
        RightFielderAgent.SetDestination(RightFielderPositionMarker.transform.position);
        ThirdBasemanAgent.SetDestination(ThirdBasemanPositionMarker.transform.position);
        ShortstopAgent.SetDestination(ShortstopPositionMarker.transform.position);
        SecondBasemanAgent.SetDestination(SecondBasemanPositionMarker.transform.position);
        FirstBasemanAgent.SetDestination(FirstBasemanPositionMarker.transform.position);
        PitcherAgent.SetDestination(PitcherPositionMarker.transform.position);
        CatcherAgent.SetDestination(CatcherPositionMarker.transform.position);
    }
}
