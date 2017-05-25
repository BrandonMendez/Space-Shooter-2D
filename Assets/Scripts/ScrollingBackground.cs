using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {
    float scrollSpeed = 7f;
    public float tileSizeY;

    private Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
        transform.position = startPosition + Vector3.down * newPosition;
	}

    public void SetSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}
