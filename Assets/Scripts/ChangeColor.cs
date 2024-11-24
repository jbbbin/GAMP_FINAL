using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Image[] images; // 4���� UI Image�� �Ҵ��� �迭
    private bool hasStartedCountdown = false; // �����Ÿ� �� ���� ���μ��� ���� ���� Ȯ��

    void Update()
    {
        // Ű���� ���� ���� ó��
        HandleKey(KeyCode.W, 0); // W Ű�� ù ��° �̹���
        HandleKey(KeyCode.A, 1); // A Ű�� �� ��° �̹���
        HandleKey(KeyCode.S, 2); // S Ű�� �� ��° �̹���
        HandleKey(KeyCode.D, 3); // D Ű�� �� ��° �̹���

        // 5��°�� ������ �� ���� ���μ��� ����
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
            // Ű�� ���� ���� ������
            if (Input.GetKey(key))
            {
                images[imageIndex].color = Color.red;
            }
            // Ű�� ���� �Ͼ������ ����
            else
            {
                images[imageIndex].color = Color.white;
            }
        }
    }

    private IEnumerator BlinkAndDestroy()
    {
        // 5�� ���
        yield return new WaitForSeconds(6f);

        
        // 6��°�� ��� �̹��� ����
        foreach (var image in images)
        {
            if (image != null)
            {
                Destroy(image.gameObject);
            }
        }
    }
}
