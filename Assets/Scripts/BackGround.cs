using System.Collections;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 5f;  // 배경이 움직이는 초기 속도

    void Start()
    {
        // 37초 뒤에 속도를 8로 변경하는 코루틴 실행
        StartCoroutine(ChangeSpeedAfterDelay(37f, 6.5f));
    }

    void Update()
    {
        // 배경이 일정 속도로 움직임
        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1);
    }

    private IEnumerator ChangeSpeedAfterDelay(float delay, float newSpeed)
    {
        // 지정된 시간(37초) 대기
        yield return new WaitForSeconds(delay);

        // 속도를 새 값(8f)으로 변경
        speed = newSpeed;
    }
}
