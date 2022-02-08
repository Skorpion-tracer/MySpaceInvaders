﻿using System.Collections.Generic;
using View;
using UnityEngine;
using Model;
using System;

namespace Controller
{
    public sealed class SpawnEnemyController
    {
        private Queue<EnemyController> _enemies;
        private Stack<EnemyController> _enemiesStack;
        private List<EnemyController> _enemiesDeath;
        private Transform _spawnTransform;
        private RulesSpawnEnemy _rulesSpawnEnemy;
        private float _time = 0;

        public event Action AllEnemiesDeath;

        public SpawnEnemyController(Transform spawnEnemy, RulesSpawnEnemy rulesSpawnEnemy)
        {
            _spawnTransform = spawnEnemy;
            _rulesSpawnEnemy = rulesSpawnEnemy;

            _enemies = new Queue<EnemyController>();
            _enemiesStack = new Stack<EnemyController>();
            _enemiesDeath = new List<EnemyController>();

            PushQueue();
        }

        private void SpawnEnemy()
        {
            _enemiesStack.Push(_enemies.Dequeue());
            _enemiesStack.Peek().Spawn(_spawnTransform, _rulesSpawnEnemy.Enemy);
            _enemiesStack.Peek().OnEnemyDead += SpawnEnemyController_OnEnemyDead;

            if (_enemies.Count <= 0)
            {
                PushQueue();
            }
        }        

        public void Execute()
        {
            foreach (EnemyController enemy in _enemiesStack)
            {
                enemy.Execute();
            }

            if (_enemies.Count > 0 && _enemiesDeath.Count < _rulesSpawnEnemy.CountEnemies)
            {
                _time += Time.deltaTime;
                if (_time >= _rulesSpawnEnemy.FrequencySpawn)
                {
                    SpawnEnemy();
                    _time = 0;
                }
            }

            if (_enemiesDeath.Count >= _rulesSpawnEnemy.CountEnemies)
            {
                AllEnemiesDeath?.Invoke();
            }
        }

        private void PushQueue()
        {
            for (int i = 0; i < _rulesSpawnEnemy.CountEnemies; i++)
            {
                _enemies.Enqueue(new EnemyController());
            }
        }

        private void SpawnEnemyController_OnEnemyDead()
        {
            _enemiesDeath.Add(_enemiesStack.Peek());
        }
    }
}
