using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    private readonly Dictionary<Enemy, Func<bool>> _enemies = new Dictionary<Enemy, Func<bool>>();

    private void Update()
    {
        Debug.Log($"Enemies count: {_enemies.Count}");

        DestroyEnemiesByCondition();
    }

    public void AddEnemy(Enemy enemy, Func<bool> destroyCondition)
    {
        _enemies.Add(enemy, destroyCondition);
    }

    private void DestroyEnemiesByCondition()
    {
        List<Enemy> enemiesToRemove = new();

        foreach (var pair in _enemies)
        {
            if (pair.Value.Invoke())
                enemiesToRemove.Add(pair.Key);
        }

        foreach (var enemy in enemiesToRemove)
        {
            _enemies.Remove(enemy);
            Destroy(enemy.gameObject);
        }
    }

    public int GetEnemyCount()
    {
        return _enemies.Count;
    }
}
