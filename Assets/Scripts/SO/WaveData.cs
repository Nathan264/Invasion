using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Object/WaveData")]
public class WaveData : ScriptableObject
{
    [SerializeField] private int timeToStartWave;
    [SerializeField] private int currentWave = 0;
    [SerializeField] private int initialEnemies;
    [SerializeField] private int maxEnemies;
    [SerializeField] private int remainingEnemies;
    [SerializeField] private int spawnAreaMinX;
    [SerializeField] private int spawnAreaMaxX;
    [SerializeField] private int spawnAreaMinY;
    [SerializeField] private int spawnAreaMaxY;

    public int TimeToStartWave
    {
        get { return timeToStartWave; }
        set { timeToStartWave = value; }
    }
    public int CurrentWave
    {
        get { return currentWave; }
        set { currentWave = value; }
    }
    public int InitialEnemies
    {
        get { return initialEnemies; }
        set { initialEnemies = value; }
    }
    public int MaxEnemies
    {
        get { return maxEnemies; }
        set { maxEnemies = value; }
    }
    public int RemainingEnemies
    {
        get { return remainingEnemies; }
        set { remainingEnemies = value; }
    }
    public int SpawnAreaMinX
    {
        get { return spawnAreaMinX; }
        set { spawnAreaMinX = value; }
    }
    public int SpawnAreaMaxX
    {
        get { return spawnAreaMaxX; }
        set { spawnAreaMaxX = value; }
    }
    public int SpawnAreaMinY
    {
        get { return spawnAreaMinY; }
        set { spawnAreaMinY = value; }
    }
    public int SpawnAreaMaxY
    {
        get { return spawnAreaMaxY; }
        set { spawnAreaMaxY = value; }
    }

}
