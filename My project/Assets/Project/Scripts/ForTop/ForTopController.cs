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
        // ���� ������Ʈ �ֺ��� �ٸ� ������Ʈ���� �˻�
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRadius);

        foreach (Collider2D collider in colliders)
        {
            // �ʿ��� ���ǿ� ���� �ش� ������Ʈ�� �����ϰ� �۾� ����
            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("�±װ��´�.");
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
