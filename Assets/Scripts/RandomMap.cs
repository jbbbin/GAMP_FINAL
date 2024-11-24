using UnityEngine;

public class RandomMap : MonoBehaviour
{
    public GameObject[] prefabs; // 생성할 프리팹 리스트 (4개 프리팹을 할당)

    void Start()
    {
        // 시작 시 랜덤으로 하나의 프리팹 생성
        SpawnRandomPrefab();
    }

    private void SpawnRandomPrefab()
    {
        // 프리팹 리스트 중 랜덤 선택
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

        // 프리팹 생성 (월드 좌표 사용)
        GameObject spawnedPrefab = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);

        // 부모를 현재 오브젝트로 설정
        spawnedPrefab.transform.SetParent(transform);

        // 프리팹의 본연의 로컬 위치 유지
        spawnedPrefab.transform.localPosition = prefabToSpawn.transform.localPosition;
    }
}
