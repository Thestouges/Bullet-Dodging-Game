using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float WallDespawnInSeconds;
    float spawntime;
    // Start is called before the first frame update
    void Start()
    {
        spawntime = Time.unscaledTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime - spawntime >= WallDespawnInSeconds)
        {
            Destroy(this.gameObject);
        }
    }
}
