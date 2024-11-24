using UnityEngine;

public class RandomMap : MonoBehaviour
{
    public GameObject[] prefabs; // ������ ������ ����Ʈ (4�� �������� �Ҵ�)

    void Start()
    {
        // ���� �� �������� �ϳ��� ������ ����
        SpawnRandomPrefab();
    }

    private void SpawnRandomPrefab()
    {
        // ������ ����Ʈ �� ���� ����
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

        // ������ ���� (���� ��ǥ ���)
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

        // �θ� ���� ������Ʈ�� ����
        spawnedPrefab.transform.SetParent(transform);

        // �������� ������ ���� ��ġ ����
        spawnedPrefab.transform.localPosition = prefabToSpawn.transform.localPosition;
    }
}
