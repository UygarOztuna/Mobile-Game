using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins2 : MonoBehaviour
{
    private Transform coinPos;

    void Start()
    {
        coinPos = GameManager.Instance.coinLocation;
        RandomSequences();
        StartCoroutine(Coin());
    }


    void Update()
    {

    }

    IEnumerator Coin()
    {

        yield return new WaitForSeconds(1.5f);
        transform.DOMove(coinPos.position, 0.4f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.4f);
        GameManager.Instance.coins += 100;
        GameManager.Instance.CoinUpdate();
        Destroy(this.gameObject);
    }

    private void RandomSequences()
    {

        Sequence sequence1 = DOTween.Sequence();
        sequence1.Append(transform.DOMove(GameManager.Instance.animLoc3.position, 0.1f).SetEase(Ease.Linear));
        sequence1.Append(transform.DOMove(GameManager.Instance.animLoc4.position, 0.3f).SetEase(Ease.Linear));



       

        sequence1.Play();

        //int randomIndex = Random.Range(0, 2);

        //if(randomIndex == 0)
        //{
        //    sequence1.Play();
        //}
        //else if(randomIndex == 1)
        //{
        //    sequence1.Play();
        //}

    }
}