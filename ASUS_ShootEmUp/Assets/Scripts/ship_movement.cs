using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship_movement : MonoBehaviour
{
    Gun[] guns;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Health health;
    public int maxHealth = 5;
    public int currentHealth;
    public Animator animator;
    public Death death;

    public GameObject explosion;
    public GameObject explosionSmol;

    private Vector2 moveDirection;
    private bool isInvulnerable = false;
    private float invulnerabilityTime = 2f;

    bool shoot1;
    bool shoot2;

    [SerializeField] private AudioSource boomSFX;

    void Start()
    {
        death = FindObjectOfType<Death>();
        guns = transform.GetComponentsInChildren<Gun>();
        foreach(Gun gun in guns)
        {
            gun.isActive = true;
        }

        currentHealth = maxHealth;
        health.setMaxHealth(maxHealth);
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
        if(transform.position.y >= 8.849f)
        {
            transform.position = new Vector3(transform.position.x, 8.849f,0);
        }
        else if(transform.position.y <= 1.866f)
        {
            transform.position = new Vector3(transform.position.x, 1.866f,0);
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
        if (bullet != null && bullet.isEnemy)
        {
            TakeDamage(bullet.gameObject);
        }

        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null)
        {
            PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
            collider.enabled = false;
            TakeDamage(null);
        }
    }

    private void TakeDamage(GameObject bullet)
    {
        if (isInvulnerable)
        {
            PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
            collider.enabled = false;
            return;
        }

        currentHealth -= 1;
        health.SetHealth(currentHealth);
        if (explosionSmol != null)
        {
            Instantiate(explosionSmol, transform.position, Quaternion.identity);
        }

        isInvulnerable = true;
        animator.SetBool("damage", true);
        Invoke("ResetVulnerability", invulnerabilityTime);
        if (currentHealth <= 0)
        {            
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                boomSFX.Play();
            }
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            Destroy(gameObject, 1f);
            death.GameOver();
        }
    }

    private void ResetVulnerability()
    {
        isInvulnerable = false;
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        collider.enabled = true;
        animator.SetBool("damage", false);
    }
}
