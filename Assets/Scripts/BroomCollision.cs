using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomCollision : MonoBehaviour
{
    public GameObject explosionEffect; // 폭발 효과 프리팹
    public GameObject respawnObject;   // 리스폰될 오브젝트 (지정 가능)
    public GameObject cube;           // 충돌을 비활성화할 큐브 오브젝트
    public float respawnTime = 1f;     // 리스폰 시간 (폭발 후 1초 대기)
    public float explosionDuration = 1f; // 폭발 효과 지속 시간 (1초)
    public float blinkDuration = 2f;   // 깜빡이는 효과 지속 시간 (2초)
    public float blinkInterval = 0.2f; // 깜빡임 간격 (0.2초)

    private BoxCollider cubeCollider;  // 큐브의 BoxCollider 저장
    private bool isBlinking = false;   // 깜빡임 상태를 추적하는 변수

    void Start()
    {
        // 큐브의 BoxCollider를 저장
        if (cube != null)
        {
            cubeCollider = cube.GetComponent<BoxCollider>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 깜빡이는 중일 때는 충돌을 무시
        if (isBlinking)
        {
            return;
        }

        if (other.CompareTag("Wall")) // "wall" 태그의 오브젝트와 충돌한 경우
        {
            Debug.Log("충돌 발생: Wall 태그와 충돌!"); // 충돌 로그 출력
            TriggerExplosion();  // 폭발 효과 호출
            StartCoroutine(HandleRespawn());  // 일정 시간 후 리스폰
        }
    }

    // 폭발 효과 실행
    void TriggerExplosion()
    {
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity); // 폭발 효과 생성
            StartCoroutine(DestroyExplosionEffect(explosion)); // 폭발 효과가 일정 시간 후 제거되도록 처리
        }
    }

    // 폭발 효과를 일정 시간 후에 비활성화
    IEnumerator DestroyExplosionEffect(GameObject explosion)
    {
        yield return new WaitForSeconds(explosionDuration); // 폭발 효과가 지속될 시간 동안 대기
        Destroy(explosion); // 폭발 효과 오브젝트 삭제
    }

    // 리스폰 처리 (폭발 효과 후 1초 뒤에 다시 활성화)
    IEnumerator HandleRespawn()
    {
        // 지정된 오브젝트가 있다면 해당 오브젝트를 비활성화
        if (respawnObject != null)
        {
            respawnObject.SetActive(false);  // 오브젝트 비활성화
        }

        // 깜빡이는 효과가 진행 중이라면 충돌을 막음
        isBlinking = true;

        // 폭발 효과가 1초 동안 지속되므로 1초 대기
        yield return new WaitForSeconds(respawnTime);

        // 원래 오브젝트와 큐브 다시 활성화
        if (respawnObject != null)
        {
            respawnObject.SetActive(true);  // 다시 활성화
            StartCoroutine(BlinkEffect());  // 깜빡이는 효과 시작
        }
    }

    // 리스폰된 오브젝트에 깜빡이는 효과 추가
    IEnumerator BlinkEffect()
    {
        float elapsedTime = 0f;
        bool isVisible = true;

        // 깜빡임 효과는 2초 동안 진행
        while (elapsedTime < blinkDuration)
        {
            respawnObject.SetActive(isVisible); // 오브젝트의 활성화 상태를 반전
            isVisible = !isVisible; // 상태 반전
            elapsedTime += blinkInterval; // 시간 경과
            yield return new WaitForSeconds(blinkInterval); // 깜빡임 간격 동안 대기
        }

        // 깜빡임이 끝나면 오브젝트를 보이도록 설정
        respawnObject.SetActive(true);

        // 깜빡임이 끝나면 충돌 감지 활성화
        isBlinking = false;
    }
}
