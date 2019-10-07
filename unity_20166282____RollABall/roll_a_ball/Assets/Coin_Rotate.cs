using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Rotate : MonoBehaviour {
    void Update() {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); // 벡터에 프레임과 프레임 사이의 시간을 곱해줌. (time.deltatime 으로 적들이 나에게 쫓아오는 것도 구현 가능.)
    }

}
