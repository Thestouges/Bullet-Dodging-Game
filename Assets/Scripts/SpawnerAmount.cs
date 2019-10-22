using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnerAmount : MonoBehaviour
{
    public int totalSpawners;
    public List<GameObject> spawners;
    // Start is called before the first frame update
    void Start()
    {
        totalSpawners = 0;
    }

    // Update is called once per frame
    void Update()
    {
        totalSpawners = GameObject.FindGameObjectsWithTag("Spawner").Length;
        GetComponent<Text>().text = "Total Spawners: " + totalSpawners;
    }
}
