using UnityEngine;

public class BroomMove : MonoBehaviour
{
    public float moveSpeed = 5f;   // �̵� �ӵ�

    // �̵� ���� ����
    public float minX = -8f;       // X�� �ּ� ��
    public float maxX = 8f;        // X�� �ִ� ��
    public float minY = 0f;        // Y�� �ּ� ��
    public float maxY = 5f;        // Y�� �ִ� ��

    void Update()
    {
        // �̵� ���� ����
        float moveX = 0f;
        float moveY = 0f;

        // W, S Ű�� Y�� (����) �̵�
        if (Input.GetKey(KeyCode.W))  // W Ű�� ������ ���� �̵�
        {
            moveY = 1f;  // ���� �̵�
        }
        else if (Input.GetKey(KeyCode.S))  // S Ű�� ������ �Ʒ��� �̵�
        {
            moveY = -1f;  // �Ʒ��� �̵�
        }

        // A, D Ű�� X�� (�¿�) �̵�
        if (Input.GetKey(KeyCode.A))  // AŰ�� ������ �������� �̵�
        {
            moveX = -1f;  // �������� �̵�
        }
        else if (Input.GetKey(KeyCode.D))  // DŰ�� ������ ���������� �̵�
        {
            moveX = 1f;  // ���������� �̵�
        }

        // �̵� �� ����
        Vector3 movement = new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // ī�޶��� ��ġ�� ������ ������ ����� �ʵ��� ����
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // �̵� �� ��ġ ����
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
