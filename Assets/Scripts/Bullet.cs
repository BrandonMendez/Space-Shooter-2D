using UnityEngine;
using System.Collections;


public class Bullet : MonoBehaviour {

    int bulletCount = 0;
    float bulletSpeed = 10f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetBulletNewPosition(Vector3 newPosition, int bulletCount)
    {
        if (bulletCount == 3)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = newPosition;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed);
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.gameObject.GetComponent<BasicEnemy>() || obj.gameObject.GetComponent<EnhancedEnemy>() || obj.gameObject.GetComponent<GarbageBinBullets>())
        {
            Destroy(gameObject);
        }

        if (obj.gameObject.GetComponent<TopGarbageBulletHell>())
        {
            Vector3 newPosition = new Vector3(transform.position.x, -5f, 0);
            bulletCount += 1;
            SetBulletNewPosition(newPosition, bulletCount);
            if (bulletCount == 3)
                bulletCount = 0;
        }
    }
}
