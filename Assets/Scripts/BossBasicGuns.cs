using UnityEngine;
using System.Collections;

public class BossBasicGuns : MonoBehaviour {

    public GameObject bullet;
    public AudioClip shootSound;

    public float bulletSpeed = 5f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Shoot", 40.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Shoot()
    {
        GameObject laser = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        laser.transform.localEulerAngles = new Vector3(180, 0, 0);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -bulletSpeed);
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
      
    }
}
