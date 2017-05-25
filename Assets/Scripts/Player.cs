using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float movementSpeed;
    public float bulletSpeed;
    public int shootingMethod;

    public GameObject bullet;
    public GameObject explossion;
    public GameObject loseMenu;
    public GameObject winMenu;
    public AudioClip bulletSound;
    public AudioClip deathSound;
    public AudioClip hitSound;

    private float instantiationTimer = 0.09f;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        MoveShip();
        ClampToCamera();
	}

    void MoveShip()
    {
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w"))
        {
            transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot(shootingMethod);
        }
    }

    void ClampToCamera()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.03f, 0.97f);
        position.y = Mathf.Clamp(position.y, 0.05f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    void Shoot(int method)
    {
        instantiationTimer -= Time.deltaTime;
        if (shootingMethod == 1)
        {
            if (instantiationTimer <= 0)
            {
                Vector3 initialBullet = new Vector3(transform.position.x, transform.position.y + 0.7f);
                GameObject laser = Instantiate(bullet, initialBullet, Quaternion.identity) as GameObject;
                laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed);
                instantiationTimer = 0.09f;
                AudioSource.PlayClipAtPoint(bulletSound, transform.position);
            }
        }
        if(shootingMethod == 2)
        {
            if (instantiationTimer <= 0)
            {
                float xRight = transform.position.x + 0.2f;
                float xleft = transform.position.x - 0.2f;
                Vector3 rightBullet = new Vector3(xRight, transform.position.y + 0.5f);
                Vector3 leftBullet = new Vector3(xleft, transform.position.y + 0.5f);

                GameObject laser1 = Instantiate(bullet, rightBullet, Quaternion.identity) as GameObject;
                GameObject laser2 = Instantiate(bullet, leftBullet, Quaternion.identity) as GameObject;
                laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed);
                laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed);
                instantiationTimer = 0.09f;
                AudioSource.PlayClipAtPoint(bulletSound, transform.position);
            }
        }
        if (shootingMethod == 3)
        {
            if (instantiationTimer <= 0)
            {
                float xRight = transform.position.x + 0.2f;
                float xleft = transform.position.x - 0.2f;
                Vector3 rightBullet = new Vector3(xRight, transform.position.y + 0.5f);
                Vector3 leftBullet = new Vector3(xleft, transform.position.y + 0.5f);
                Vector3 initialBullet = new Vector3(transform.position.x, transform.position.y + 0.5f);

                GameObject laser1 = Instantiate(bullet, rightBullet, Quaternion.identity) as GameObject;
                GameObject laser2 = Instantiate(bullet, leftBullet, Quaternion.identity) as GameObject;
                GameObject laser3 = Instantiate(bullet, initialBullet, Quaternion.identity) as GameObject;
                laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed, bulletSpeed);
                laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletSpeed, bulletSpeed);
                laser3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed);
                instantiationTimer = 0.09f;
                AudioSource.PlayClipAtPoint(bulletSound, transform.position);
            }
        }
        if(shootingMethod == 4)
        {
            if (instantiationTimer <= 0)
            {
                float xRight = transform.position.x + 0.2f;
                float xleft = transform.position.x - 0.2f;
                Vector3 rightBullet = new Vector3(xRight, transform.position.y + 0.5f);
                Vector3 leftBullet = new Vector3(xleft, transform.position.y + 0.5f);

                GameObject laser1 = Instantiate(bullet, rightBullet, Quaternion.identity) as GameObject;
                GameObject laser2 = Instantiate(bullet, leftBullet, Quaternion.identity) as GameObject;
                GameObject laser3 = Instantiate(bullet, rightBullet, Quaternion.identity) as GameObject;
                GameObject laser4 = Instantiate(bullet, leftBullet, Quaternion.identity) as GameObject;
                laser1.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed, bulletSpeed);
                laser2.GetComponent<Rigidbody2D>().velocity = new Vector3(-bulletSpeed, bulletSpeed);
                laser3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed);
                laser4.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed);
                instantiationTimer = 0.09f;
                AudioSource.PlayClipAtPoint(bulletSound, transform.position);
            }
        }
    }

    void Explode()
    {
        GameObject explode = Instantiate(explossion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    void Die()
    {
        gameObject.SetActive(false);
        loseMenu.SetActive(true);
        winMenu.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.GetComponent<EnemyBullet>() || obj.GetComponent<Bullet>())
        {
            if (obj.GetComponent<Bullet>())
            {
                Destroy(collider.gameObject);
            }
            shootingMethod -= 1;
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            if(shootingMethod <= 0)
            {
              Explode();
              Die();
            }
        }

        if(obj.GetComponent<PowerUp>() && shootingMethod < 4)
        {
            shootingMethod += 1;
        }

        if (obj.gameObject.GetComponent<Core>() || obj.gameObject.GetComponent<LeftWing>() || obj.gameObject.GetComponent<RightWing>())
        {
            Explode();
            Die();
        }
    }
}
