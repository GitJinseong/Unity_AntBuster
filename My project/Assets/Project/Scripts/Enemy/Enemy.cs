using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rigid;
    public float speed = 3f;
    public int hp = 100;
    public int giveGolds = 10;

    // Start is called before the first frame update

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Point_2");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Move();
        }
        else
        {
            Debug.Log("게임 오브젝트를 찾을 수 없습니다.");
        }

        IsDead();
    }

    public void Move()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        rigid.velocity = direction * speed;
    }

    public void SetHP(int hp_)
    {
        hp = hp_;
    }

    public void ResetPosition(GameObject obj)
    {
        transform.position = obj.transform.position;
    }

    public void Damage(int damage)
    {
        hp -= damage;
    }

    public void IsDead()
    {
        if (hp <= 0)
        {
            Debug.Log("파괴");
            GameManager.instance.AddScore();
            GameManager.instance.AddGold(Random.Range(1, 10));
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name;
        Debug.Log(name);
        switch(name)
        {
            case "Point_1":
                target = GameObject.Find("Point_2");
                break;
            case "Point_2":
                target = GameObject.Find("Point_3");
                break;
            case "Point_3":
                target = GameObject.Find("Point_4");
                break;
            case "Point_4":
                target = GameObject.Find("Point_1");
                break;
            default:
                break;
        }
    }
}
