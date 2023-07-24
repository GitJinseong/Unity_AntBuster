using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ForTopBullet : MonoBehaviour
{
    public float speed = 1000f;
    private GameObject target;
    private Rigidbody2D rigid; // Rigidbody2D ������Ʈ�� �����ϱ� ���� ����

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        // Ÿ���� ���� ���
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
