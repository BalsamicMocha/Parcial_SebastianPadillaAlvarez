using UnityEngine;
using System.Collections;
using Managers;

    public class Target : MonoBehaviour
    {
    [Header("Tiempo de vida (segundos)")]
    public float minLifeTime = 1f;
    public float maxLifeTime = 5f;


    [Header("Puntaje/Tiempo")]
    public int score = 1;
    public float extraTime = .5f;

    private ObjectPool<GameObject> pool;
    private float lifeTime;

    public void Initialize(ObjectPool<GameObject> poolRef)
        {
            pool = poolRef;
            lifeTime = Random.Range(minLifeTime, maxLifeTime);
            StartCoroutine(LifeTimeRoutine());
        }

        IEnumerator LifeTimeRoutine()
        {
            yield return new WaitForSeconds(lifeTime);
            pool.Release(gameObject);
        }

        void OnMouseDown()
        {           
            pool.Release(gameObject);
            UIManager.Instance.AddScore(score);
            GameManager.Instance.AddTime(extraTime);
        }
    }
