using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject m_healthPrefab;
    private Slider m_healthSlider;
    private HealthData m_health;


    private void Awake()
    {
        if (m_healthPrefab == null)
        {
            Debug.LogError("HealthPrefab is NULL");
            return;
        }

        m_healthSlider = Instantiate(m_healthPrefab, transform).GetComponentInChildren<Slider>();
        if (m_healthSlider == null)
        {
            Debug.LogError("HealthSlider is NULL");
            return;
        }

        m_health = new HealthData(100);
    }

    private void OnCollisionEnter2D(Collision2D pCollision)
    {
        if (pCollision.transform.CompareTag("Bullet"))
        {
            m_health.TakeDamage(10);
            m_healthSlider.value = m_health.CurrentHP / m_health.MaxHP;
            if (m_health.IsDead)
            {
                gameObject.SetActive(false);
            }
        }
    }
}