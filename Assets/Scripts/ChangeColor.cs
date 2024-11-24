using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Image[] images; // 4개의 UI Image를 할당할 배열
    private bool hasStartedCountdown = false; // 깜빡거림 및 삭제 프로세스 시작 여부 확인

    void Update()
    {
        // 키별로 색상 변경 처리
        HandleKey(KeyCode.W, 0); // W 키는 첫 번째 이미지
        HandleKey(KeyCode.A, 1); // A 키는 두 번째 이미지
        HandleKey(KeyCode.S, 2); // S 키는 세 번째 이미지
        HandleKey(KeyCode.D, 3); // D 키는 네 번째 이미지

        // 5초째에 깜빡임 및 삭제 프로세스 시작
        if (!hasStartedCountdown)
        {
            StartCoroutine(BlinkAndDestroy());
            hasStartedCountdown = true;
        }
    }

    private void HandleKey(KeyCode key, int imageIndex)
    {
        if (imageIndex < images.Length && images[imageIndex] != null)
        {
            // 키가 눌린 동안 빨간색
            if (Input.GetKey(key))
            {
                images[imageIndex].color = Color.red;
            }
            // 키를 떼면 하얀색으로 복구
            else
            {
                images[imageIndex].color = Color.white;
            }
        }
    }

    private IEnumerator BlinkAndDestroy()
    {
        // 5초 대기
        yield return new WaitForSeconds(6f);

        
        // 6초째에 모든 이미지 삭제
        foreach (var image in images)
        {
            if (image != null)
            {
                Destroy(image.gameObject);
            }
        }
    }
}
