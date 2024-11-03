using UnityEngine;

public class Rotator
{
    private Transform _transform;

    public Rotator(Transform transform)
    {
        _transform = transform;
    }

    public void ForseRotateTo(Vector3 direction)
    {
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _transform.rotation = lookRotation;
    }
}