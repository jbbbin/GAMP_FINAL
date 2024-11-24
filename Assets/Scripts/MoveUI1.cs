using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI1 : MonoBehaviour
{
    public RectTransform uiElement; // �̵��� UI�� RectTransform
    public float targetX = -490f; // ���� ������ x��ǥ
    public float startX = -800f; // �ʱ� x��ǥ
    public float startDelay = 9f; // �̵� ���� �ð� (��)
    public float duration = 28f; // �̵��� �ɸ��� �ð� (��)

    private float speed; // ���� �̵� �ӵ�
    private bool isMoving = false; // �̵� ���� ����
    private float startTime; // �̵� ���� �ð� ���

    void Start()
    {
        // �ӵ� ���: �Ÿ� / �ð�
        float distance = Mathf.Abs(targetX - startX);
        speed = distance / duration;

        // UI ���� ��ġ ����
        uiElement.anchoredPosition = new Vector3(startX, uiElement.anchoredPosition.y);
    }

    void Update()
    {
        // 9�� ���� �̵� ����
        if (Time.time >= startDelay && !isMoving)
        {
            isMoving = true;
            startTime = Time.time; // �̵� ���� �ð� ���
        }

        // UI �̵� ó��
        if (isMoving)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        // ��� �ð� ���
        float elapsedTime = Time.time - startTime;

        // ���� ��ġ�� ���� �������� ��� (Lerp ��� ���)
        float progress = Mathf.Clamp01(elapsedTime / duration); // 0~1�� ��ȯ
        float newX = Mathf.Lerp(startX, targetX, progress);

        // ��ġ ������Ʈ
        uiElement.anchoredPosition = new Vector3(newX, uiElement.anchoredPosition.y);

        // ��ǥ ��ġ�� �����ϸ� �̵� ����
        if (Mathf.Approximately(newX, targetX))
        {
            isMoving = false; // �̵� �Ϸ�
        }
    }
}
