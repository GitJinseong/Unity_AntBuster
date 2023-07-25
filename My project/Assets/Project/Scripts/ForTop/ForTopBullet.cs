using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ForTopBullet : MonoBehaviour
{
    public float speed = 1000f;
    public int damage = 30;
    private GameObject target;
    private Rigidbody2D rigid; // Rigidbody2D ������Ʈ�� �����ϱ� ���� ����

    private void FixedUpdate()
    {
        // Ÿ���� ���� ���
        if (target != null)
        {
            Move();
        }
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ ��������
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            Enemy enemyComponent = collision.collider.GetComponent<Enemy>();
            enemyComponent.Damage(damage);
        }
        gameObject.SetActive(false);
    }
}
