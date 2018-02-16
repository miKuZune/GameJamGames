using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float TimePerRound;
    public Text timerText;
    public Text saved;
    public Text notSaved;
    public Text Score;
    public RawImage reticle;
    public GameObject view;
    public GameObject endOfRound;
    public GameObject playerPrefab;
    public GameObject InGameUI;
    public GameObject StartScreenUI;
    public GameObject AboutUI;
    float timer;

    public bool roundOver;
    bool firstFrameRoundOver;
    bool hasStarted = false;

    int toysSaved;
    int toysNotSaved;
    int score;

    GameObject[] toys = new GameObject[150];
    GameObject[] toysToDestroy = new GameObject[150];
    GameObject[] toysToMove = new GameObject[150];
	// Use this for initialization
	void Start () {
        timerText.text = "Time left: ";
        timer = TimePerRound;
        
        roundOver = false;
        firstFrameRoundOver = false;
        InGameUI.SetActive(false);
        AboutUI.SetActive(false);
	}
	
    public void setTimeScaleNormal()
    {
        Time.timeScale = 1;
    }

    public void OnAbout()
    {
        AboutUI.SetActive(true);
        StartScreenUI.SetActive(false);
    }

    public void BackFromAbout()
    {
        AboutUI.SetActive(false);
        StartScreenUI.SetActive(true);
    }

    public void Reset()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        for (int i = 0; i < toysToDestroy.Length; i++)
        {
            if(toysToDestroy[i] != null)
            {
                Destroy(toysToDestroy[i].gameObject);
            }
        }

        for (int i = 0; i < toysToMove.Length; i++)
        {
            ToySpawner toys = gameObject.GetComponent<ToySpawner>();
            if (toysToMove[i] != null)
            {
                toysToMove[i].transform.position = toys.PositionPick(toys.lowerPos.position, toys.upperPos.position);
                toysToMove[i].GetComponent<ToyManager>().isSafe = false;
            }
        }
        
        timer = TimePerRound;
        roundOver = false;
        endOfRound.SetActive(false);
        reticle.gameObject.SetActive(true);
        
        player.transform.position = new Vector3(0, 0 + (player.transform.localScale.y), 0);
        player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        
        Camera cam = Camera.main;
        Transform playerCamPos = GameObject.FindGameObjectWithTag("PlayerCamPos").transform;
        cam.transform.position = playerCamPos.transform.position;
        cam.transform.rotation = playerCamPos.rotation;

        firstFrameRoundOver = false;


        cam.transform.rotation = Quaternion.Euler(new Vector3(33.5f, 90, 0));
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<ToySpawner>().SpawnToys();
        toys = GameObject.FindGameObjectsWithTag("Toy");
    }

    public void OnStart()
    {
        Reset();
        StartScreenUI.SetActive(false);
        InGameUI.SetActive(true);
        endOfRound.SetActive(false);
        hasStarted = true;
        Time.timeScale = 1;
        toys = GameObject.FindGameObjectsWithTag("Toy");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void CheckForSafeToys()
    {
        int j = 0, l =0;
        for(int i = 0; i < toys.Length; i++)
        {
            if (toys[i].GetComponent<ToyManager>().isSafe == false && toys[i] != null)
            {
                toysNotSaved++;
                toysToDestroy[j] = toys[i];
                j++;
            }
            else
            {
                toysToMove[l] = toys[i];
                l++;
                toysSaved++;
            }
        }
    }

    void CalculateScore()
    {
        score = score + (toysSaved * 10);
        score = score - (toysNotSaved * 5);

        if(score < 0)
        {
            score = 0;
        }
    }


    void RoundEndUIManager()
    {
        reticle.gameObject.SetActive(false);
        endOfRound.SetActive(true);
        saved.gameObject.SetActive(false);
        notSaved.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);


        if(timer > 1)
        {
            saved.gameObject.SetActive(true);
            saved.text = "" + toysSaved;
        }
        if(timer > 2)
        {
            notSaved.gameObject.SetActive(true);
            notSaved.text = "" + toysNotSaved;
        }
        if(timer > 3)
        {
            Score.gameObject.SetActive(true);
            Score.text = "" + score;
        }
    }

    void MoveCamToOverview()
    {

        Camera cam = Camera.main;

        cam.transform.position = Vector3.MoveTowards(cam.transform.position, view.transform.position, 10.0f * Time.deltaTime);

        cam.transform.rotation = Quaternion.Euler(new Vector3(35, 90, 0));
    }

	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            Time.timeScale = 0;
        }

        if (!roundOver)
        {
            
            timer -= Time.deltaTime;
            float mins = timer / 60;
            string timeToDisplay = "" + mins;

            //timeToDisplay = "" + timeToDisplay[0] + timeToDisplay[1] + timeToDisplay[2] + timeToDisplay[3];
            timerText.text = "Time left: " + timeToDisplay;
            if (timer <= 0)
            {
                roundOver = true;
                CheckForSafeToys();

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponentInChildren<PickupToy>().inCollider = null;
                player.GetComponentInChildren<PickupToy>().currentPickup = null;
                player.GetComponentInChildren<PickupToy>().holding = false;
            }
        }else
        {
            if (!firstFrameRoundOver)
            {
                CalculateScore();
                firstFrameRoundOver = true;
            }
            MoveCamToOverview();
            RoundEndUIManager();
            timer += Time.deltaTime;
            timerText.text = "Out of time.";
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
