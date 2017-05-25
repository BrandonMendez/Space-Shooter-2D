using UnityEngine;
using System.Collections;

public class GrabageBin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D collider) 
    {
        Destroy(collider.gameObject);
    }

}
