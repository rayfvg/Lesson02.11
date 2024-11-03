using UnityEngine;

public class Mover
{
    private float _speed;
    private CharacterController _characterController;

    public Mover(float speed, CharacterController characterController)
    {
        _speed = speed;
        _characterController = characterController;
    }

    public void MoverTo(Vector3 direcrion)
    {
        Vector3 velocity = direcrion.normalized * _speed;
        _characterController.Move(velocity * Time.deltaTime);
    }
}