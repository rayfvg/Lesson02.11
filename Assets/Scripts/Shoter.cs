using UnityEngine;

public class Shoter 
{
    private Bullet _bullet;
    private Transform _shotPosition;

    public Shoter(Bullet bullet, Transform shotPosition)
    {
        _bullet = bullet;
        _shotPosition = shotPosition;
    }

    public void Shot()
    {
        Bullet bullet = Object.Instantiate(_bullet, _shotPosition.position, _shotPosition.rotation);
        Object.Destroy(bullet.gameObject, 1f);
    }
}