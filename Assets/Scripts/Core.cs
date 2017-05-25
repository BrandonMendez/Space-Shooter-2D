using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour
{
    public GameObject hitExplossion;
    public GameObject deathExplossion;
    public AudioClip hitSound;
    public AudioClip shieldSound;
    public AudioClip deathSound;

    private LeftWing lefty;
    private RightWing righty;
    private Animator animator;

    int hitCounter = 0;
    bool isLeftWingUp, isRightWingUp, isCoreUp;
    bool dead;
    
    // Use this for initialization
    void Start()
    {
        lefty = GameObject.Find("LeftWing").GetComponent<LeftWing>();
        righty = GameObject.Find("RightWing").GetComponent<RightWing>();
        animator = GetComponent<Animator>();
        
        isCoreUp = true;

    }

    void Update()
    {
        CheckWingShieldStatus();
        CoreShieldDown();
    }

    IEnumerator ShieldOut()
    {
        yield return new WaitForSeconds(1);
        isCoreUp = false;
        animator.SetBool("isCoreShieldUp", false);
        AudioSource.PlayClipAtPoint(shieldSound, transform.position);

        yield return new WaitForSeconds(7);
        lefty.ShieldUp();
        righty.ShieldUp();
        isCoreUp = true;
        animator.SetBool("isCoreShieldUp", true);
    }

    void CheckWingShieldStatus()
    {
        isLeftWingUp = lefty.ShieldStatus();
        isRightWingUp = righty.ShieldStatus();
    }

    void CoreShieldDown()
    {
        if(isLeftWingUp == false && isRightWingUp == false && isCoreUp == true)
        {
            StartCoroutine(ShieldOut());
        }
    }

    void KillBoss()
    {
        GameObject explode = Instantiate(deathExplossion, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        Destroy(gameObject);
        Destroy(lefty.gameObject);
        Destroy(righty.gameObject);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.gameObject.GetComponent<Bullet>())
        {
            GameObject hit = Instantiate(hitExplossion, obj.transform.position, Quaternion.identity) as GameObject;
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(collider.gameObject);

            if (isLeftWingUp == false && isRightWingUp == false)
            {
                hitCounter += 1;
                if (hitCounter >= 40)
                {
                    KillBoss();
                }
            }
        }
        
    }
}