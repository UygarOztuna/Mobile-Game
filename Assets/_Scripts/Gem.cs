using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private Transform coinPos;

    void Start()
    {
        coinPos = GameManager.Instance.gemLocation;
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
        GameManager.Instance.gems += 1;
        GameManager.Instance.GemUpdate();
        Destroy(this.gameObject);
    }

    private void RandomSequences()
    {

        Sequence sequence2 = DOTween.Sequence();
        sequence2.Append(transform.DOMove(GameManager.Instance.animLoc1.position, 0.1f).SetEase(Ease.Linear));
        sequence2.Append(transform.DOMove(GameManager.Instance.animLoc2.position, 0.3f).SetEase(Ease.Linear));

        sequence2.Play();

        

    }
}