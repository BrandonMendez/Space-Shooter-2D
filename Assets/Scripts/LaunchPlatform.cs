using UnityEngine;
using System.Collections;

public class LaunchPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
         {
            transform.Translate(new Vector3(0, -20 * Time.deltaTime, 0));
         }
	}


}
