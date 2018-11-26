using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private int damage;
    private float attackSpeed;
    ICanAttack attack;
    RotationToTarget rotation;
    GameObject nearestEnemy = null;
    List<GameObject> enemies = new List<GameObject>();

    public int Damage
    {
        set
        {
            damage = value;
        }
    }

    public float AttackSpeed
    {
        set
        {
            attackSpeed = value;
        }
    }

    private void Awake()
    {
        rotation = GetComponent<RotationToTarget>();
        attack = GetComponent<ICanAttack>();
    }

    private void OnEnable()
    {
        InvokeRepeating("ChoosingTarget", 0.5f, 0.5f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Update()
    {
        // атака и вращение к цели 
        if (nearestEnemy != null && nearestEnemy.activeSelf)
        {
            attack.Attack(damage, nearestEnemy, attackSpeed);
            rotation.Rotate(nearestEnemy.transform);
        }
    }

    /// <summary>
    /// Смотрим кто в радиусе атаки
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
        }
    }

    /// <summary>
    /// удаление из раудиуса при выходе из него
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }
    }

    /// <summary>
    /// поиск цели
    /// </summary>
    private void ChoosingTarget()
    {
        float shortestDistance = Mathf.Infinity;
        nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            if (enemy == null && !enemy.activeSelf)
                return;
            float distanceToEnemy = Vector2.SqrMagnitude(transform.position - enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                if (enemy.activeSelf)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }
    }
}
