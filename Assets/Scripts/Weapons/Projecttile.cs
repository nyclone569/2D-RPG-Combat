using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projecttile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private bool isEnemyProjectile = false;
    [SerializeField] private float projectileRange = 10f;
    
    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }

    private void Update() {
        MoveProjectTile();  
        DetectFireDistance();
    }
    public void UpdateProjectileRange(float projectileRange){
        this.projectileRange = projectileRange; 
    }

    public void UpdateMoveSpeed(float moveSpeed){
        this.moveSpeed = moveSpeed; 
    }

    public bool CheckIsEnemyProjectile()
    {
        return isEnemyProjectile;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = other.gameObject.GetComponent<Indestructible>();
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (!other.isTrigger && (enemyHealth || indestructible || player))
        {
            if ((player && isEnemyProjectile) || (enemyHealth && !isEnemyProjectile))
            {
                player?.TakeDamage(1, transform);
                // Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                // Destroy(gameObject);
                LeanPool.Spawn(particleOnHitPrefabVFX, transform.position, transform.rotation);
                LeanPool.Despawn(gameObject);
            }
            else if (!other.isTrigger && indestructible)
            {
                LeanPool.Spawn(particleOnHitPrefabVFX, transform.position, transform.rotation);
                LeanPool.Despawn(gameObject);
            }
        }
    }

    private void DetectFireDistance(){
        if(Vector3.Distance(transform.position, startPosition) > projectileRange ){
            LeanPool.Despawn(gameObject);
        }
    }

    private void MoveProjectTile(){
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
    }
}
