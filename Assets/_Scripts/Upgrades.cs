using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Upgrades : MonoBehaviour
{
    public static Upgrades Instance;

    [SerializeField] private GameObject upgradeBox;
    private Vector3 upgradeBoxPos;
    public int upgradeMoney = 500;
 


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        upgradeBoxPos = upgradeBox.transform.position;
    }


    void Update()
    {
       

        
    }

    public void PowerUp()
    {
        if(GameManager.Instance.coins >= upgradeMoney)
        {
            GameManager.Instance.damage += 10;
            GameManager.Instance.coins -= upgradeMoney;
            GameManager.Instance.CoinUpdate();
            upgradeMoney += 500;

        }
        
    }

   

    public void CloseUpgradeBox()
    {
        upgradeBox.transform.DOMove(upgradeBoxPos, 0.3f).SetEase(Ease.Linear);
    }
    public void OpenUpgradeBox()
    {
        upgradeBox.transform.DOMove(LevelChange.Instance.levelLoc1.position, 0.3f).SetEase(Ease.Linear);
    }

    
}
