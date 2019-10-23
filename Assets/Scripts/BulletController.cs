using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletDespawnInSeconds;
    public int bounces = 0;
    float spawntime;
    public float bulletspeed = 20;
    int wallbounced = 0;
    void Start()
    {
        spawntime = Time.unscaledTime;

        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.up;
        if (Time.unscaledTime - spawntime >= BulletDespawnInSeconds && bounces >= 0)
        {
            Destroy(this.gameObject);
        }
        if (bounces > 0)
        {
            spawntime = Time.unscaledTime;
            Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            if (transform.position.x > stageDimensions.x && wallbounced != 1)
            {
                Vector3 rotation = new Vector3(0, 180, 0);
                transform.eulerAngles += rotation;
                GetComponent<Rigidbody2D>().angularVelocity = 0;
                GetComponent<Rigidbody2D>().velocity = transform.up*bulletspeed;
                wallbounced = 1;
                bounces--;
            }
            if (transform.position.y > stageDimensions.y && wallbounced != 2)
            {
                Vector3 rotation = new Vector3(180, 0, 0);
                transform.eulerAngles += rotation;
                GetComponent<Rigidbody2D>().angularVelocity = 0;
                GetComponent<Rigidbody2D>().velocity = transform.up * bulletspeed;
                wallbounced = 2;
                bounces--;
            }
            if (transform.position.x < stageDimensions.x - Camera.main.orthographicSize * 4 && wallbounced != 3)
            {
                Vector3 rotation = new Vector3(0, 180, 0);
                transform.eulerAngles += rotation;
                GetComponent<Rigidbody2D>().angularVelocity = 0;
                GetComponent<Rigidbody2D>().velocity = transform.up * bulletspeed;
                wallbounced = 3;
                bounces--;
            }
            if (transform.position.y < stageDimensions.y - Camera.main.orthographicSize * 2 && wallbounced != 4)
            {
                Vector3 rotation = new Vector3(180, 0, 0);
                transform.eulerAngles += rotation;
                GetComponent<Rigidbody2D>().angularVelocity = 0;
                GetComponent<Rigidbody2D>().velocity = transform.up * bulletspeed;
                wallbounced = 4;
                bounces--;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject score = GameObject.Find("ScoreCounter");

            float time = score.GetComponent<ScoreController>().score;
            //Debug.Log("touched player");
            SaveGame.Save<float>("score", time);
            SceneManager.LoadScene("MainMenu");   
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Player Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
