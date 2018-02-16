using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley : MonoBehaviour {

    bool canPull;

	// Use this for initialization
	void Start () {
        canPull = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(canPull)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Fire").GetComponent<FireHandler>().FireOn();
                GameObject.Find("Balloon").GetComponent<BalloonManager>().SetVerticalVel(5);
                GameObject.Find("EventSystem").GetComponent<UIManager>().HideEButton();
                canPull = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("EventSystem").GetComponent<UIManager>().ShowEButton();
            canPull = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("EventSystem").GetComponent<UIManager>().HideEButton();

            canPull = false;
        }
    }
}
