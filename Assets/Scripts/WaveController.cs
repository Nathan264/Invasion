using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController Instance;

    [SerializeField] private List<EnemyObj> enemies;
    [SerializeField] private WaveInfo wInfo;
    [SerializeField] private PlayerHealth pHealth;

    [SerializeField] private float timeToStartWave;
    [SerializeField] private int currentWave = 0;
    [SerializeField] private int maxEnemies;
    [SerializeField] private int initialEnemies;
    [SerializeField] private int remainingEnemies;
    [SerializeField] private int spawnAreaMinX;
    [SerializeField] private int spawnAreaMaxX;
    [SerializeField] private int spawnAreaMinY;
    [SerializeField] private int spawnAreaMaxY;


    public float TimeToStartWave
    {
        get { return timeToStartWave; }
    }

    public int RemainingEnemies
    {
        get { return remainingEnemies; }
    }

    public int CurrentWave
    {
        get { return currentWave; }
    }

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        CheckEnemyCount();
    }

    public void UpdateEnemiesCount()
    {
        remainingEnemies--;
        wInfo.UpdateEnemiesTxt(remainingEnemies);
        CheckEnemyCount();
    }

    private void CheckEnemyCount()
    {
        if (!GameController.Instance.IsGameOver)
        {
            if (remainingEnemies <= 0)
            {
                if (currentWave > 0)
                {
                    pHealth.AddHealth(); 
                }
                
                StartCoroutine(WaveCountdown());
            }    
        }
    }

    private IEnumerator WaveCountdown()
    {
        NextWave();
        wInfo.SetTimer();

        yield return new WaitForSeconds(timeToStartWave);

        StartWave();    
    }

    private void StartWave()
    {
        for (int i = 0; i < initialEnemies; i++)
        {
            GameObject tmp = ObjectPooler.Instance.GetPooledObject("Enemy");
            
            tmp.transform.position = GenerateSpawnPos();
            tmp.GetComponent<Enemy>().EnemyObj = enemies[Random.Range(0, enemies.Count)];
            tmp.SetActive(true);
        }
    }

    private void NextWave()
    {
        remainingEnemies = initialEnemies;

        if (initialEnemies < maxEnemies)
        {
            initialEnemies++;
        }
        currentWave++;
        wInfo.UpdateWaveTxt(currentWave);
        wInfo.UpdateEnemiesTxt(remainingEnemies);
    }

    private Vector3 GenerateSpawnPos()
    {
        return new Vector3(Random.Range(spawnAreaMinX, spawnAreaMaxX), Random.Range(spawnAreaMinY, spawnAreaMaxY));
    }
}
