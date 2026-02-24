using System;
using UnityEngine;


public class EnemyHealthComponent : MonoBehaviour
{
    private IDamageble _damageble;

    private void Awake()
    {
        _damageble = GetComponent<IDamageble>();
    }

    private void Start()
    {
        if (_damageble is DamageSystem handler)
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
                }
            };
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) || 
            Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.Y))
        {
            _damageble?.TakeDamage(10,null);
        }
    }
}
