using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door1; // 첫 번째 오브젝트
    public GameObject door2; // 두 번째 오브젝트
    public Transform targetObject; // z 위치를 체크할 오브젝트
    public float rotationSpeed = 2f; // 회전 속도

    private bool isRotating = false; // 중복 회전을 방지하기 위한 플래그

    void Update()
    {
        // 조건: targetObject의 절대 z 좌표가 15가 되면 실행
        if (targetObject.position.z <= 15f && !isRotating)
        {
            isRotating = true; // 중복 실행 방지
            StartCoroutine(SmoothRotate(door1.transform, new Vector3(0, -90, 0)));
            StartCoroutine(SmoothRotate(door2.transform, new Vector3(0, -90, 0)));
        }
    }

    // 부드럽게 회전시키는 코루틴
    private IEnumerator SmoothRotate(Transform obj, Vector3 targetRotation)
    {
        Quaternion initialRotation = obj.rotation; // 현재 회전값
        Quaternion finalRotation = Quaternion.Euler(targetRotation); // 목표 회전값

        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * rotationSpeed;
            obj.rotation = Quaternion.Slerp(initialRotation, finalRotation, time); // 부드럽게 회전
            yield return null;
        }

        obj.rotation = finalRotation; // 정확히 목표값으로 설정
    }
}