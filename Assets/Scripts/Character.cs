using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform ShotPosition;

    private Vector3 _input;

    private Mover _mover;
    private Rotator _rotator;
    private Shoter _shoter;

    public void Initialize(Mover mover, Rotator rotator, Shoter shoter)
    {
        _mover = mover;
        _rotator = rotator;
        _shoter = shoter;
    }

    private void Update()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (Input.GetMouseButtonDown(0))
        {
            _shoter.Shot();
        }
    }

    private void FixedUpdate()
    {
        if(_input.magnitude > 0.1f)
        {
            _mover.MoverTo(_input);
            _rotator.ForseRotateTo(_input);
        }
    }
}