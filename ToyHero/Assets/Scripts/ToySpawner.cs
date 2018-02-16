using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToySpawner : MonoBehaviour {

    public GameObject[] SpawnableToys;

    public Transform lowerPos;
    public Transform upperPos;

    void Start()
    {
        SpawnToys();
    }

    public Vector3 PositionPick(Vector3 lowerLimit, Vector3 upperLimit)
    {
        float xPos, yPos, zPos;
        xPos = Random.Range(lowerLimit.x, upperLimit.x);
        yPos = Random.Range(lowerLimit.y, upperLimit.y);
        zPos = Random.Range(lowerLimit.z, upperLimit.z);


        Vector3 returnable = new Vector3(xPos, yPos, zPos);
        return returnable;
    }

    public void SpawnToys()
    {
        int numToysToSpawn = Random.Range(5, 10);

        for(int i = 0; i < numToysToSpawn; i++)
        {
            int toyToSpawn = Random.Range(0, SpawnableToys.Length);
            Vector3 spawnPos = PositionPick(lowerPos.position, upperPos.position);
            Instantiate(SpawnableToys[toyToSpawn], spawnPos, Quaternion.identity);
        }
    }	
}
