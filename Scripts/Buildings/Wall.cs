using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] float distance = 2.75f;

    HpManager hpManager;

    private void Awake()
    {
        hpManager = GetComponent<HpManager>();
    }

    private void Start()
    {
        Initialization();
    }

    public void Initialization()
    {
        CheckingForLines(distance);
    }

    /// <summary>
    /// Проверка наличий стен в радиусе
    /// </summary>
    /// <param name="radius"></param>
    void CheckingForLines(float radius)
    {

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);


        foreach (var hit in hitColliders)
        {
            // если есть то соединяем линий и подписываем линию на событие при уничтожении любой из стен
            if (hit.tag == "Wall" && hit.gameObject != gameObject)
            {
                Line line = PoolManager.GetObject(1, transform.position, Quaternion.identity).GetComponent<Line>();
                line.Initialise(transform.position, hit.transform.position, 0.05f, Color.black);
                hpManager.OnDestroyCallback += line.Destroy;
                hit.GetComponent<Wall>().hpManager.OnDestroyCallback += line.Destroy;
            }
        }
    }
}


