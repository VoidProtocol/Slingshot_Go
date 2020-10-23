using UnityEngine;

public class ShootBall : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float _force;
    [SerializeField] private Vector3 _gravity;
    
    private Rigidbody _rb;
    void Awake()
    {
        if (TryGetComponent(out _rb))

        _rb = GetComponent<Rigidbody>();
        Physics.gravity = _gravity;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            _rb.velocity = Vector3.forward * _force * Time.deltaTime;
            _rb.useGravity = true;
        }

        if (Input.touchCount > 0)
        {
            _rb.velocity = Vector3.forward * _force * Time.deltaTime;
            _rb.useGravity = true;
        }
    }
}
