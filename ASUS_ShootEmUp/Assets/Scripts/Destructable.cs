using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject explosion;

    bool canBeDestroyed = false;

    [SerializeField] private AudioSource boomSFX;
    // Start is called before the first frame update
    void Start()
    {
        
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

                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, Quaternion.identity);
                }
                
                StartCoroutine(DestroyDestructable(bullet.gameObject));
                boomSFX.Play();
                Destroy(bullet.gameObject);
                Destroy(explosion.gameObject);

            }
        }
    }

    IEnumerator DestroyDestructable (GameObject bullet)
    {
        yield return new WaitForSeconds(1.0f);

        Destroy(gameObject);
    }
}