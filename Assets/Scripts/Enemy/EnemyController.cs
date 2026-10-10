using UnityEngine;


public class EnemyController : MonoBehaviour
{
    private float m_moveSpeed = 5;
    private Vector3 m_moveDir;
    private Rigidbody2D m_rigidbody2D;
    private Transform m_playerTransform;


    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(Transform pTransform)
    {
        m_playerTransform = pTransform;
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