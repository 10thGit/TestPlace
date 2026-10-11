using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyController m_enemyPrefab;
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private int m_maxEnemyCount = 10;

    private EnemyController[] m_enemies = null;


    void Start()
    {
        if (m_enemyPrefab == null)
        {
            Debug.LogError("EnemyPrefab is NULL");
            return;
        }

        if (m_playerTransform == null)
        {
            Debug.LogError("PlayerTransform is NULL");
            return;
        }

        m_enemies = new EnemyController[m_maxEnemyCount];

        for (int i = 0; i < m_maxEnemyCount; i++)
        {
            m_enemies[i] = Instantiate(m_enemyPrefab);
            m_enemies[i].transform.SetParent(transform);
            m_enemies[i].SetTarget(m_playerTransform);
            m_enemies[i].SetColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        }


        int spawnValue = Random.Range(0, 3);
        Debug.Log(spawnValue);

        switch (spawnValue)
        {
            case 0:
                EnemySpawn1();
                break;
            case 1:
                EnemySpawn2();
                break;
            case 2:
                EnemySpawn3();
                break;
            default:
                break;
        }
    }

    public void EnemySpawn1()
    {
        float offset = (2 * Mathf.PI) / (float)m_maxEnemyCount;
        float angle = 0;
        float radius = 8;

        Vector3 center = m_playerTransform.position;

        for (int i = 0; i < m_maxEnemyCount; i++)
        {
            angle += offset;
            var pos = new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius, 0);
            m_enemies[i].transform.position = center + pos;
            m_enemies[i].gameObject.SetActive(true);
        }
    }

    public void EnemySpawn2()
    {
        int width = Random.Range(1, m_maxEnemyCount / 3 + 1);
        int height = Mathf.CeilToInt((float)m_maxEnemyCount / width);
        int distance = 5;

        Vector3 center = m_playerTransform.position;

        for (int i = 0; i < m_maxEnemyCount; i++)
        {
            int x = i % width;
            int y = i / width;
            Vector3 pos = new Vector3(distance - x, y - (height - 1) / 2f, 0);
            m_enemies[i].transform.position = center + pos;
            m_enemies[i].gameObject.SetActive(true);
        }
    }

    public void EnemySpawn3()
    {
        int width = Random.Range(1, m_maxEnemyCount / 3 + 1);
        int height = Mathf.CeilToInt((float)m_maxEnemyCount / width);
        int distance = -5;

        Vector3 center = m_playerTransform.position;

        for (int i = 0; i < m_maxEnemyCount; i++)
        {
            int x = i % width;
            int y = i / width;
            Vector3 pos = new Vector3(distance - (width - 1) + x, y - (height - 1) / 2f, 0);
            m_enemies[i].transform.position = center + pos;
            m_enemies[i].gameObject.SetActive(true);
        }
    }
}
