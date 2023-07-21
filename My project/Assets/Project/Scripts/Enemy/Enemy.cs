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

        // 랜덤하게일정 시간 마다 정지하는 함수 호출
        DoStop();
    }

    // Update is called once per frame
    void Update()
    {
        // 타겟이 있을 경우
        if (target != null)
        {
            // 스피드를 랜덤하게 설정
            speed = Random.Range(1, 10);

            // 타겟으로 향하는 방향 벡터 구하기
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

                // 역방향 이동
                rigid.velocity = direction * speed * Random.Range(0, 3);
            }
            else
            {
                // 정방향 이동
                rigid.velocity = direction * speed * Random.Range(0, 3);
            }
        }
    }

    public IEnumerator DoStop()
    {
        while (true)
        {
            // 딜레이는 0초 ~ 0.01초 사이
            float delay = Random.Range(0, 100);
            delay = delay * 0.001f;

            // 딜레이 만큼 대기
            yield return new WaitForSeconds(delay);

            // 오브젝트 이동 정지
            rigid.velocity = Vector2.zero;           
        }       // loop: 지정한 delay 마다 움직임 일시정지
    }
}
