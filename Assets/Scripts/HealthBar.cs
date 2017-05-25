using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private float fillAmount;
    [SerializeField]
    private Image healthBar;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = MapToFillAmount(value, 0, MaxValue, 0, 1);
        }
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateHealth();
	}

    void UpdateHealth()
    {
        healthBar.fillAmount = fillAmount;
    }

    float MapToFillAmount(float currentHealth, float minHealth, float maxHealth, float fillMin, float fillMax)
    {
        return (currentHealth - minHealth) * (fillMax - fillMin) / (maxHealth - minHealth) + fillMin; //take current health and scale it into a value between 0-1
        
    }
}
