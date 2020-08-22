using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject[] obstacleArray;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 4.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("SpawnObstacle", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            obstaclePrefab = obstacleArray[Random.Range(0, 4)];
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
            Invoke("SpawnObstacle", Random.Range(0.8f, 2.5f));
        }
    }



}
