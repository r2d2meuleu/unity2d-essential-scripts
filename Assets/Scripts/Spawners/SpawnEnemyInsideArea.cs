using Pixeye.Unity;
using UnityEditor;
using UnityEngine;

public class SpawnEnemyInsideArea : MonoBehaviour
{
    [field: SerializeField] [field: Range(0.1f, 20)] float RangeOfSpawn { get; set; } = 5; // Define the area where the enemies will spawn

    #region This setting is not necessary, it's something else to have, if you dont like it the function to spawn enemies is pubblic, so its accessible everywhere
    [Foldout("Spawn Timers", true)]
    [SerializeField] bool startCountdown = true;
    [SerializeField] float timerCountdown = 4;
    float multiplierTimer;
    #endregion

    [Foldout("Enemies Settings", true)]
    [SerializeField] GameObject[] enemyToSpawn;
    [SerializeField] private int nMinOfEnemies;
    [SerializeField] private int nMaxOfEnemies;
    [SerializeField] private int maxSpawnableEnemies;
    int totalEnemiesActive;

    private int nOfEnemiesToSpawn;

    void Start()
    {
        multiplierTimer = timerCountdown;
    }

    void Update()
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

                if (totalEnemiesActive <= maxSpawnableEnemies) SpawnObject();

                multiplierTimer = timerCountdown;
            }
        }

        #endregion
    }

    /// <summary>
    /// Spawns a random GameObject from the variable 'enemyToSpawn' inside the 'RangeOfSpawn' area
    /// </summary>
    public void SpawnObject()
    {
        nOfEnemiesToSpawn = Random.Range(nMinOfEnemies, nMaxOfEnemies);
        totalEnemiesActive += nOfEnemiesToSpawn;

        for (int i = 0; i < nOfEnemiesToSpawn; i++)
        {
            Instantiate(enemyToSpawn[Random.Range(0, enemyToSpawn.Length)], new Vector3(Random.Range(transform.position.x, Random.Range(-RangeOfSpawn, RangeOfSpawn)), Random.Range(transform.position.y, Random.Range(-RangeOfSpawn, RangeOfSpawn)), 0), Quaternion.identity);
        }
    }

    // This function draws a circle around the gameObject to give a visual rappresentation of how large the range actually is
    protected void OnDrawGizmos()
    {
        if (Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, RangeOfSpawn);
            Gizmos.color = Color.white;
        }
    }
}
