using System;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float speed = 4.0f;
    //공격력
    //이펙트
    public GameObject effect;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //충돌처리
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            // 이팩트 생성
            GameObject impact = Instantiate(effect, transform.position, Quaternion.identity);

            // 1초뒤에 지우기
            Destroy(impact, 1f);

            //몬스터삭제
            collision.gameObject.GetComponent<Monster>().Damage(1);
            
            //미사일 삭제
            Destroy(gameObject);

        }
    }
}
