using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 5f;  // ����� �����̴� �ӵ�

    void Update()
    {
        // ����� ���� �ӵ��� �÷��̾� �������� �����̵��� ����
        transform.Translate(Vector3.forward * speed * Time.deltaTime*-1);
    }
}