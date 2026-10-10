using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyController m_enemyPrefab;
    [SerializeField] private Transform m_playerTransform;
    [SerializeField] private int m_maxEnemyCount = 10;
    [SerializeField][Range(1f, 10f)] private float moveSpeed = 1;

    private EnemyController[] enemies = null;


    void Start()
    {
        if (m_enemyPrefab == null)
        {
            Debug.LogError("EnemyPrefab is NULL");
        }

        if (m_playerTransform == null)
        {
            Debug.LogError("PlayerTransform is NULL");
        }

        enemies = new EnemyController[m_maxEnemyCount];

        for (int i = 0; i < m_maxEnemyCount; i++)
        {
            enemies[i] = Instantiate(m_enemyPrefab);
            enemies[i].transform.SetParent(transform);
            enemies[i].SetTarget(m_playerTransform);
            enemies[i].SetMoveSpeed(moveSpeed);
            enemies[i].SetColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
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
            enemies[i].transform.position = center + pos;
            enemies[i].gameObject.SetActive(true);
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
            enemies[i].transform.position = center + pos;
            enemies[i].gameObject.SetActive(true);
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
            enemies[i].transform.position = center + pos;
            enemies[i].gameObject.SetActive(true);
        }
    }
}
