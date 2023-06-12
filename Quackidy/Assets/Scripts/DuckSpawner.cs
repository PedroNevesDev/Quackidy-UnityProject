using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    private static DuckSpawner instance;

    [SerializeField] Vector2 xLims;
    [SerializeField] Vector2 yLims;

    [SerializeField] float timeToSpawnSeed;
    [SerializeField] float seedTimer;

    [SerializeField] float timeToSpawnDuck;
    [SerializeField] float duckTimer;

    [SerializeField] BadDuck badDuckPrefab;
    [SerializeField] Seed seedPrefab;

    [SerializeField] LookAtTarget arrow;
    Duck duck;

    public static DuckSpawner Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        if(instance)
            Destroy(instance);
        instance = this;
    }
    private void Start()
    {
        duck = Duck.Instance;
        FollowPlayer follow = Camera.main.GetComponent<FollowPlayer>();
        xLims = follow.XLims;
        yLims = follow.YLims;
    }

    private void Update()
    {
        seedTimer += Time.deltaTime;
        duckTimer += Time.deltaTime;

        if (seedTimer > timeToSpawnSeed)
        {
            seedTimer = 0;
            Seed newSeed = Instantiate(seedPrefab, new Vector3(Random.Range(xLims.x, xLims.y), Random.Range(yLims.x, yLims.y), 0), Quaternion.identity);
            LookAtTarget newarrow = Instantiate(arrow, duck.transform.position, Quaternion.identity, duck.transform);
            newarrow.Target = newSeed.transform;
        }
    }

    public void SpawnDuck()
    {
        Instantiate(badDuckPrefab, new Vector3(Random.Range(xLims.x, xLims.y), Random.Range(yLims.x, yLims.y), 0), Quaternion.identity);
    }
}
