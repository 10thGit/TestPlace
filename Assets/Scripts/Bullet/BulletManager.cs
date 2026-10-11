using UnityEngine;


public class BulletManager : MonoBehaviour
{
    [SerializeField][Range(1, 30)] private int m_maxBulletCount = 10;
    [SerializeField] private BulletController m_bulletPrefab = null;
    
    private BulletController[] m_bullets = null;


    private void Awake()
    {
        if (m_bulletPrefab == null)
        {
            Debug.LogError("BulletPrefab NULL");
            return;
        }

        m_bullets = new BulletController[m_maxBulletCount];

        for (int i = 0; i < m_maxBulletCount; i++)
        {
            m_bullets[i] = Instantiate(m_bulletPrefab);
            m_bullets[i].transform.position = Vector3.zero;
            m_bullets[i].transform.SetParent(transform);
            m_bullets[i].gameObject.SetActive(false);
        }
    }

    public void Fire(Vector3 pStartPos, Vector3 pDirection)
    {
        for (int i = 0; i < m_maxBulletCount; i++)
        {
            if (m_bullets[i].readyToMove)
            {
                m_bullets[i].gameObject.SetActive(true);
                m_bullets[i].Fire(pStartPos, pDirection);
                break;
            }
        }
    }
}
