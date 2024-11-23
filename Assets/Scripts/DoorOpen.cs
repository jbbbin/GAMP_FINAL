using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door1; // ù ��° ������Ʈ
    public GameObject door2; // �� ��° ������Ʈ
    public Transform targetObject; // z ��ġ�� üũ�� ������Ʈ
    public float rotationSpeed = 2f; // ȸ�� �ӵ�

    private bool isRotating = false; // �ߺ� ȸ���� �����ϱ� ���� �÷���

    void Update()
    {
        // ����: targetObject�� ���� z ��ǥ�� 15�� �Ǹ� ����
        if (targetObject.position.z <= 15f && !isRotating)
        {
            isRotating = true; // �ߺ� ���� ����
            StartCoroutine(SmoothRotate(door1.transform, new Vector3(0, -90, 0)));
            StartCoroutine(SmoothRotate(door2.transform, new Vector3(0, -90, 0)));
        }
    }

    // �ε巴�� ȸ����Ű�� �ڷ�ƾ
    private IEnumerator SmoothRotate(Transform obj, Vector3 targetRotation)
    {
        Quaternion initialRotation = obj.rotation; // ���� ȸ����
        Quaternion finalRotation = Quaternion.Euler(targetRotation); // ��ǥ ȸ����

        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * rotationSpeed;
            obj.rotation = Quaternion.Slerp(initialRotation, finalRotation, time); // �ε巴�� ȸ��
            yield return null;
        }

        obj.rotation = finalRotation; // ��Ȯ�� ��ǥ������ ����
    }
}