using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerController : MonoBehaviour
{
    public float timeBetweenSpawners = 10;
    public List<GameObject> enemyspawners;
    public GameObject player;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        start = false;
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            StartCoroutine("SpawnSpawner");
            start = true;
        }
    }

    IEnumerator SpawnSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawners);

            int i = Random.Range(0, enemyspawners.Count);

            GameObject spawner = Instantiate(enemyspawners[i]);

            if(spawner.GetComponent<EnemyMineSpawnController>() != null)
            {
                spawner.GetComponent<EnemyMineSpawnController>().aimplayer = player;
            }
            if (spawner.GetComponent<EnemyBounceSpawnController>() != null)
            {
                spawner.GetComponent<EnemyBounceSpawnController>().aimplayer = player;
            }
            if (spawner.GetComponent<EnemyLineSpawnController>() != null)
            {
                spawner.GetComponent<EnemyLineSpawnController>().aimplayer = player;
            }
        }
    }
}
