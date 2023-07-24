using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ForTopBullet : MonoBehaviour
{
    public float speed = 1000f;
    private GameObject target;
    private Rigidbody2D rigid; // Rigidbody2D 컴포넌트를 저장하기 위한 변수

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        // 타겟이 있을 경우
        if (target != null)
        {
            Move();
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    public void Move()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        rigid.velocity = direction * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Enemy enemyComponent = collision.GetComponent<Enemy>();
            enemyComponent.Damage(100);
        }
        gameObject.SetActive(false);
    }
}
