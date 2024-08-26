using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject[] coinPrefabs;
    [SerializeField] private GameObject gemPrefab;
    
    public Transform coinLocation;
    public Transform gemLocation;
    public Transform animLoc1;
    public Transform animLoc2;
    public Transform animLoc3;
    public Transform animLoc4;
    public Transform animLoc5;
    public Transform animLoc6;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gemText;



    [SerializeField] private Transform spawnLocation;
    public bool isCoin = false;

    public int coins;
    public int gems;
    public int damage;
    public int skillDamage;

    public bool gemSpawn = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        
    }

    void Start()
    {
        coinText.text = coins.ToString();
        gemText.text = gems.ToString();        

    }

    void Update()
    {
        
        
    }

    public void CoinUpdate()
    {
        coinText.text = coins.ToString();
        VeriYoneticisi.Instance.VeriyiKaydet();
    }

    public void GemUpdate()
    {
        gemText.text = gems.ToString();
      
    }

    public void CoinSpawn()
    {
        

        if(gemSpawn)
        {
            Instantiate(gemPrefab, spawnLocation.position, Quaternion.identity);
            gemSpawn = false;
        }
        else
        {
            int spawnCount = Random.Range(0, coinPrefabs.Length);
            int i = 0;

            foreach (var item in coinPrefabs)
            {
                if (i! >= spawnCount)
                {
                    Instantiate(item, spawnLocation.position, Quaternion.identity);
                }

                i++;
            }
        }



    }

    




}
