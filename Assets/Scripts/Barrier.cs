using UnityEngine;
using System.Collections;

public class Barrier : MonoBehaviour {

    public GameObject explossion;
    public AudioClip hitSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<Bullet>())
        {
            GameObject explode = Instantiate(explossion, obj.transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(hitSound, obj.transform.position);
            Destroy(collider.gameObject);
        }
    }
}
