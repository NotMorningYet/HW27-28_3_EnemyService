using UnityEngine;

public class Enemy : MonoBehaviour, IClickKillable
{
    private float _lifeTime;    

    public bool IsClickKillable { get; private set; }
    public bool IsDead { get; set; }
    public float MaxLifeTime { get; set; }
        
    private void Update()
    {
        _lifeTime += Time.deltaTime;
    }
    
    public void SetKillableByClick()
    {
        IsClickKillable = true;
    }
    
    public bool IsLifeTimeExpired() => _lifeTime >= MaxLifeTime;    

    public void OnClickKill()
    {
        if (IsClickKillable)
            IsDead = true;
    }
}
