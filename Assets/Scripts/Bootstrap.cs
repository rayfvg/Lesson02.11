using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private RulesVictories _rulesVictories;
    [SerializeField] private RulesDefeats _rulesDefeats;

    [SerializeField] private Enemy _enemy;

    private Character _player;
    private CharacterController _characterController;

    private IRules _rulesDefeat;
    private IRules _rulesVictory;


    private void Awake()
    {
        InitializePlayer();
    }

    private void InitializePlayer()
    {
        GameObject playerInstance = Instantiate(_playerPrefab);
        _player = playerInstance.GetComponent<Character>();
        _characterController = _player.GetComponent<CharacterController>();

        Mover mover = new Mover(_speedPlayer, _characterController);
        Rotator rotator = new Rotator(_player.transform);
        Health health = new Health(30, _player.gameObject);
        Shoter shoter = new Shoter(_bulletPrefab, _player.ShotPosition);

        _player.Initialize(mover, rotator, health, shoter);
    }

    private IRules CreateRules()
    {
        switch (_rulesVictories)
        {
            case RulesVictories.TimeOver:
                return new TimeOver();

            case RulesVictories.KillEnoughtEnemy:
                return new KillCounter(_enemy, 10);

            default:
                return null;
        }
    }

}