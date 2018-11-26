using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanAttack
{
    void Attack(int Damage, GameObject target, float attackSpeed);
}
