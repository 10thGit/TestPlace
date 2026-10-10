using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private float m_moveSpeed = 5;
    private Vector3 m_moveDir;
    private Rigidbody2D m_rigidbody2D;
    private Transform m_playerTransform;
    private SpriteRenderer m_spriteRenderer;


    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        if(m_rigidbody2D == null)
        {
            Debug.LogError("Rigidbody2D is NULL");
        }

        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (m_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is NULL");
        }
    }

    public void SetTarget(Transform pTransform)
    {
        m_playerTransform = pTransform;
    }

    public void SetColor(Color color)
    {
        m_spriteRenderer.color = color;
    }

    public void SetMoveSpeed(float pSpeed)
    {
        m_moveSpeed = pSpeed;
    }

    void FixedUpdate()
    {
        if (m_playerTransform == null)
            return;

        m_moveDir = m_playerTransform.position - transform.position;
        m_moveDir.Normalize();

        m_rigidbody2D.MovePosition(transform.position + m_moveDir * m_moveSpeed * Time.deltaTime);
    }
}