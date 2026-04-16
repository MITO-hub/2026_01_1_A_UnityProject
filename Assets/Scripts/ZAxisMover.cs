using UnityEngine;

public class ZAxisMover : MonoBehaviour
{
    public float speed = 5.0f;                                          //이동 속도
    public float timer = 5.0f;                                          //타이머 설정
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);              //변수 Speed의 속도로 일정하게 이동한다.

        timer -= Time.deltaTime;                                        //시간을 카운트다운 한다.

        if (timer < 0)
        {
            Destroy(gameObject);                                        //자기 자신을 파괴한다.
        }
    }
}
