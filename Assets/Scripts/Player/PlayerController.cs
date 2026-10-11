using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField][Range(0, 10)] private float m_moveSpeed = 5;
    [SerializeField][Range(0.3f, 1)] private float m_muzzleOffset = 0.5f;
    [SerializeField] private GameObject m_muzzle;
    [SerializeField] private BulletManager m_bulletManager;

    private Vector3 m_moveDir = Vector3.zero;
    private Vector3 m_muzzleDir = Vector3.zero;


    private void Awake()
    {
        if (m_muzzle == null)
        {
            Debug.LogError("Muzzle is NULL");
            return;
        }
        if (m_bulletManager == null)
        {
            Debug.LogError("BulletManager is NULL");
            return;
        }
    }

    private void Update()
    {
        transform.position += m_moveDir * m_moveSpeed * Time.deltaTime;
        m_muzzle.transform.position = transform.position + m_muzzleDir * m_muzzleOffset;
    }

    public void OnMove(InputAction.CallbackContext pContext)
    {
        if (pContext.started)
            return;

        m_moveDir = pContext.ReadValue<Vector2>();

        if (m_moveDir != Vector3.zero)
            m_muzzleDir = m_moveDir;
    }

    public void OnFire(InputAction.CallbackContext pContext)
    {
        if (!pContext.performed)
            return;

        m_bulletManager.Fire(transform.position, m_muzzleDir);
    }
}