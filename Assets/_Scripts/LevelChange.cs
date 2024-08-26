using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using DG.Tweening;

public class LevelChange : MonoBehaviour
{
    public static LevelChange Instance;

    public GameObject normalCounter;
    public GameObject timerCounter;

    public TextMeshProUGUI timerText;
    public float timeRemaining = 20f;
    public float timeRemainingReset;
    public bool timerIsRunning = false;
    public bool timeEnds;

    public TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelLine;
    public TextMeshProUGUI killCountText;
    [SerializeField] private GameObject levelChangeFilter;
    public Transform levelLoc1;
    [SerializeField] private Transform levelLoc2;
    public int level = 1;
    public int levelUpCount = 0;
    public int levelUpLine = 10;
    public int levelUpButtonCheck = 1;
    public bool levelUpSafety;
    private Vector3 levelFilterStartPos;

    [SerializeField] private Color[] bgColors;
    [SerializeField] private SpriteRenderer bg;

    public bool destroyPlayer;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {       
        levelText.text = level.ToString();
        killCountText.text = levelUpCount.ToString();
        levelLine.text = levelUpLine.ToString();
        levelFilterStartPos = levelChangeFilter.transform.position;
    }

    void Update()
    {
        if(levelUpCount >= levelUpLine && !levelUpSafety)
        {
            levelUpButtonCheck++;
            levelUpSafety = true;
        }

        if(levelUpCount == levelUpLine)
        {
            normalCounter.SetActive(false);
        }

        Timer();
    }

    public void Timer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Geri sayýmý yap
                timeRemaining -= Time.deltaTime;
                timerText.text = Mathf.Ceil(timeRemaining).ToString();
            }
            else
            {
                // Geri sayým bittiðinde timer'ý durdur
                timeRemaining = 0;
                timeEnds = true;
                timerIsRunning = false;
                timerText.text = "Süre Doldu!";
            }
        }
    }


    public void LevelUpButton()
    {
        if(level < levelUpButtonCheck)
        {
            destroyPlayer = true;
            StartCoroutine(LevelUpButtonEnumerator());
            levelUpSafety = false;
            normalCounter.SetActive(false);
            timerCounter.SetActive(false);
            timerIsRunning = false;
            VeriYoneticisi.Instance.VeriyiKaydet();
        }
        
        
    }

    public void LevelDowndButton()
    {
        if(level != 1)
        {
            destroyPlayer = true;            
            StartCoroutine(LevelDownEnumerator());
            normalCounter.SetActive(false);
            timerCounter.SetActive(false);
            timerIsRunning = false;
            VeriYoneticisi.Instance.VeriyiKaydet();
        }
        
        
    }

    IEnumerator LevelUpButtonEnumerator()
    {
        levelChangeFilter.transform.DOMove(levelLoc1.position, 0.5f).SetEase(Ease.Linear);
        level++;
        levelText.text = level.ToString();
        levelUpCount = 0;
        killCountText.text = levelUpCount.ToString();
        yield return new WaitForSeconds(1f);
        Spawner.Instance.canSpawn = true;
        Spawner.Instance.SpawnNewEnemy();
        bg.color = bgColors[Random.Range(0, bgColors.Length)];
        levelChangeFilter.transform.DOMove(levelLoc2.position, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.6f);
        levelChangeFilter.transform.position = levelFilterStartPos;
    }

    IEnumerator LevelDownEnumerator()
    {
        levelChangeFilter.transform.DOMove(levelLoc1.position, 0.5f).SetEase(Ease.Linear);
        level--;
        levelText.text = level.ToString();
        levelUpCount = 0;
        killCountText.text = levelUpCount.ToString();
        yield return new WaitForSeconds(1f);
        Spawner.Instance.canSpawn = true;
        Spawner.Instance.SpawnNewEnemy();
        bg.color = bgColors[Random.Range(0, bgColors.Length)];
        levelChangeFilter.transform.DOMove(levelLoc2.position, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.6f);
        levelChangeFilter.transform.position = levelFilterStartPos;
    }


}
