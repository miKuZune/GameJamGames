using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuUI : MonoBehaviour {

    public GameObject pauseUI;

	// Use this for initialization
	void Start () {
        pauseUI.SetActive(false);
	}
	
    void OnPause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }



	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
	}
}
