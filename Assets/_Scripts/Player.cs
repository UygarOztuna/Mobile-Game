using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator animator;
    public int health;
    private bool isDamaged;
    private bool damageDelay;


    void Start()
    {
        animator = GetComponent<Animator>();
        health += LevelChange.Instance.level * 10;
        HealthBar.Instance.SetMaxHealth(health);
        if (LevelChange.Instance.level == LevelChange.Instance.levelUpButtonCheck)
        {
            LevelChange.Instance.normalCounter.SetActive(true);
            LevelChange.Instance.timerCounter.SetActive(false);
        }

    }


    void Update()
    {
        Die();
        TakeDamage();
        TakeCircle();

        if(LevelChange.Instance.destroyPlayer)
        {
            LevelChange.Instance.destroyPlayer = false;
            Destroy(this.gameObject);
        }
    }

    private void Die()
    {
        if (health <= 0 || DevelopersKit.Instance.canKill)
        {
            DevelopersKit.Instance.canKill = false;
            StartCoroutine(DeathAnimation());
        }
    }

    private void TakeDamage()
    {
        if(isDamaged)
        {
            animator.SetTrigger("attack");
            health -= GameManager.Instance.damage;
            HealthBar.Instance.SetHealth(health);
            isDamaged = false;
           
        }
        
    }

    private void TakeCircle()
    {
        if(Circle.Instance.isCirle)
        {
            animator.SetTrigger("attack");
            health -= GameManager.Instance.skillDamage;
            HealthBar.Instance.SetHealth(health);
            Circle.Instance.isCirle = false;
        }
    }
   

    IEnumerator DeathAnimation()
    {
        
            animator.SetBool("isDead", true);

            yield return new WaitForSeconds(1.5f);
            GameManager.Instance.CoinSpawn();
            LevelChange.Instance.levelUpCount += 1;
            LevelChange.Instance.killCountText.text = LevelChange.Instance.levelUpCount.ToString();
            Spawner.Instance.canSpawn = true;

            Destroy(this.gameObject);
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Blade") && !damageDelay)
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

    
