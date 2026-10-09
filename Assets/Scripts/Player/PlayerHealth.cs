using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    private ObjectHealth health;


    private void Awake()
    {
        if(healthSlider == null)
        {
            Debug.LogError("healthSlider is NULL");
        }
        health = new ObjectHealth(100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            health.TakeDamage(10);
            healthSlider.value = health.CurrentHP / health.MaxHP;
            if(health.isDead)
            {
                gameObject.SetActive(false);
            }
        }
    }
}