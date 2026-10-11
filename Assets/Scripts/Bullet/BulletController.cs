using UnityEngine;


public class BulletController : MonoBehaviour
{
    [SerializeField][Range(5, 30)] private float m_moveSpeed = 10f;
    private bool m_fired = false;
    private Vector3 m_moveDir = Vector3.zero;

    public bool readyToMove => !m_fired;


    void Update()
    {
        transform.position += m_moveDir * m_moveSpeed * Time.deltaTime;


        if (transform.position.x > 10 || transform.position.x < -10)
        {
            m_fired = false;
        }
        if (transform.position.y > 5 || transform.position.y < -5)
        {
            m_fired = false;
        }
    }

    public void Fire(Vector3 pFirePosition, Vector3 pFireDirection)
    {
        if (!readyToMove)
            return;
        if (pFireDirection == Vector3.zero)
            return;

        transform.position = pFirePosition;
        m_moveDir = pFireDirection;

        m_fired = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            m_fired = false;
            gameObject.SetActive(false);
        }
    }
}
