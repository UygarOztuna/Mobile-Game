using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;

    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] enemyPrefab2;
    [SerializeField] private GameObject[] enemyPrefab3;
    [SerializeField] private GameObject[] enemyPrefab4;
    [SerializeField] private GameObject[] firsBossPrefab;
    [SerializeField] private GameObject[] specialMonstersPrefab;
    [SerializeField] private Transform spawnLocation;
    public bool canSpawn = false;
    private int whichNormalSpawner = 1;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        canSpawn = true;
    }

    
    void Update()
    {
        WhichSpawner();
        SpawnNewEnemy();

    }

    public void SpawnNewEnemy()
    {
        //if(canSpawn)
        //{
        //    if(LevelChange.Instance.level == 10 || LevelChange.Instance.level == 20 || LevelChange.Instance.level == 30 || LevelChange.Instance.level == 40
        //        || LevelChange.Instance.level == 50 || LevelChange.Instance.level == 60 || LevelChange.Instance.level == 70 || LevelChange.Instance.level == 80)
        //    {
                
        //            HealthBar.Instance.ChangeToBossHealthBar();
        //            LevelChange.Instance.levelUpLine = 1;
        //            Instantiate(firsBossPrefab, spawnLocation.position, Quaternion.identity);
        //            canSpawn = false;

                
        //    }
        //    else
        //    {
        //        HealthBar.Instance.ChangeToNormalHealthBar();
        //        LevelChange.Instance.levelUpLine = 10;             

        //        switch (whichNormalSpawner)
        //        {
        //            case 1:
        //                Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnLocation.position, Quaternion.identity);
        //                canSpawn = false;
        //                break;

        //            case 2:
        //                Instantiate(enemyPrefab2[Random.Range(0, enemyPrefab.Length)], spawnLocation.position, Quaternion.identity);
        //                canSpawn = false;
        //                break;
        //        }
        //    }
            
            
         
        //}

        if(canSpawn)
        {
            switch(LevelChange.Instance.level)
            {
                case 5:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(specialMonstersPrefab[0], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;
                case 10:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(firsBossPrefab[0], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;
                case 15:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(specialMonstersPrefab[1], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;
                case 20:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(firsBossPrefab[1], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;
                case 25:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(specialMonstersPrefab[2], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;
                case 30:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(firsBossPrefab[2], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;
                case 35:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(specialMonstersPrefab[3], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;
                case 40:
                    HealthBar.Instance.ChangeToBossHealthBar();
                    LevelChange.Instance.levelUpLine = 1;
                    Instantiate(firsBossPrefab[3], spawnLocation.position, Quaternion.identity);
                    canSpawn = false;
                    break;


                default:
                    HealthBar.Instance.ChangeToNormalHealthBar();
                    LevelChange.Instance.levelUpLine = 10;

                    switch (whichNormalSpawner)
                    {
                        case 1:
                            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnLocation.position, Quaternion.identity);
                            canSpawn = false;
                            break;

                        case 2:
                            Instantiate(enemyPrefab2[Random.Range(0, enemyPrefab.Length)], spawnLocation.position, Quaternion.identity);
                            canSpawn = false;
                            break;
                        case 3:
                            Instantiate(enemyPrefab3[Random.Range(0, enemyPrefab.Length)], spawnLocation.position, Quaternion.identity);
                            canSpawn = false;
                            break;
                        case 4:
                            Instantiate(enemyPrefab4[Random.Range(0, enemyPrefab.Length)], spawnLocation.position, Quaternion.identity);
                            canSpawn = false;
                            break;
                    }

                    break;
            }
        }
        
    }


    private void WhichSpawner()
    {      
        switch(LevelChange.Instance.level)
        {
            case 10: 
                whichNormalSpawner = 2;
                break;
            case 20:
                whichNormalSpawner = 3;
                break;
            case 30:
                whichNormalSpawner = 4;
                break;
        }
    }
}
