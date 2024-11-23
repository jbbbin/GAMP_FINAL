using UnityEngine;

public class BroomMove : MonoBehaviour
{
    public float moveSpeed = 5f;   // 이동 속도

    // 이동 범위 설정
    public float minX = -8f;       // X축 최소 값
    public float maxX = 8f;        // X축 최대 값
    public float minY = 0f;        // Y축 최소 값
    public float maxY = 5f;        // Y축 최대 값

    void Update()
    {
        // 이동 관련 변수
        float moveX = 0f;
        float moveY = 0f;

        // W, S 키로 Y축 (상하) 이동
        if (Input.GetKey(KeyCode.W))  // W 키를 누르면 위로 이동
        {
            moveY = 1f;  // 위로 이동
        }
        else if (Input.GetKey(KeyCode.S))  // S 키를 누르면 아래로 이동
        {
            moveY = -1f;  // 아래로 이동
        }

        // A, D 키로 X축 (좌우) 이동
        if (Input.GetKey(KeyCode.A))  // A키를 누르면 왼쪽으로 이동
        {
            moveX = -1f;  // 왼쪽으로 이동
        }
        else if (Input.GetKey(KeyCode.D))  // D키를 누르면 오른쪽으로 이동
        {
            moveX = 1f;  // 오른쪽으로 이동
        }

        // 이동 후 적용
        Vector3 movement = new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;
        transform.position += movement;

        // 카메라의 위치가 지정된 범위를 벗어나지 않도록 제한
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        // 이동 후 위치 적용
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
