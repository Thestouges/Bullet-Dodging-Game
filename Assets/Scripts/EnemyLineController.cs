using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineController : MonoBehaviour
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
            spawnShootTarget();
            Destroy(this.gameObject);
        }
    }

    public void spawnShootTarget()
    {
        GameObject item = Instantiate(bullettype, transform.position, Quaternion.identity);
        item.GetComponent<ShootTargetController>().target = player;
    }
}
