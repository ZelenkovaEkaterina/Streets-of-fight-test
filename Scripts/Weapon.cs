using UnityEngine;

public class Weapon : MonoBehaviour, IDamageDiller
{
    private int _damageAmount = 10;
    public int DamageAmount => _damageAmount;
    
    public void DealDamage(IDamageble target, int damage)
    {
        if (target != null && !target.IsDead())
        {
            target.TakeDamage(damage, gameObject);
            Debug.Log($"Удар c уроном {damage}!");
        }
    }
    
    public void Attack(IDamageble target)
    {
        DealDamage(target, _damageAmount);
    }
    
    public void CriticalAttack(IDamageble target)
    {
        DealDamage(target, _damageAmount);
    }
}
