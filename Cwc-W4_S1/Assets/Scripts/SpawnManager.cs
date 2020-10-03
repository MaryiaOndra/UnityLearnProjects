using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 7f;
    private float repeatRate = 2f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
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
