using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTopController : MonoBehaviour
{
    public GameObject bulletPrefab = default;
    public GameObject target = default;
    public float searchRadius = 2f;
    public float spawnTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FindEnemy()
    {
        // 현재 오브젝트 주변의 다른 오브젝트들을 검색
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius);

        foreach (Collider2D collider in colliders)
        {
            // 필요한 조건에 따라 해당 오브젝트를 선택하고 작업 수행
            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("태그가맞다.");
                target = collider.gameObject;
                GameObject bullet = Instantiate(bulletPrefab, transform.position,
                    transform.rotation);
                ForTopBullet bulletComponent = bullet.GetComponent<ForTopBullet>();
                bulletComponent.SetTarget(target);
                break;
            }
        }
    }
    
    public IEnumerator SpawnBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            FindEnemy();
        }
    }
}
