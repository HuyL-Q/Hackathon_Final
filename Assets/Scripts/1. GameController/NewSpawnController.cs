using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawnController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawnStartPos;
    //[SerializeField]
    //List<GameObject> enemyToSpawn;
    private int waveIndex;
    private bool isWaveEnded;
    [SerializeField]
    private int numOfEnemies;
    [SerializeField]
    private int currentNumOfEnemies;
    public int WaveIndex { get => waveIndex; }
    public bool IsWaveEnded { get => isWaveEnded; }

    public static NewSpawnController Instance { get; private set; }
    public int CurrentNumOfEnemies { get => currentNumOfEnemies; set => currentNumOfEnemies = value; }
    public int NumOfEnemies { get => numOfEnemies; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isWaveEnded = true;
        waveIndex = 0;
        numOfEnemies = 3;
        CurrentNumOfEnemies = NumOfEnemies;
        gameObject.AddComponent<MinionFactory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.State == State.End_Defeat)
        {
            StopCoroutine(SpawnWave());
            return;
        }
        if (isWaveEnded)
        {
            StartCoroutine(SpawnWave());
            isWaveEnded = false;
        }
        if (CurrentNumOfEnemies == 0)
        {
            isWaveEnded = true;
            numOfEnemies++;
            CurrentNumOfEnemies = numOfEnemies;
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        StoryUIController.instance.UpdateWaveIndex();
        for (int i = 0; i < NumOfEnemies; i++)
        {
            gameObject.GetComponent<MinionFactory>().CreateEnemy(spawnStartPos[Random.Range(0, spawnStartPos.Count)]);
            yield return new WaitForSeconds(1.5f);
            //Instantiate(enemyToSpawn[Random.Range(0, enemyToSpawn.Count)], spawnStartPos[Random.Range(0, spawnStartPos.Count)].transform);
        }
    }
}
