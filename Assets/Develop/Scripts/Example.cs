using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private EnemyService _enemyService;    
    [SerializeField] private int _maxEnemiesCount;
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _minLifeTime;
    [SerializeField] private float _spawnAreaSize = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddEnemyWithDeathCondition();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddEnemyWithTimeCondition(); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddEnemyWithCountCondition(_maxEnemiesCount); 
        }
    }

    private void AddEnemyWithDeathCondition()
    {
        Enemy enemy = GetNewEnemy();

        enemy.SetKillableByClick();
        _enemyService.AddEnemy(enemy, () => enemy.IsDead);
    }

    private void AddEnemyWithTimeCondition()
    {
        Enemy enemy = GetNewEnemy();
        enemy.MaxLifeTime = GetlifeTime();

        _enemyService.AddEnemy(enemy, () => enemy.IsLifeTimeExpired());
    }

    private float GetlifeTime()
    {
        return Random.Range(_minLifeTime, _maxLifeTime);
    }

    private Vector3 GetPosition()
    {
        float x = Random.Range(-_spawnAreaSize, _spawnAreaSize);
        float z = Random.Range(-_spawnAreaSize, _spawnAreaSize);
        return new Vector3(x, 1f, z);
    }

    private void AddEnemyWithCountCondition(int maxCount)
    {
        Enemy enemy = GetNewEnemy();

        _enemyService.AddEnemy(enemy, () => _enemyService.GetEnemyCount() > maxCount);
    }

    private Enemy GetNewEnemy() => Instantiate(_enemyPrefab, GetPosition(), Quaternion.identity);
        
    
}
