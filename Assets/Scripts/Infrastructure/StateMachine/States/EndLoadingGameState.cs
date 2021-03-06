using Platformer.Game.Logger;
using Platformer.Game.Services.Factory;
using Platformer.Game.Services.StaticData;
using Platformer.Infrastructure.Persistent;
using Platformer.Infrastructure.SaveLoad;
using Platformer.Infrastructure.SceneLoading;
using Platformer.UI.Loading;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class EndLoadingGameState : IAppState
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IAppStateMachine _stateMachine;
        private readonly IGameLogger _gameLogger;
        private readonly IStaticDataService _staticData;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentService _persistentService;
        private readonly ISaveLoadService _saveLoadService;

        public EndLoadingGameState(ILoadingScreen loadingScreen, IAppStateMachine stateMachine, IGameLogger gameLogger,
            IStaticDataService staticData, IGameFactory gameFactory, IPersistentService persistentService,
            ISaveLoadService saveLoadService)
        {
            _loadingScreen = loadingScreen;
            _stateMachine = stateMachine;
            _gameLogger = gameLogger;
            _staticData = staticData;
            _gameFactory = gameFactory;
            _persistentService = persistentService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _gameLogger.Bootstrap();
            _staticData.Load();
            LoadPersistentData();
            
            LevelData levelData = _staticData.GetLevelData(GetLevelName());

            CreateEnemySpawners(levelData);

            InformReaders();
            _stateMachine.Enter<GameState>();
        }
        
        private void InformReaders()
        {
            for (int i = 0; i < _gameFactory.Readers.Count; i++)
            {
                ISaveLoadReader loadReader = _gameFactory.Readers[i];
                loadReader.Load(_persistentService.Data);
            }
        }
        
        private void LoadPersistentData()
        {
            _persistentService.Data = _saveLoadService.Load();
        }

        public void Exit()
        {
            _loadingScreen.Hide();
        }
        
        private string GetLevelName() =>
            SceneName.Game;

        private void CreateEnemySpawners(LevelData levelData)
        {
            foreach (EnemySpawnData spawnData in levelData.EnemySpawnPoints)
                _gameFactory.CreateEnemySpawner(spawnData);
        }
    }
}