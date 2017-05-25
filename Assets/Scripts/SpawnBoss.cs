using UnityEngine;
using System.Collections;

public class SpawnBoss : MonoBehaviour {

    bool moveRight = true;
    bool summonBoss = false;

    public AudioClip barrierDown;
    public GameObject winMenu;
    public GameObject loseMenu;

    private Barrier barrier;
    private SpawnLocation spawner1;
    private SpawnLocation2 spawner2;
    private ScrollingBackground background;

    // Use this for initialization
    void Start () {
        barrier = GameObject.Find("Barrier").GetComponent<Barrier>();
        transform.localEulerAngles = new Vector3(180, 0, 0);

        spawner1 = GameObject.Find("BasicSpawner").GetComponent<SpawnLocation>();
        spawner2 = GameObject.Find("EnhancedSpawner").GetComponent<SpawnLocation2>();
        background = GameObject.Find("MovingBackground").GetComponent<ScrollingBackground>();
        StartCoroutine(SummonBoss());
    }
	
	// Update is called once per frame
	void Update () {
        if (summonBoss == true)
        {
            if (transform.position.x >= 3.5f)
            {
                moveRight = false;
            }
            if (transform.position.x <= -3.5f)
            {
                moveRight = true;
            }
            MoveShip();
        }

        if(transform.childCount <= 0)
        {
            Win(); 
        }
    }

    void MoveShip()
    {
        if (transform.position.y >= 2.2f)
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        if (moveRight)
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
    }

    IEnumerator SummonBoss()
    {
        yield return new WaitForSeconds(30); //going to be put to 30
        gameObject.SetActive(true);
        Destroy(spawner1.gameObject);
        Destroy(spawner2.gameObject);
        background.SetSpeed(2);
        yield return new WaitForSeconds(3);
        background.SetSpeed(0);
        summonBoss = true;
        yield return new WaitForSeconds(7);
        Destroy(barrier.gameObject);
        AudioSource.PlayClipAtPoint(barrierDown, transform.position);
    }

    void Win()
    {
        winMenu.SetActive(true);
        loseMenu.SetActive(false);
    }
}
