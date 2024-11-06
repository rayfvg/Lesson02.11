using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private RulesVictories _rulesVictories;
    [SerializeField] private RulesDefeats _rulesDefeats;

    [SerializeField] private float _speedPlayer;

    [SerializeField] private GameManager _gameManager;

    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private EnemyConteiner _enemyConteiner;

    [SerializeField] private EnemySpawner[] _enemySpawners;

    private Character _player;
    private CharacterController _characterController;


    private void Awake()
    {
        InitializePlayer();
        _gameManager.InitializeRules(CreateLoseRules(), CreateWinRules());
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

    private IRules CreateWinRules()
    {
        switch (_rulesVictories)
        {
            case RulesVictories.TimeOver:
                return new TimeOver(5, _gameManager);

            case RulesVictories.KillEnoughtEnemy:
                return new KillCounter(_enemySpawners, 10);

            default:
                return null;
        }
    }

    private IRules CreateLoseRules()
    {
        switch (_rulesDefeats)
        {
            case RulesDefeats.PlayerDie:
                return new PLayerDie(_player);

            case RulesDefeats.CaptureArena:
                return new CaptureArena(_enemyConteiner.Enemies, _gameManager, 10);

            default:
                return null;
        }
    }
}