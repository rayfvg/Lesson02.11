using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Mover _mover;
    private Rotator _rotator;
    private CharacterController _characterController;

    public void Inivcialize(Mover mover, Rotator rotator)
    {
        _mover = mover;
        _rotator = rotator;
    }

    private void FixedUpdate()
    {
        _mover.MoverTo(Vector3.forward);
        _rotator.ForseRotateTo(Vector3.forward);
    }
}
