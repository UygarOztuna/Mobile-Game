using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopersKit : MonoBehaviour
{
    public static DevelopersKit Instance;

    [SerializeField] private GameObject developersKit;
    public bool canKill;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenTheKit()
    {
        developersKit.SetActive(true);
    }

    public void CloseTheKit()
    {
        developersKit.SetActive(false);
    }

    public void LevelUp()
    {
        LevelChange.Instance.levelUpCount = LevelChange.Instance.levelUpLine;
    }

    public void KillTheMonster()
    {
        canKill = true;
    }
}
