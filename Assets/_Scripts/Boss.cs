using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator animator;
    public int healthBoss;
    private bool isDamaged;
    public int health;
    private bool damageDelay;

    void Start()
    {
        LevelChange.Instance.timeRemaining = LevelChange.Instance.timeRemainingReset;
        health = healthBoss;
        animator = GetComponent<Animator>();
        HealthBar.Instance.SetMaxHealth(healthBoss);
        LevelChange.Instance.normalCounter.SetActive(false);
        LevelChange.Instance.timerCounter.SetActive(true);
        LevelChange.Instance.timerIsRunning = true;
        
        
    }

    void Update()
    {

        Die();
        TakeDamage();
        TakeCircle();

        if (LevelChange.Instance.destroyPlayer)
        {
            LevelChange.Instance.destroyPlayer = false;
            Destroy(this.gameObject);
        }

        if(LevelChange.Instance.timeEnds)
        {
            LevelChange.Instance.timeEnds = false;
            healthBoss = health;
            LevelChange.Instance.timeRemaining = LevelChange.Instance.timeRemainingReset;
            LevelChange.Instance.timerIsRunning = true;
        }
    }

    private void Die()
    {
        if (healthBoss <= 0 || DevelopersKit.Instance.canKill)
        {
            DevelopersKit.Instance.canKill = false;
            StartCoroutine(DeathAnimation());
            
        }
    }

    private void TakeDamage()
    {
        if (isDamaged)
        {
            animator.SetTrigger("attack");
            healthBoss -= GameManager.Instance.damage;
            HealthBar.Instance.SetHealth(healthBoss);
            isDamaged = false;

        }

    }

    private void TakeCircle()
    {
        if (Circle.Instance.isCirle)
        {
            animator.SetTrigger("attack");
            healthBoss -= GameManager.Instance.skillDamage;
            HealthBar.Instance.SetHealth(healthBoss);
            Circle.Instance.isCirle = false;
        }
    }

    IEnumerator DeathAnimation()
    {
        
            animator.SetBool("isDead", true);

            yield return new WaitForSeconds(1.5f);
            GameManager.Instance.gemSpawn = true;
            GameManager.Instance.CoinSpawn();
            LevelChange.Instance.levelUpCount += 1;           
            LevelChange.Instance.killCountText.text = LevelChange.Instance.levelUpCount.ToString();
            Spawner.Instance.canSpawn = true;


            Destroy(this.gameObject);
        
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blade") && !damageDelay)
        {
            StartCoroutine(DamageDelay());
        }
    }

    IEnumerator DamageDelay()
    {
        damageDelay = true;
        isDamaged = true;
        yield return new WaitForSeconds(0.1f);
        damageDelay = false;


    }

}
