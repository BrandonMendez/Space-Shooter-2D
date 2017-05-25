using UnityEngine;
using System.Collections;

public class GarbageBinBullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEntter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.gameObject.GetComponent<Bullet>())
        {
            Destroy(collider.gameObject);
        }
        else
        {
            Debug.Log("something wrong");
        }
    }
}
