using Controller;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using View;

namespace SpaceInvaders
{
    public sealed class Root : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPlayer;
        [SerializeField] private Transform _spawnEnemies;
        [SerializeField] private DataShip _dataShip;
        [SerializeField] private RulesSpawnEnemy _rulesSpawnEnemy;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _finalMessageText;
        [SerializeField] private Button _buttonRestart;

        private ShipController _shipController;
        private InputController _inputController;
        private SpawnEnemyController _spawnEnemyController;
        private MainUI _mainUI;
        private int _score = 0;

        private bool _isPlay;

        private void Awake()
        {
            _isPlay = true;
            _buttonRestart.gameObject.SetActive(false);
            _finalMessageText.gameObject.SetActive(false);

            var player = Resources.Load<ShipView>("Prefabs/Ship");
            player = Instantiate(player, _spawnPlayer.position, Quaternion.identity);            

            _shipController = new ShipController(_dataShip, player);
            _inputController = new InputController(_shipController);
            _mainUI = new MainUI(_scoreText, _score);
            _spawnEnemyController = new SpawnEnemyController(_spawnEnemies, _rulesSpawnEnemy, _mainUI);

            _buttonRestart.onClick.AddListener(() => 
            {
                SceneManager.LoadSceneAsync(0);
            });

            _spawnEnemyController.AllEnemiesDeath += (() =>
            {
                _isPlay = false;
                _spawnEnemyController.AllDestroy();
                _buttonRestart.gameObject.SetActive(true);
                _finalMessageText.gameObject.SetActive(true);
                _finalMessageText.color = Color.green;
                _finalMessageText.text = "You WIN!!!";
            });

            player.OnDeath += (() =>
            {
                _isPlay = false;
                _buttonRestart.gameObject.SetActive(true);
                _finalMessageText.gameObject.SetActive(true);
                _finalMessageText.color = Color.red;
                _finalMessageText.text = "You loooose!!!";
            });
        }

        private void FixedUpdate()
        {
            if (_isPlay == true)
                _inputController.FixedExecute();
        }

        private void Update()
        {
            _shipController.BoundMove();

            if(_isPlay == true)
                _inputController.Execute();

            _spawnEnemyController.Execute();
            _mainUI.Execute();
        }
    } 
}
