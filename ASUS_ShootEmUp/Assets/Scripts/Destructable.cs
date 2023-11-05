using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionSmol;

    public int maxHealth;
    public int currentHealth;

    bool canBeDestroyed = false;

    [SerializeField] private AudioSource boomSFX;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 17f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            Gun[] guns = transform.GetComponentsInChildren<Gun>();
            foreach (Gun gun in guns)
            {
                gun.isActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        Bullets bullet = collision.GetComponent<Bullets>();
        if (bullet != null)
        {
            if (!bullet.isEnemy)
            {
                currentHealth -= 1;

                if (explosionSmol != null)
                {
                    Instantiate(explosionSmol, transform.position, Quaternion.identity);
                }

                if (explosion != null)
                {
                    if (currentHealth == 0)
                    {
                        MoveRightLeft movespeed = GetComponent<MoveRightLeft>();
                        if (movespeed != null)
                        {
                            movespeed.moveSpeeed = 0f;
                        }
                        GetComponent<SpriteRenderer>().enabled = false;

                        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
                        if (boxCollider != null)
                        {
                            boxCollider.isTrigger = false;
                            boxCollider.enabled = false;
                        }
                        Instantiate(explosion, transform.position, Quaternion.identity);
                        boomSFX.Play();
                        Destroy(gameObject, 1f);
                        Destroy(bullet.gameObject);
                    }
                }
                
                //StartCoroutine(DestroyDestructable(bullet.gameObject));
                
                

            }
        }
    }
}