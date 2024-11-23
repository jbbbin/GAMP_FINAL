using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomCollision : MonoBehaviour
{
    public GameObject explosionEffect; // ���� ȿ�� ������
    public GameObject respawnObject;   // �������� ������Ʈ (���� ����)
    public GameObject cube;           // �浹�� ��Ȱ��ȭ�� ť�� ������Ʈ
    public float respawnTime = 1f;     // ������ �ð� (���� �� 1�� ���)
    public float explosionDuration = 1f; // ���� ȿ�� ���� �ð� (1��)
    public float blinkDuration = 2f;   // �����̴� ȿ�� ���� �ð� (2��)
    public float blinkInterval = 0.2f; // ������ ���� (0.2��)

    private BoxCollider cubeCollider;  // ť���� BoxCollider ����
    private bool isBlinking = false;   // ������ ���¸� �����ϴ� ����

    void Start()
    {
        // ť���� BoxCollider�� ����
        if (cube != null)
        {
            cubeCollider = cube.GetComponent<BoxCollider>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // �����̴� ���� ���� �浹�� ����
        if (isBlinking)
        {
            return;
        }

        if (other.CompareTag("Wall")) // "wall" �±��� ������Ʈ�� �浹�� ���
        {
            Debug.Log("�浹 �߻�: Wall �±׿� �浹!"); // �浹 �α� ���
            TriggerExplosion();  // ���� ȿ�� ȣ��
            StartCoroutine(HandleRespawn());  // ���� �ð� �� ������
        }
    }

    // ���� ȿ�� ����
    void TriggerExplosion()
    {
        if (explosionEffect != null)
        {
            GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity); // ���� ȿ�� ����
            StartCoroutine(DestroyExplosionEffect(explosion)); // ���� ȿ���� ���� �ð� �� ���ŵǵ��� ó��
        }
    }

    // ���� ȿ���� ���� �ð� �Ŀ� ��Ȱ��ȭ
    IEnumerator DestroyExplosionEffect(GameObject explosion)
    {
        yield return new WaitForSeconds(explosionDuration); // ���� ȿ���� ���ӵ� �ð� ���� ���
        Destroy(explosion); // ���� ȿ�� ������Ʈ ����
    }

    // ������ ó�� (���� ȿ�� �� 1�� �ڿ� �ٽ� Ȱ��ȭ)
    IEnumerator HandleRespawn()
    {
        // ������ ������Ʈ�� �ִٸ� �ش� ������Ʈ�� ��Ȱ��ȭ
        if (respawnObject != null)
        {
            respawnObject.SetActive(false);  // ������Ʈ ��Ȱ��ȭ
        }

        // �����̴� ȿ���� ���� ���̶�� �浹�� ����
        isBlinking = true;

        // ���� ȿ���� 1�� ���� ���ӵǹǷ� 1�� ���
        yield return new WaitForSeconds(respawnTime);

        // ���� ������Ʈ�� ť�� �ٽ� Ȱ��ȭ
        if (respawnObject != null)
        {
            respawnObject.SetActive(true);  // �ٽ� Ȱ��ȭ
            StartCoroutine(BlinkEffect());  // �����̴� ȿ�� ����
        }
    }

    // �������� ������Ʈ�� �����̴� ȿ�� �߰�
    IEnumerator BlinkEffect()
    {
        float elapsedTime = 0f;
        bool isVisible = true;

        // ������ ȿ���� 2�� ���� ����
        while (elapsedTime < blinkDuration)
        {
            respawnObject.SetActive(isVisible); // ������Ʈ�� Ȱ��ȭ ���¸� ����
            isVisible = !isVisible; // ���� ����
            elapsedTime += blinkInterval; // �ð� ���
            yield return new WaitForSeconds(blinkInterval); // ������ ���� ���� ���
        }

        // �������� ������ ������Ʈ�� ���̵��� ����
        respawnObject.SetActive(true);

        // �������� ������ �浹 ���� Ȱ��ȭ
        isBlinking = false;
    }
}
