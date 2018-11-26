using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
	
    public void Update()
    {
        var enemy = FindEnemy();
        if (enemy != null)
        {
            if (MoveToEnemy(enemy))
            {
                AttackEnemy(enemy);
            }
        }
    }

    protected abstract GameObject FindEnemy();
    protected abstract bool MoveToEnemy(GameObject enemy);
    protected abstract void AttackEnemy(GameObject enemy);
}