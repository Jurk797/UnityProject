using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public List<Transform> pointsForSpawn = new List<Transform>();
    [SerializeField] int countEnemy = 12;
    [SerializeField] int enemyID = 8;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            Spawn();
        }
    }


    void Spawn()
    {
        int enemyOnPoint = countEnemy / pointsForSpawn.Count;
        StartCoroutine(waitSec(enemyOnPoint));


    }

    /// <summary>
    /// Спаун врагов с переодичностью в 1 секунду с каждой стороны
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    IEnumerator waitSec(int count)
    {
        for (int i = 0; i < count; i++)
        {
            foreach (Transform point in pointsForSpawn)
            {
                PoolManager.GetObject(enemyID, point.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
