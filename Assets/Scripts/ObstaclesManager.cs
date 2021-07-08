using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    private const float REMOVE_OBSTACLE_AT_X = -13f;
    private const float SPAWN_OBSTACLE_AT_X = 8f;
    private const float SPAWN_OBSTACLE_MIN_Y = 11f;
    private const float SPAWN_OBSTACLE_MAX_Y = 19f;

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float obstacleSpeed;
    [SerializeField] private float spawnObstacleInterval;

    private List<GameObject> obstacles = new List<GameObject>();


    void Start()
    {
        StartCoroutine(SpawnObstaclesRepetitively());
    }

    void Update()
    {
        if(playerController.IsGameOver == true)
        {
            return; 
        }

        for (int i = 0; i < obstacles.Count; i++)
        {
            obstacles[i].transform.position += new Vector3(-obstacleSpeed, 0, 0) * Time.deltaTime;

            if (obstacles[i].transform.position.x <= REMOVE_OBSTACLE_AT_X)
            {
                Destroy(obstacles[i].gameObject);
                obstacles.RemoveAt(i);

                break;
            }
        }  
    }


    public IEnumerator SpawnObstaclesRepetitively()
    {
        while (true)
        {
            if (playerController.PlayerClickedForTheFirstTime == true)
            {
                break;
            }

            yield return null;
        }

        SpawnObstacle();

        while (true)
        {
            yield return new WaitForSeconds(spawnObstacleInterval);

            if (playerController.IsGameOver == true)
            {
                yield break;
            }

            SpawnObstacle();
        }

    }

    private void SpawnObstacle()
    {
        float randomY = Random.Range(SPAWN_OBSTACLE_MIN_Y, SPAWN_OBSTACLE_MAX_Y);
        var obstacle = Instantiate(obstaclePrefab, new Vector2(SPAWN_OBSTACLE_AT_X, randomY), new Quaternion(0, 0, 0, 0));
        obstacles.Add(obstacle);
    }


}
