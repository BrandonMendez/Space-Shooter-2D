using UnityEngine;
using System.Collections;

public class BossEnhancedGuns : MonoBehaviour {

    public GameObject bullet;
    public AudioClip shootSound;

    public float bulletSpeed;

    Player player;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Shoot", 44, 5);
        player = GameObject.Find("PlayerShip").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player == null)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        
        if(player != null)
        {
            GameObject laser = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            laser.transform.localEulerAngles = new Vector3(180, 0, 0);
            Vector3 direction = player.transform.position - transform.position;
            laser.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }
    }
}
