using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject powerUp;
    public float width = 10f;
    public float height = 5f;
    bool shouldSpawn = false;

    private Score score;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0f, -2f * Time.deltaTime, 0));

        CheckAllDead();
        
    }

    void CheckAllDead()
    {
        foreach (Transform childPosition in transform)
        {
            if (childPosition.childCount > 0)
            {
                shouldSpawn = true; //if there is at least one enemy still alive in that wave
                return;
            }
        }
         if(shouldSpawn == true)
        {
            SpawnPowerUp();
            shouldSpawn = false;
        }
    }

    void SpawnPowerUp()
    {
        GameObject power = Instantiate(powerUp, transform.position, Quaternion.identity) as GameObject;
        score.DoubleScore();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
