using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Bullet _bulletPrefab;

    private Character _player;
    private CharacterController _characterController;


    private void Awake()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        GameObject playerInstance = Instantiate(_playerPrefab);
        _player = playerInstance.GetComponent<Character>();
        _characterController = _player.GetComponent<CharacterController>();

        Mover _mover = new Mover(_speedPlayer, _characterController);
        Rotator _rotator = new Rotator(_player.transform);
        Shoter  _shoter = new Shoter(_bulletPrefab, _player.ShotPosition);

        _player.Initialize(_mover, _rotator, _shoter);
    }
}
