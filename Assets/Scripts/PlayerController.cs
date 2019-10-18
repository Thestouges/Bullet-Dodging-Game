using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.2F;
    //public GameObject bullet;
    //public float bulletspeed;
    //public GameObject bulletspawnpoint;
    //public GameObject mine;
    //public GameObject spawnshoottarget;
    //public GameObject wallbouncebullet;
    //public Text debugtext;

    float horizontal;
    float vertical;


    bool mousedown;

    // Start is called before the first frame update
    void Start()
    {
        mousedown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);
        }

        float radius = 25/2;
        Vector3 centerPosition = new Vector3(0,0,0); 
        float distance = Vector3.Distance(transform.position, centerPosition); 

        if (distance > radius) 
        {
            Vector3 fromOriginToObject = transform.position - centerPosition; 
            fromOriginToObject *= radius / distance; 
            transform.position = centerPosition + fromOriginToObject; 
        }
    }

    /*
    private void FireBullet()
    {
        GameObject firedbullet = Instantiate(bullet, bulletspawnpoint.transform.position, this.transform.Find("PlayerSprite").transform.rotation);
        firedbullet.GetComponent<Rigidbody2D>().velocity = this.transform.Find("PlayerSprite").transform.up * bulletspeed;
    }

    public void SpawnMine()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        var ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        Vector3 groundedRay = new Vector3(ray.origin.x, ray.origin.y, 0);
        Instantiate(mine, groundedRay, Quaternion.identity);
    }

    public void spawnShootTarget()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        var ray = Camera.main.ScreenPointToRay(new Vector3(x, y, 0));
        Vector3 groundedRay = new Vector3(ray.origin.x, ray.origin.y, 0);
        GameObject item = Instantiate(spawnshoottarget, groundedRay, Quaternion.identity);
        item.GetComponent<ShootTargetController>().target = this.gameObject;
    }

    public void spawnWallBouncBullet()
    {
        GameObject item = Instantiate(wallbouncebullet, bulletspawnpoint.transform.position, this.transform.Find("PlayerSprite").transform.rotation);
        //item.GetComponent<WallBounceBulletController>().border = GameObject.FindGameObjectWithTag("MainCamera");
    }
    */
}