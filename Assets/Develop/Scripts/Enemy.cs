using UnityEngine;

public class Enemy : MonoBehaviour, IClickKillable
{
    private float _lifeTime;
    private bool _isDead;
    private float _maxLifeTime;

    public bool IsClickKillable { get; private set; }
    public bool IsDead => _isDead;
    public float MaxLifeTime => _maxLifeTime;          

    private void Update()
    {
        _lifeTime += Time.deltaTime;
    }
    
    public void SetLifeTime(float maxLifeTime)
    {
        _maxLifeTime = maxLifeTime;        
    }

    public void SetKillableByClick()
    {
        IsClickKillable = true;
    }
    
    public bool IsLifeTimeExpired() => _lifeTime >= _maxLifeTime;    

    public void OnClickKill()
    {
        if (IsClickKillable)
            _isDead = true;
    }
}
