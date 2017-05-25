using UnityEngine;
using System.Collections;

public class EnhancedEnemy : MonoBehaviour {
    public float bulletSpeed = 5f;
    public float bulletPerSecond = 0.9f;
    public float rateOfFire;
    int points = 200;
    public float movementSpeed;
    public float movementAmplitude;
    public float movementFrequency;

    public Transform targetPosition;
    public GameObject bullet;
    public GameObject explossion;
    public AudioClip bulletSound;
    public AudioClip deathSound;

    private float startTime;

    private Vector3 direction;
    private Vector3 orthogonal;
    private Score score;

    // Use this for initialization
    void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();

        startTime = Time.time;
        direction = (targetPosition.position - transform.position).normalized;
        orthogonal = new Vector3(-direction.x, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        float time = Time.time - startTime;
        transform.position += direction * movementSpeed + orthogonal * movementAmplitude * Mathf.Sin(movementFrequency * time);

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
