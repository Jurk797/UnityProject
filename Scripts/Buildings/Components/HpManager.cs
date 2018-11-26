using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour, IDamageable
{
    PoolObject pool;


    [SerializeField] HpUI hpUI;

    public delegate void OnDestroy();
    public OnDestroy OnDestroyCallback;

    private float hpMax;

    private float hpCurrent;

    public float HpCurrent
    {
        get
        {
            return hpCurrent;
        }
        set
        {
            hpCurrent = value;
            hpUI.DisplayHP(hpCurrent / hpMax);
            if(hpCurrent <= 0)
            {
                OnDestroyCallback.Invoke();
            }
        }
    }
    
    public float HpMax
    {
        set
        {
            hpMax = value;
            HpCurrent = value;
        }
    }

    void Awake()
    {
        OnDestroyCallback += _OnDesroy;
        pool = GetComponent<PoolObject>();
    }


    public void TakeDamage(int damage)
    {
        HpCurrent -= damage;
    }

    public void _OnDesroy()
    {
        BuildingsList.instance.buildings.Remove(gameObject);
        pool.ReturnToPool();
    }
}
