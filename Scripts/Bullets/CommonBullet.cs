using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBullet : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject target;
    int damage;
    Transform _transform;
    PoolObject pool;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        pool = GetComponent<PoolObject>();
    }


    public void Initialization(int _damage, GameObject _target)
    {
        damage = _damage;
        target = _target;
    }

    void Update()
    {
        if (target != null && target.activeSelf)
        {
            // аналогично LookAt только в 2D
            var heading = target.transform.position - _transform.position;
            var angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg - 180;
            _transform.rotation = Quaternion.Euler(0, 0, angle);

            _transform.position = Vector2.MoveTowards(_transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            pool.ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            if (target.GetComponent<IDamageable>() != null)
            {
                target.GetComponent<IDamageable>().TakeDamage(damage);
            }
            pool.ReturnToPool();
        }
    }
}