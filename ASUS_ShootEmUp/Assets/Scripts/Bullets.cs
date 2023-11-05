using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public Vector2 direction = new Vector2(1,0);
    public float speed = 5f;

    public Vector2 velocity;

    public bool isEnemy = false;

    public GameObject explosionSmol;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isEnemy)
        {
            Instantiate(explosionSmol, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }

        if(!collision.CompareTag("Player") && !isEnemy)
        {
            Instantiate(explosionSmol, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.05f);
        }
    }
}
