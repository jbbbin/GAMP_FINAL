using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI1 : MonoBehaviour
{
    public RectTransform uiElement; // 이동할 UI의 RectTransform
    public float targetX = -490f; // 최종 목적지 x좌표
    public float startX = -800f; // 초기 x좌표
    public float startDelay = 9f; // 이동 시작 시간 (초)
    public float duration = 28f; // 이동에 걸리는 시간 (초)

    private float speed; // 계산된 이동 속도
    private bool isMoving = false; // 이동 시작 여부
    private float startTime; // 이동 시작 시간 기록

    void Start()
    {
        // 속도 계산: 거리 / 시간
        float distance = Mathf.Abs(targetX - startX);
        speed = distance / duration;

        // UI 시작 위치 설정
        uiElement.anchoredPosition = new Vector3(startX, uiElement.anchoredPosition.y);
    }

    void Update()
    {
        // 9초 이후 이동 시작
        if (Time.time >= startDelay && !isMoving)
        {
            isMoving = true;
            startTime = Time.time; // 이동 시작 시간 기록
        }

        // UI 이동 처리
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        // 경과 시간 계산
        float elapsedTime = Time.time - startTime;

        // 현재 위치를 선형 보간으로 계산 (Lerp 방식 사용)
        float progress = Mathf.Clamp01(elapsedTime / duration); // 0~1로 변환
        float newX = Mathf.Lerp(startX, targetX, progress);

        // 위치 업데이트
        uiElement.anchoredPosition = new Vector3(newX, uiElement.anchoredPosition.y);

        // 목표 위치에 도달하면 이동 중지
        if (Mathf.Approximately(newX, targetX))
        {
            isMoving = false; // 이동 완료
        }
    }
}
