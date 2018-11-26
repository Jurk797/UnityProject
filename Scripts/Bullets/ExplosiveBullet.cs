using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float radiusExplosive;
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
        if (target != null)
        {

            var heading = target.transform.position - _transform.position;
            var angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg - 180;
            _transform.rotation = Quaternion.Euler(0, 0, angle);

            _transform.position = Vector2.MoveTowards(_transform.position, target.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Explosive();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            Explosive();
            //эффект взрыва
        }
    }

    void Explosive()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(_transform.position, radiusExplosive);

        foreach (var hit in hitColliders)
        {
            if (hit.tag == "Enemy")
            {
                if (hit.GetComponent<IDamageable>() != null)
                {
                    hit.GetComponent<IDamageable>().TakeDamage(damage);
                }
            }
        }
        pool.ReturnToPool();
    }
}