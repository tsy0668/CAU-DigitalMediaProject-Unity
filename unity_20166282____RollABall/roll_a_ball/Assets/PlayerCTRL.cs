using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCTRL : MonoBehaviour
{
    public Text youWinText;
    public Text countText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        youWinText.text = "";
    }

    public float speed; // public 쓰면 inspector 뷰에 생김.
    private Rigidbody rb;

    int count = 0;

    void FixedUpdate()
    {    //fixedupdate 는 물리계산, rigidbody(물리엔진), 게임 속도에 따라 가해지는 힘이 달라질 때가 있음.(컴퓨터가 너무 좋아 140프레임, 안좋아서 30프레임. 인 경우 차이 발생. 따라서 일정한 간격에 따라 업데이트가 되게 함)

        float moveHorizontal = Input.GetAxis("Horizontal"); // getaxis : 축의 값을 가져옴
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // 가져온 축 값들로 이동방향 설정
        rb.AddForce(movement * speed);  // AddForce : 벡터 방향으로 힘을 준다.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {   // 충돌한 것이 Pick up 이면 (TAG를 비교함.)
            other.gameObject.SetActive(false);        // 게임 오브젝트를 비활성화함
            count += 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();          
        //4은 코인의 숫자        
        if (count >= 4)
        {
            youWinText.text = "YOU WIN!!";
        }
    }
    }