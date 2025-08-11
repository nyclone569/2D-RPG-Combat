using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public bool IsDead {get; private set;}

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;
    const string HEALTH_BAR_TEXT = "Health Bar";
    const string SPAWN_TEXT = "Scene1";
    readonly int DEATH_HASH = Animator.StringToHash("Death");

    protected override void Awake() {
        base.Awake();
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    private void Start() {
        IsDead = false;
        currentHealth = maxHealth;

        UpdateHealthSlider();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();

        if(enemy){
            TakeDamage(1, other.transform);
            
        }
    }

    public void HealPlayer(){
        if(currentHealth < maxHealth){
            currentHealth +=1;
            UpdateHealthSlider();
        }
    }

    public void TakeDamage(int damageAmount, Transform hitTransform){
        if(!canTakeDamage) {return;}
        AudioManager.Instance.PlaySFX("PlayerHurt");
        ScreenShakeManager.Instance.ShakeScreen();
        knockBack.GetKnockedBack(hitTransform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        CheckIfPlayerDeath();
    }

    private IEnumerator DamageRecoveryRoutine(){
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    private void CheckIfPlayerDeath(){
        if (currentHealth <=0 && !IsDead){
            IsDead=true;            
            currentHealth =0;            
            StartCoroutine(DeathLoadSceneRoutine());
        }
    }

    private IEnumerator DeathLoadSceneRoutine()
    {
        ActiveWeapon.Instance.DisableCombat();
        canTakeDamage = false;
        GetComponent<Animator>().SetTrigger(DEATH_HASH);
        yield return new WaitForSeconds(2f);
        Stamina.Instance.ReplenishStaminaOnDeath();
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(SPAWN_TEXT);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.position = Vector3.zero;
        IsDead = false;
        canTakeDamage = true;
        ActiveWeapon.Instance.EnableCombat();
        currentHealth = maxHealth;
        UpdateHealthSlider();
        Animator animator = GetComponent<Animator>();
        animator.ResetTrigger(DEATH_HASH);
        animator.Play("Idle");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find(HEALTH_BAR_TEXT).GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
