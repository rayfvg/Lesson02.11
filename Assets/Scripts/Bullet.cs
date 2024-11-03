using UnityEngine;

public class Bullet: MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(transform.forward * 100f, ForceMode.Impulse);
    }
}