using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    
    public GameObject hitExplossion;
    public AudioClip hitSound;

    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.gameObject.GetComponent<Bullet>())
        {
            GameObject hit = Instantiate(hitExplossion, obj.transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(collider.gameObject);
        }
    }
}