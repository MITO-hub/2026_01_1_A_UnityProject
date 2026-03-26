using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed = 5.0f;                  //이동 속도 변수 설정
    public float jumpForce = 5.0f;

    public Rigidbody rb;                            //플레이어 강체 선언

    public bool isGround = true;

    public int coinCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");         //수평 이동 (키값을 받아온다 , -1 ~ 1)
        float moveVertical = Input.GetAxis("Vertical");             //수직 이동 (키값을 받아온다 , -1 ~ 1)

        //강체의 속도의 값을 변경해서 캐릭터를 이동시킨다.
        rb.linearVelocity = new Vector3(moveHorizontal * moveSpeed, rb.linearVelocity.y, moveVertical * moveSpeed);

        if (Input.GetButton("Jump") && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
    }

        private void OnCollisionEnter(Collision collision)                  //유니티에서 지원해주는 충돌 체크 함수
        {
            if (collision.gameObject.tag == "Ground")                           // 충돌이 일어난 물체의 Tag 가 Ground 인 경우
            {
                isGround = true;
            }
        }

    private void OnTriggerEnter(Collider other)                         //캐릭터가 특정 지역을 들어갈 때 (충돌 범위) 체크 하는 함수
    {
        if(other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
        }
    }
}
