using System;
using UnityEngine;


public class EnemyHealthComponent : MonoBehaviour
{
    public IDamageble _damagebleEnemy;

    private void Awake()
    {
        _damagebleEnemy = GetComponent<IDamageble>();
    }

    private void Start(){
        if (_damagebleEnemy is DamageSystem handler)
        {
            handler.OnDamageTaken += (damage, source) =>
            {
                Debug.Log($"Получен урон {damage}. Текущее здоровье {handler.CurrentrHealth}");
            };

            handler.OnDamageTaken += (damage, source) =>
            {
                if (handler.IsDead())
                {
                    Debug.Log("Умер");
                    Destroy(this.gameObject);
                }
            };
        }
    }
}
