using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounceController : MonoBehaviour
{
    public float speed = 0.1F;
    public GameObject bullettype;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collide");
        if (collision.gameObject.tag == "Arena")
        {
            spawnBullets();
            Destroy(this.gameObject);
        }
    }

    public void spawnBullets()
    {
        GameObject item = Instantiate(bullettype, transform.position, transform.rotation);
        Vector3 rotation = new Vector3(180, 180, 0);
        item.transform.eulerAngles += rotation;
        //item.GetComponent<ShootTargetController>().target = player;
    }
}
