using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject m_muzzle;
    [SerializeField][Range(0.3f, 1)] private float m_muzzleOffset = 0.5f;
    [SerializeField][Range(0, 10)] private float moveSpeed = 5;

    private Vector3 m_moveDir = Vector3.zero;
    private Vector3 m_muzzleDir = Vector3.zero;


    private void Awake()
    {
        if (m_muzzle == null)
        {
            Debug.LogError("Muzzle is NULL");
        }
    }

    private void Update()
    {
        transform.position += m_moveDir * moveSpeed * Time.deltaTime;
        m_muzzle.transform.position = transform.position + m_muzzleDir * m_muzzleOffset;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
            return;

        m_moveDir = context.ReadValue<Vector2>();

        if (m_moveDir != Vector3.zero)
            m_muzzleDir = m_moveDir;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
            return;

        

    }
}