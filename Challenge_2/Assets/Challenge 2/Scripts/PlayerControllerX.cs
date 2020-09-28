using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float fireRate = 1; // time the player has to wait to fire again
    private float nextFire = 0; // time since start after which player can fire agai

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            print(nextFire);
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
