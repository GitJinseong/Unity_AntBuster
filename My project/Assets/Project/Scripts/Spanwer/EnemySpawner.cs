using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject startPoint = default;
    public GameObject enemyPrefab = default;
    public const float SPAWN_TIME = 0.1f;
    public const int MAX_MONSTER_SPAWN_SIZE = 100;
    public List<GameObject> enemyList = default;
    public int enemyHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        CreateEnemys();
        Spawn();
        StartCoroutine(SpawnDelay());
    }

    public void CreateEnemys()
    {
        //Vector2 targetPos = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < MAX_MONSTER_SPAWN_SIZE; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, transform.position,
                transform.rotation, transform);
            enemyList.Add(enemy);
            enemy.SetActive(false);
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!enemyList[i].activeSelf)
            {
                enemyList[i].SetActive(true);
                Enemy enemyComponent = enemyList[i].GetComponent<Enemy>();
                enemyComponent.SetHP(enemyHp);
                enemyComponent.ResetPosition(gameObject);
                break;
            }
        }
    }

    public IEnumerator SpawnDelay()
    {
        while(true)
        {
            yield return new WaitForSeconds(SPAWN_TIME);
            Spawn();
        }
    }
}
