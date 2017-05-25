using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
    public AudioClip powerUpSound;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 1.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<Player>())
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
        }
    }
}
