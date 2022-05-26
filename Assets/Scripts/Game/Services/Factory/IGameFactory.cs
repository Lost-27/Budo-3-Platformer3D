using System.Collections.Generic;
using Platformer.Game.Enemy;
using Platformer.Game.Services.StaticData;
using Platformer.Infrastructure.SaveLoad;
using UnityEngine;

namespace Platformer.Game.Services.Factory
{
    public interface IGameFactory
    {
        List<ISaveLoadWriter> Writers { get; }
        List<ISaveLoadReader> Readers { get; }

        void CreateEnemySpawner(EnemySpawnData spawnData);
        GameObject CreateEnemy(EnemyType enemyType, Vector3 at, string id);

        void Clean();
    }
}