using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = default;
    public int count = 0;
    public GameObject target;
    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        // �����ϰ����� �ð� ���� �����ϴ� �Լ� ȣ��
        DoStop();
    }

    // Update is called once per frame
    void Update()
    {
        // Ÿ���� ���� ���
        if (target != null)
        {
            // ���ǵ带 �����ϰ� ����
            speed = Random.Range(1, 10);

            // Ÿ������ ���ϴ� ���� ���� ���ϱ�
            Vector2 direction = (target.transform.position - transform.position).normalized;

            float count = Random.Range(0, 1);
            if (count % 2 == 0)
            {
                int randomValue = Random.Range(0, 100);
                if (Random.Range(0, 1) == 0)
                {
                    direction.x = randomValue % 2 == 0 ? -direction.x : direction.x;
                    direction.y = randomValue % 2 == 0 ? direction.y : -direction.y;
                }
                else
                {
                    direction.x = randomValue % 2 == 0 ? direction.x : -direction.x;
                    direction.y = randomValue % 2 == 0 ? -direction.y : direction.y;
                }

                // ������ �̵�
                rigid.velocity = direction * speed * Random.Range(0, 3);
            }
            else
            {
                // ������ �̵�
                rigid.velocity = direction * speed * Random.Range(0, 3);
            }
        }
    }

    public IEnumerator DoStop()
    {
        while (true)
        {
            // �����̴� 0�� ~ 0.01�� ����
            float delay = Random.Range(0, 100);
            delay = delay * 0.001f;

            // ������ ��ŭ ���
            yield return new WaitForSeconds(delay);

            // ������Ʈ �̵� ����
            rigid.velocity = Vector2.zero;           
        }       // loop: ������ delay ���� ������ �Ͻ�����
    }
}
