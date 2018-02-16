using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutManager : MonoBehaviour {

    public bool tutEnabeled;
    public Text tutText;
    public float textResetSpeed;
    public GameObject gameManager;

    float timer;

    int tutStage;
	// Use this for initialization
	void Start () {
        tutEnabeled = false;
        tutText.gameObject.SetActive(false);
        tutText.text = "Use WASD to move.";
        tutStage = 0;
    }
	
    public void StartWithTut()
    {
        gameManager.GetComponent<GameManager>().setTimeScaleNormal();
        gameManager.GetComponent<GameManager>().OnStart();
        tutEnabeled = true;
        tutText.text = "Use WASD to move.";
        
    }

	// Update is called once per frame
	void Update () {
        if (!tutEnabeled)
        {
            return;
        }
        tutText.gameObject.SetActive(true);
        timer += Time.deltaTime;
        if (timer > textResetSpeed && tutStage == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                tutText.text = "Walk towards a toy on the floor and press E to pick it up.";
                tutStage++;
                timer = 0;
            }

        }
        else if (timer > textResetSpeed && tutStage == 1 && Input.GetKeyDown(KeyCode.E))
        {

            tutText.text = "You can walk around with toys you have picked up.";
            tutStage++;
            timer = 0;
        }
        else if (timer > textResetSpeed && tutStage == 2)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                tutText.text = "You can drop toys by clicking E again.";
                tutStage++;
                timer = 0;
            }
        }
        else if (timer > textResetSpeed && Input.GetKeyDown(KeyCode.E) && tutStage == 3)
        {
            tutText.text = "Hide toys in places where mum won't find them and take them away.";
            tutStage++;
            timer = 0;
        }
        else if (timer > textResetSpeed && tutStage == 4 && Input.GetKeyDown(KeyCode.W))
        {
            tutText.text = "You can also throw toys by pressing Q while holding them";
            tutStage++;
            timer = 0;
        }
        else if (timer > textResetSpeed && tutStage == 5 && Input.GetKey(KeyCode.Q))
        {
            tutText.text = "You can jump with space and sprint with left shift too!";
            timer = 0;
            tutStage++;
        }
        else if(timer > textResetSpeed && tutStage == 6 && Input.GetKey(KeyCode.W))
        {
            tutText.text = "Enjoy your time here, and good luck!";
            tutStage++;
            timer = 0;
        }
        else if (timer > textResetSpeed * 4 && tutStage >= 7)
        {
            tutText.gameObject.SetActive(false);
            tutEnabeled = false;
        }

	}
}
