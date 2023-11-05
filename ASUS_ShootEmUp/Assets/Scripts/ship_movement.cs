using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movement : MonoBehaviour
{
    Gun[] guns;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 moveDirection;

    bool shoot1;
    bool shoot2;

    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        foreach(Gun gun in guns)
        {
            gun.isActive = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        shoot1 = Input.GetKeyDown(KeyCode.Space);
        shoot2 = Input.GetKeyDown(KeyCode.Mouse0);
        
        if (shoot1 || shoot2)
        {
            shoot1 = false;
            shoot2 = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
        if(transform.position.y >= 9.50f)
        {
            transform.position = new Vector3(transform.position.x, 9.50f,0);
        }
        else if(transform.position.y <= 0.54f)
        {
            transform.position = new Vector3(transform.position.x, 0.54f,0);
        }

        if(transform.position.x <= 0.75f)
        {
            transform.position = new Vector3(0.75f,transform.position.y , 0);
        }
        else if(transform.position.x >= 17.01f)
        {
            transform.position = new Vector3(17.01f,transform.position.y , 0);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullets bullet = collision.GetComponent<Bullets>();
        if (bullet != null)
        {
            if (bullet.isEnemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }

        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
