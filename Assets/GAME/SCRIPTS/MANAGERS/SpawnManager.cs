using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.GraphicsBuffer;

public class SpawnManager : MonoBehaviour
{
    [Header("Area spawneable")]
    public Vector3 Centro = Vector3.zero;
    public Vector3 Tamanio = new Vector3(10, 0, 10);

    [Header("Tiempo entre spawns (segundos)")]
    [Tooltip("Intervalo mínimo entre spawns")]
    public float minDelay = 1f;
    [Tooltip("Intervalo máximo entre spawns")]
    public float maxDelay = 3f;

    [Header("Prefab del objetivo")]
    public GameObject objetivo;
    [Tooltip("Pool inicial de instancias")]
    public int poolSize = 10;

    private ObjectPool<GameObject> pool;

    void Awake()
    {
        pool = new ObjectPool<GameObject>(
            () => Instantiate(objetivo),
            obj => obj.SetActive(true),
            obj => obj.SetActive(false),
            poolSize
        );
    }

    void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            Vector3 pos = Centro + new Vector3(
                Random.Range(-Tamanio.x / 2, Tamanio.x / 2),
                Random.Range(-Tamanio.y / 2, Tamanio.y / 2),
                Random.Range(-Tamanio.z / 2, Tamanio.z / 2)
            );

            GameObject obj = pool.Get();
            obj.transform.position = pos;
            obj.GetComponent<Target>().Initialize(pool);
        }
    }
}
