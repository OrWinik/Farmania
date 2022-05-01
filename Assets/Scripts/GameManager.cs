using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] pickUpsSpawn;
    public GameObject[] enemiesSpawn;

    //pickup cooldowns
    public float spawnCooldown = 1f;
    public float spawnCooldownReset = 3f;
    public bool canDecrese = true;
    public float waitForSeconds = 30;

    //enemies cooldown
    public float enemiesSpawnCoolDown = 5f;
    public float enemiesSpawnCoolDownRest = 5f;

    //fallingdown speed
    public GameObject[] allSpawned;

    void Start()
    {
    }

    void Update()
    {
        allSpawned = GameObject.FindGameObjectsWithTag("allSpawned");

        SpawnSystem();

        if(canDecrese == true)
        {
            canDecrese = false;
            StartCoroutine(SpawnCoolDownTimer());
            SpawnCoolDownDecrese();
        }

        FallingDownSpeed();
    }

    public void Spawn()
    {
        if (Time.time > 0 && Time.time <60)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(-4.5f, 5), Random.Range(3, 6), 0);
            Instantiate(pickUpsSpawn[Random.Range(0, 0)], randomSpawn, transform.rotation);
            Debug.Log("first spawn");
        }
        else if (Time.time > 60 && Time.time < 120)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(-4.5f, 5), Random.Range(3, 6), 0);
            int i = Random.Range(0, 2);
            Instantiate(pickUpsSpawn[i], randomSpawn, transform.rotation);
            Debug.Log("second spawn");
            Debug.Log(i);

        }
        else if (Time.time > 120 && Time.time < 180)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(-4.5f, 5), Random.Range(3, 6), 0);
            int i = Random.Range(0, 3);
            Instantiate(pickUpsSpawn[i], randomSpawn, transform.rotation);
            Debug.Log("third spawn");
        }
        else if (Time.time > 180)
        {
            Vector3 randomSpawn = new Vector3(Random.Range(-4.5f, 5), Random.Range(3, 6), 0);
            int i = Random.Range(0, 4);
            Instantiate(pickUpsSpawn[i], randomSpawn, transform.rotation);
            Debug.Log("forth spawn");
        }
        else
            return;

    }

    public void SpawnEnemies()
    {
        Vector3 randomSpawnEnemies = new Vector3(Random.Range(-4.5f, 5), Random.Range(3, 6), 0);
        Instantiate(enemiesSpawn[Random.Range(0,enemiesSpawn.Length)], randomSpawnEnemies, transform.rotation);
    }

    public void SpawnSystem()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown < 0)
        {
            Spawn();
            spawnCooldown = spawnCooldownReset;
        }

        enemiesSpawnCoolDown -= Time.deltaTime;
        if(enemiesSpawnCoolDown <= 0)
        {
            SpawnEnemies();
            enemiesSpawnCoolDown = enemiesSpawnCoolDownRest;
        }
    }

    IEnumerator SpawnCoolDownTimer()
    {
        yield return new WaitForSeconds(waitForSeconds);
        canDecrese = true;
    }

    public void SpawnCoolDownDecrese()
    {
        spawnCooldownReset = spawnCooldownReset / 1.2f;
        enemiesSpawnCoolDownRest = enemiesSpawnCoolDownRest / 1.2f;
        if (waitForSeconds > 10)
        {
            waitForSeconds = waitForSeconds - 1;
        }
    }

    public void FallingDownSpeed()
    {
        if (Time.time > 120 && Time.time < 240)
        {
            Debug.Log("gravity changed : 120");
            for (int i = 0; i < allSpawned.Length; i++)
            {
                Rigidbody2D gravity = allSpawned[i].GetComponent<Rigidbody2D>();
                gravity.gravityScale = 0.2f;

            }
        }
        else if (Time.time > 240 && Time.time < 360)
        {
            Debug.Log("gravity changed : 240");
            for (int i = 0; i < allSpawned.Length; i++)
            {
                Rigidbody2D gravity = allSpawned[i].GetComponent<Rigidbody2D>();
                gravity.gravityScale = 0.3f;

            }
        }
        else if (Time.time > 360)
        {
            Debug.Log("gravity changed : 360");
            for (int i = 0; i < allSpawned.Length; i++)
            {
                Rigidbody2D gravity = allSpawned[i].GetComponent<Rigidbody2D>();
                gravity.gravityScale = 0.5f;

            }
        }
        else
            return;
    }

}
