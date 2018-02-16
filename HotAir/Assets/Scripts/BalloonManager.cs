using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour {

    float height;
    float verticalVel;


    const float vertVelDecrementRate = 0.5f;
    const float vertVelMin = -5f;
    const float verVelMax = 5f;

    const float crashHeight = 250;
    const float tooHighHeight = 3000;
	// Use this for initialization
	void Start () {
        height = 500;
        verticalVel = 1.5f;
	}

    public void SetVerticalVel(float newVertVel)
    {
        verticalVel = newVertVel;
    }

    void CheckForGameOver()
    {
        if(height <= crashHeight)
        {
            Debug.Log("YOU CRASHED");
        }else if(height >= tooHighHeight)
        {
            Debug.Log("Holy shit you're so high up wtf xd");
        }
    }

	// Update is called once per frame
	void Update () {

        verticalVel -= (vertVelDecrementRate * Time.deltaTime);

        if(verticalVel <= vertVelMin)
        {
            verticalVel = vertVelMin;
        }else if(verticalVel >= verVelMax)
        {
            verticalVel = verVelMax;
        }

        height += (verticalVel * Time.deltaTime);
        CheckForGameOver();

        GameObject.Find("EventSystem").GetComponent<UIManager>().UpdateHeight(height);
    }
}
