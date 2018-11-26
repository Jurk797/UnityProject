using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : EnemyAI
{
    bool isAttacking = false;

    BuildingsList list;
    [SerializeField] float attackRange;
    [SerializeField] float maxHP;
    [SerializeField] int attackDamage;
    [SerializeField] float attackSpeed;
    [SerializeField] float moveSpeed;


    private void Awake()
    {
        GetComponent<HpManager>().HpMax = maxHP;
        list = BuildingsList.instance;
    }


    /// <summary>
    /// Поиск цели
    /// </summary>
    /// <returns></returns>
    protected override GameObject FindEnemy()
    {
        GameObject target = null;

        float closestFloat = Mathf.Infinity;

        foreach (GameObject enemy in list.buildings)
        {
            Vector3 heading = enemy.transform.position - transform.position;
            var distance = heading.sqrMagnitude;

            if (closestFloat > distance)
            {
                target = enemy;
                closestFloat = distance;
            }
        }
        return target;
    }

    /// <summary>
    /// Движение к цели
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    protected override bool MoveToEnemy(GameObject enemy)
    {

        Vector2 heading = enemy.transform.position - transform.position;
        var distance = heading.sqrMagnitude;
        if (distance >= Mathf.Pow(attackRange, 2))
        {
            transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, moveSpeed * Time.deltaTime);
            return false;
        }
        return true;
    }

    /// <summary>
    /// Атака цели
    /// </summary>
    /// <param name="enemy"></param>
    protected override void AttackEnemy(GameObject enemy)
    {
        if (!isAttacking)
            StartCoroutine(_attack(enemy));
    }

    IEnumerator _attack(GameObject enemy)
    {
        isAttacking = true;

        enemy.GetComponent<IDamageable>().TakeDamage(attackDamage);

        yield return new WaitForSeconds(attackSpeed);
        isAttacking = false;
    }
}