
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {

        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private SpriteAnimatorConfig _coinConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private List<LevelObjectView> _coinsView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private LevelObjectView _finishView;
        [SerializeField] private List<LevelObjectView> _deathlyPitsView;
        [SerializeField] private GeneratorLevelView _genView;
        [SerializeField] private QuestObjectView _singleQuest;

        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;
        private CannonController _cannon;
        private BulletEmitterController _bulletEmitterController;
        private CoinController _coinController;
        private FinishController _finishController;
        private DeathlyPitsController _deathlyPitsController;
        private GeneratorController _levelGenerator;
        private QuestConfiguratorController _questConfigurator;

        void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
                _playerController = new PlayerController(_playerView, _playerAnimator);
            }

            _coinConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");
            if (_coinConfig)
            {
                _coinAnimator = new SpriteAnimatorController(_coinConfig);
            }

            _cameraController = new CameraController(_playerView.transform, Camera.main.transform);

            _cannon = new CannonController(_cannonView._muzzleTransform, _playerView._transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);
            _coinController = new CoinController(_playerView, _coinsView, _coinAnimator);
            _finishController = new FinishController(_playerView, _finishView);
            _deathlyPitsController = new DeathlyPitsController(_playerView, _playerView.transform.position, _deathlyPitsView);

            _levelGenerator = new GeneratorController(_genView);
            _levelGenerator.Init();

            _questConfigurator = new QuestConfiguratorController(_singleQuest);
            _questConfigurator.Init();
        }

        void Update()
        {
            _cameraController.Update();
            _playerController.Update();
            _cannon.Update();
            _bulletEmitterController.Update();
            _coinAnimator.Update();
        }
    }
}
