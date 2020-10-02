using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 3f;
    private float repeatRate = 2.5f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[prefabIndex], spawnPos, obstaclePrefabs[prefabIndex].transform.rotation);
        }
    }
}
