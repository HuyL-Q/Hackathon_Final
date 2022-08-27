using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static Vector3[] wayPoint0;
    public static Vector3[] wayPoint1;
    public static Vector3[] wayPoint2;
    public static Vector3[] Starts;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private static int waveIndex;
    public static int EnemiesAlive;
    public class VectorConverter : JsonConverter<List<Vect3>> { }
    public class WaveControlConverter : JsonConverter<List<WaveControllerJs>> { };
    List<WaveControllerJs> wcList;
    public static T[] grow<T>(T[] v)
    {
        T[] v2 = new T[v.Length + 5];
        for (int i = 0; i < v.Length; i++)
            v2[i] = v[i];
        return v2;
    }
    public static int WaveIndex { get => waveIndex; set => waveIndex = value; }
    public class WaveControllerJs
    {
        public int waveid;
        public int enemy_01_1;
        public int enemy_01_2;
        public int enemy_01_3;
        public int enemy_01_4;
        public int boss_01;
        public int boss_02;
        public int boss_03;
        public int boss_04;
        public WaveControllerJs() { }
        public WaveControllerJs(int waveid, int enemies_01_1, int enemies_01_2, int enemies_01_3, int enemies_01_4, int bossy_01, int bossy_02, int bossy_03, int bossy_04)
        {
            this.waveid = waveid;
            this.enemy_01_1 = enemies_01_1;
            this.enemy_01_2 = enemies_01_2;
            this.enemy_01_3 = enemies_01_3;
            this.enemy_01_4 = enemies_01_4;
            this.boss_01 = bossy_01;
            this.boss_02 = bossy_02;
            this.boss_03 = bossy_03;
            this.boss_04 = bossy_04;

        }
    }
    public class Vect3
    {
        public string id;
        public float x;
        public float y;
        public float z;

        public Vect3(string id, float x, float y, float z)
        {
            this.id = id;
            this.z = z;
            this.x = x;
            this.y = y;
        }
    }
    void Start()
    {
        waveIndex = 1;
        EnemiesAlive = 0;
        Starts = new Vector3[3];
        wayPoint0 = new Vector3[5];
        wayPoint1 = new Vector3[8];
        wayPoint2 = new Vector3[7];
        VectorConverter vConv = new VectorConverter();
        vConv.setCurrentDir(@"\WaypointCoord.json");
        List<Vect3> VecAr = vConv.getObjectFromJSON();
        int startCount = 0;
        int wpCount0 = 0;
        int wpCount1 = 0;
        int wpCount2 = 0;
        foreach (Vect3 v in VecAr)
        {
            if (v.id.Equals("-1"))
            {
                Starts[startCount] = new Vector3(v.x, v.y, v.z);
                startCount++;
            }
            if (v.id.Equals("0"))
            {
                wayPoint0[wpCount0] = new Vector3(v.x, v.y, v.z);
                wpCount0++;
            }
            if (v.id.Equals("1"))
            {
                wayPoint1[wpCount1] = new Vector3(v.x, v.y, v.z);
                wpCount1++;
            }
            if (v.id.Equals("2"))
            {
                wayPoint2[wpCount2] = new Vector3(v.x, v.y, v.z);
                wpCount2++;
            }
        }
        WaveControlConverter wcc = new WaveControlConverter();
        wcc.setCurrentDir(@"\WaveController.json");
        wcList = wcc.getObjectFromJSON();
    }
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }
    WaveControllerJs LastWave = new WaveControllerJs();
    IEnumerator SpawnWave()
    {
        foreach (WaveControllerJs wc in wcList)
        {
            if (waveIndex == wc.waveid)
            {
                Debug.Log("Welcome Wave " + wc.waveid);
                for (int i = 0; i < wc.enemy_01_1; i++)
                {
                    string[] eid = { "enemy_01_1", "enemy_02_1", "enemy_03_1", "enemy_04_1", "enemy_05_1" };
                    gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < wc.enemy_01_2; i++)
                {
                    string[] eid = { "enemy_01_2", "enemy_02_2", "enemy_03_2", "enemy_04_2", "enemy_05_2" };
                    gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < wc.enemy_01_3; i++)
                {
                    string[] eid = { "enemy_01_3", "enemy_02_3", "enemy_03_3", "enemy_04_3", "enemy_05_3" };
                    gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < wc.enemy_01_4; i++)
                {
                    string[] eid = { "enemy_01_4", "enemy_02_4", "enemy_03_4", "enemy_04_4", "enemy_05_4" };
                    gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < wc.boss_01; i++)
                {
                    gameObject.GetComponent<BossFactory>().createEnemy("boss_01");
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < wc.boss_02; i++)
                {
                    gameObject.GetComponent<BossFactory>().createEnemy("boss_02");
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < wc.boss_03; i++)
                {
                    gameObject.GetComponent<BossFactory>().createEnemy("boss_03");
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                for (int i = 0; i < wc.boss_04; i++)
                {
                    gameObject.GetComponent<BossFactory>().createEnemy("boss_04");
                    EnemiesAlive++;
                    yield return new WaitForSeconds(0.2f);
                }
                waveIndex++;
                LastWave = wc;
                break;
            }
        }
        if (waveIndex > 40)
        {
            Debug.Log("Welcome Wave " + waveIndex);
            Debug.Log("There are " + LastWave.enemy_01_1 + " " + LastWave.enemy_01_2 + " " + LastWave.enemy_01_3 + " " + " " + (LastWave.enemy_01_4 + (waveIndex - LastWave.waveid) * 8) + " in this wave.");
            for (int i = 0; i < LastWave.enemy_01_1; i++)
            {
                string[] eid = { "enemy_01_1", "enemy_02_1", "enemy_03_1", "enemy_04_1", "enemy_05_1" };
                gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < LastWave.enemy_01_2; i++)
            {
                string[] eid = { "enemy_01_2", "enemy_02_2", "enemy_03_2", "enemy_04_2", "enemy_05_2" };
                gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < LastWave.enemy_01_3; i++)
            {
                string[] eid = { "enemy_01_3", "enemy_02_3", "enemy_03_3", "enemy_04_3", "enemy_05_3" };
                gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < (LastWave.enemy_01_4 + (waveIndex - LastWave.waveid) * 8); i++)
            {
                string[] eid = { "enemy_01_4", "enemy_02_4", "enemy_03_4", "enemy_04_4", "enemy_05_4" };
                gameObject.GetComponent<MinionFactory>().createEnemy(eid[Random.Range(0, 5)]);
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < LastWave.boss_01; i++)
            {
                gameObject.GetComponent<BossFactory>().createEnemy("boss_01");
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < LastWave.boss_02; i++)
            {
                gameObject.GetComponent<BossFactory>().createEnemy("boss_02");
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < LastWave.boss_03; i++)
            {
                gameObject.GetComponent<BossFactory>().createEnemy("boss_03");
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            for (int i = 0; i < LastWave.boss_04; i++)
            {
                gameObject.GetComponent<BossFactory>().createEnemy("boss_04");
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            if (waveIndex % 5 == 0)
            {
                gameObject.GetComponent<MinionFactory>().createEnemy("boss_04");
                EnemiesAlive++;
                yield return new WaitForSeconds(0.2f);
            }
            waveIndex++;
        }
    }
}