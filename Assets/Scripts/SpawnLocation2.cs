using UnityEngine;
using System.Collections;

public class SpawnLocation2 : MonoBehaviour {
    public GameObject enhancedEnemyFormation;

    // Use this for initialization
    void Start () {
        InvokeRepeating("RandomlySpawnEnchancedEnemies", 10, 8);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void RandomlySpawnEnchancedEnemies()
    {
        Vector3 spawn;
        float xNew = Random.Range(1f, 3f);
        if(xNew >= 2f)
        {
             spawn = new Vector3(2f, transform.position.y, 0);
        }
        else
        {
             spawn = new Vector3(-1.7f, transform.position.y, 0);
        }

        transform.position = spawn;
        GameObject newFormation = Instantiate(enhancedEnemyFormation, transform.position, Quaternion.identity) as GameObject;
    }
}
