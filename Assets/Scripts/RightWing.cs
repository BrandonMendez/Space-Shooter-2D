using UnityEngine;
using System.Collections;

public class RightWing : MonoBehaviour
{

    public GameObject hitExplossion;
    public AudioClip hitSound;
    public AudioClip shieldSound;

    private Animator animator;
    private Core core;

    int hitCounter = 0;
    bool shieldStatus = true;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        core = GameObject.Find("Core").GetComponent<Core>();
    }

    void Update()
    {
        animator.SetBool("isRightShieldUp", shieldStatus);
        if(ShieldStatus() == false)
        {
            hitCounter = 0;
        }
    }

    void ShieldDown()
    {
        shieldStatus = false;
        AudioSource.PlayClipAtPoint(shieldSound, transform.position);
    }

    public void ShieldUp()
    {
        shieldStatus = true;
    }

    public bool ShieldStatus()
    {
        return shieldStatus;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.gameObject.GetComponent<Bullet>())
        {
            GameObject hit = Instantiate(hitExplossion, obj.transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(collider.gameObject);

            hitCounter += 1;
            if(hitCounter == 25)
            {
                ShieldDown();
                hitCounter = 0;
            }
        }
    }
}