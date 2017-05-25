using UnityEngine;
using System.Collections;

public class Explossion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DestroyAnimation()
    {
        Destroy(gameObject);
    }
}
