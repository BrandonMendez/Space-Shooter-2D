using UnityEngine;
using System.Collections;

public class SpawnLocation : MonoBehaviour {
    public GameObject basicEnemenyFormation;
    

	// Use this for initialization
	void Start () {
       InvokeRepeating("RandomlySpawnBasicEnemies", 4, 1.5f);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void RandomlySpawnBasicEnemies()
    {
        float xNew = Random.Range(-4f, 4f);
        Vector3 spawn = new Vector3(xNew, transform.position.y, 0);
        transform.position = spawn;

        GameObject newFormation = Instantiate(basicEnemenyFormation, transform.position, Quaternion.identity) as GameObject;
    }

}
