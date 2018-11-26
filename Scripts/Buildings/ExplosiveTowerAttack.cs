using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTowerAttack : MonoBehaviour, ICanAttack
{
    [SerializeField] Transform firePoint;
    [SerializeField] Transform rotationPart;

    bool isAttacking = false;
    
    public void Attack(int Damage, GameObject target, float attackSpeed)
    {
        if (!isAttacking)
            StartCoroutine(_attack(Damage, target, attackSpeed));
    }
    
    IEnumerator _attack(int Damage, GameObject target, float attackSpeed)
    {
        isAttacking = true;
        // создаем пулю по ID префаба
        ExplosiveBullet bullet = PoolManager.GetObject(2, firePoint.position, rotationPart.localRotation).GetComponent<ExplosiveBullet>();
        bullet.Initialization(Damage, target);
        yield return new WaitForSeconds(attackSpeed);
        isAttacking = false;
    }
}