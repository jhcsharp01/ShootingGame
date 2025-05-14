using UnityEngine;

//유닛 1개 생성기
public class EnemyManager : MonoBehaviour
{
    float currentTime; //현재 시간
    public float step = 1;//시간 간격
    public GameObject enemyFactory; //적 공장

    //오브젝트 풀
    [Header("오브젝트 풀")]
    public int poolSize = 10;             
    public GameObject[] pool;
    public Transform[] spawnPoint; //기존의 생성 위치

    //기존 방식 : EnemyManager.cs를 연결한 생성 지점을 배치해서
    //            무한 생성

    //바꾸는 방식 : EnemyManager는 1개, 생성 지점을 연결해
    //              해당 지점에 시간에 맞춰 활성화


    //태어날 때에 대한 작업
    private void Start()
    {
        pool = new GameObject[poolSize];
        
        for(int i = 0;  i < poolSize; i++)
        {
            var enemy = Instantiate(enemyFactory);
            pool[i] = enemy;
            enemy.SetActive(false);
        }

    }


    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > step)
        {
            var enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            enemy.transform.parent = transform;
            currentTime = 0;
        }
    }
}
