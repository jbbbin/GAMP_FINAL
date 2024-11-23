using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 5f;  // 배경이 움직이는 속도

    void Update()
    {
        // 배경이 일정 속도로 플레이어 방향으로 움직이도록 설정
        transform.Translate(Vector3.forward * speed * Time.deltaTime*-1);
    }
}