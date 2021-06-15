using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixeye.Unity;

public class SpawnPlatforms : MonoBehaviour
{
    [Foldout("Obstacle Setup", true)]
    [SerializeField] GameObject obstacle;
    [SerializeField] string obstacleTagName; // Set the tag to be the one of your obstacle ( Ideally 'Obstacle', duh :) ) 
    [SerializeField] float obstacleMoveSpeed;

    [Foldout("Spawner Setup", true)]
    [SerializeField] GameObject endPoint; // Set this to be the point your obstacle will move towards
    [Range(0, 10)]
    [SerializeField] float spawnRate; // After how many seconds the spawner will instantiate an obstacle
    [SerializeField] float minHeight = 0;
    [SerializeField] float maxHeight = 0;

    float obstacleHeight;
    float multiplierTimer;
    bool timerIsRunning;

    public static SpawnPlatforms instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        multiplierTimer = spawnRate;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (multiplierTimer > 0)
            {
                multiplierTimer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");

                obstacleHeight = Random.Range(minHeight, maxHeight);

                multiplierTimer = spawnRate;
                var newObstacle = Instantiate(obstacle, new Vector3(gameObject.transform.position.x, obstacleHeight), Quaternion.identity);
            }
        }

    }

    private void FixedUpdate()
    {
        foreach (var obstacle in GameObject.FindGameObjectsWithTag(obstacleTagName))
        {
            obstacle.transform.position = Vector3.MoveTowards(obstacle.transform.position, new Vector3(endPoint.transform.position.x, obstacle.transform.position.y), obstacleMoveSpeed * Time.deltaTime);

            if (obstacle.transform.position.x == endPoint.transform.position.x)
            {
                Destroy(obstacle);
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void DestroyPlatforms()
    {
        timerIsRunning = false;

        foreach (var platform in GameObject.FindGameObjectsWithTag(obstacleTagName))
        {
            Destroy(platform);
        }
    }
}
