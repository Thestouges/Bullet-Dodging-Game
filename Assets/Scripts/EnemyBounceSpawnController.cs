using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounceSpawnController : MonoBehaviour
{
    public float spawnPerXSecond = 10;
    public GameObject enemy;
    public GameObject aimplayer;
    public float distanceFromCenter = 20;
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
            StartCoroutine("Spawner");
            start = true;
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            GameObject item = Instantiate(enemy);
            var comp = item.GetComponent<FacePlayerController>();
            comp.player = aimplayer;

            float angle = Random.Range(0.0f, Mathf.PI * 2);
            Vector3 point = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0);

            item.transform.position = new Vector3(0, 0, 0) + point * distanceFromCenter;

            yield return new WaitForSeconds(spawnPerXSecond);
        }
    }
}
