using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {

    int dir;
    float windAffect;
    float timeFloating;

    const float timeTillNewDir = 20.5f;
    const float windAffectUpperLimit = 35f;



    void NewWind()
    {
        timeFloating = 0;

        windAffect = Random.Range(0, windAffectUpperLimit);

        float randDir = 0;
        const float randDirLimit = 100;
        randDir = Random.Range(0, randDirLimit);

        if(randDir > 50)
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        windAffect = windAffect * dir;

    }

    // Use this for initialization
    void Start () {
        NewWind();
        timeFloating = 0;
	}
	
	// Update is called once per frame
	void Update () {

        timeFloating += Time.deltaTime;

        if(timeFloating > timeTillNewDir)
        {
            NewWind();
        }

        

        GameObject.Find("Balloon").GetComponent<BalloonManager>().horizontalVel = windAffect;
    }

}
