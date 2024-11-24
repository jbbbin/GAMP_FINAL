using System.Collections;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed = 5f;  // ����� �����̴� �ʱ� �ӵ�

    void Start()
    {
        // 37�� �ڿ� �ӵ��� 8�� �����ϴ� �ڷ�ƾ ����
        StartCoroutine(ChangeSpeedAfterDelay(37f, 6.5f));
    }

    void Update()
    {
        // ����� ���� �ӵ��� ������
        transform.Translate(Vector3.forward * speed * Time.deltaTime * -1);
    }

    private IEnumerator ChangeSpeedAfterDelay(float delay, float newSpeed)
    {
        // ������ �ð�(37��) ���
        yield return new WaitForSeconds(delay);

        // �ӵ��� �� ��(8f)���� ����
        speed = newSpeed;
    }
}
