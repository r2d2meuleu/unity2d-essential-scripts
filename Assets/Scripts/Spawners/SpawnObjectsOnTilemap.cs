using Pixeye.Unity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnObjectsOnTilemap : MonoBehaviour
{
    #region This setting is not necessary, it's something else to have, if you dont like it the function to spawn enemies is pubblic, so its accessible everywhere
    [Header("Spawn Timers")]
    [SerializeField] bool startCountdown = true;
    [SerializeField] float timerCountdown = 4;
    float multiplierTimer;
    #endregion

    [Foldout("Enemies Settings", true)]
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int nMinOfEnemies;
    [SerializeField] private int nMaxOfEnemies;
    [SerializeField] private int maxEnemyCount;
    int totalEnemiesActive;

    [Foldout("Tiles and Spawn Lists", true)]
    [SerializeField] private Tilemap tilemapToScan;
    [SerializeField] private List<Vector3> availablePlacesForEnemies;
    [SerializeField] List<Vector3> enemySpawnPosition = new List<Vector3>();

    private int nOfEnemiesToSpawn;

    private void Start()
    {
        FindLocationsOfTilesToSpawnEnemies();

        multiplierTimer = timerCountdown;
    }

    private void Update()
    {
        #region This is to demonstrate how the spawner works, you could attach a Collider2D to this gameObject and call the 'SpawnObject' function from there, this is just an input

        if (startCountdown)
        {
            if (multiplierTimer > 0)
            {
                multiplierTimer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");

                if (totalEnemiesActive <= maxEnemyCount) SpawnEnemy();

                multiplierTimer = timerCountdown;

            }
        }

        #endregion
    }

    public void StartSpawning()
    {
        startCountdown = true;
    }

    public void StopSpawning()
    {
        startCountdown = false;
    }

    /// <summary>
    /// Scan the selected tilemap and get its single tiles' positions
    /// </summary>
    public void FindLocationsOfTilesToSpawnEnemies()
    {
        availablePlacesForEnemies = new List<Vector3>(); // create a new list of vectors by doing...

        for (int n = tilemapToScan.cellBounds.xMin; n < tilemapToScan.cellBounds.xMax; n++) // scan from left to right for tiles
        {
            for (int p = tilemapToScan.cellBounds.yMin; p < tilemapToScan.cellBounds.yMax; p++) // scan from bottom to top for tiles
            {
                Vector3Int localPlace = new Vector3Int(n, p, (int)tilemapToScan.transform.position.y); // if you find a tile, record its position on the tile map grid
                Vector3 place = tilemapToScan.CellToWorld(localPlace); // convert this tile map grid coords to local space coords
                if (tilemapToScan.HasTile(localPlace))
                {
                    //Tile at "place"
                    availablePlacesForEnemies.Add(place);
                }
                else
                {
                    Debug.Log("No tile at place");
                }
            }
        }
    }

    /// <summary>
    /// Spawns a random GameObject from the variable 'enemyPrefab' inside the 'tilemapToScan'
    /// </summary>
    public void SpawnEnemy()
    {
        enemySpawnPosition.Clear();
        nOfEnemiesToSpawn = Random.Range(nMinOfEnemies, nMaxOfEnemies);
        totalEnemiesActive += nOfEnemiesToSpawn;

        for (int i = 0; i < nOfEnemiesToSpawn; i++)
        {
            enemySpawnPosition.Add(availablePlacesForEnemies[Random.Range(0, availablePlacesForEnemies.Count)]);
        }
        for (int i = 0; i < enemySpawnPosition.Count; i++)
        {
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], new Vector3(enemySpawnPosition[i].x + 0.5f, enemySpawnPosition[i].y + 0.5f, enemySpawnPosition[i].z), Quaternion.identity);
        }
    }
}