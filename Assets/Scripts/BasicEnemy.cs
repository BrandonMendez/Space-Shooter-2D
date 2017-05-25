using UnityEngine;
using System.Collections;

public class BasicEnemy : MonoBehaviour {
    public GameObject bullet;
    public float bulletSpeed = 5f;
    public float bulletPerSecond = 0.5f;
    public float rateOfFire;
    int points = 100;

    public GameObject explossion;
    public AudioClip bulletSound;
    public AudioClip deathSound;

    private Score score;

	// Use this for initialization
	void Start () {
         score = GameObject.Find("Score").GetComponent<Score>();
	}

    // Update is called once per frame
    void Update()
    {
        rateOfFire = Time.deltaTime * bulletPerSecond;
        if (Random.value < rateOfFire)
        { 
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject laser = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletSpeed);
        AudioSource.PlayClipAtPoint(bulletSound, transform.position);
    }

    void Explode()
    {
        GameObject explode = Instantiate(explossion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.gameObject.GetComponent<Bullet>())
        {
            Explode();
            Destroy(gameObject);
            score.AddToScore(points);
        }
    }
}
