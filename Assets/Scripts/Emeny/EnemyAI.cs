using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Timer that mobs keep roaming at that direction
    [SerializeField] private float roamChangerDirFloat = 2f;
    [SerializeField] private float attackRange =0f;
    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float AttackCooldown = 2f; 
    [SerializeField] private bool stopMovingWhileAttacking = false;

    private bool canAttack = true;
    private enum State {
        Roaming,
        Attacking
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Vector2 roamPosition; 
    private float timeRoaming = 0f;

    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    // Start is called before the first frame update
    private void Start()
    {
        roamPosition = GetRoamingPosition();   
    }

    // Update is called once per frame
    private void Update()
    {
        MovementStateControl();
    }

    private void MovementStateControl(){
        switch(state){

            default:
            case State.Roaming:
                Roaming();
            break;
            case State.Attacking:
                Attacking();
            break;
        }
    }
    private void Roaming(){
        timeRoaming += Time.deltaTime;

        enemyPathfinding.MoveTo(roamPosition);

        if(Vector2.Distance(transform.position, PlayerController.Instance.transform.position) < attackRange){
            state = State.Attacking;
        }

        if(timeRoaming > roamChangerDirFloat){
            roamPosition = GetRoamingPosition();
        }
    }
    private void Attacking(){
        if(Vector2.Distance(transform.position, PlayerController.Instance.transform.position) > attackRange){
            state = State.Roaming;
        }
        if(attackRange != 0 && canAttack){
            canAttack = false;
            (enemyType as IEnemy).Attack(); 

            if(stopMovingWhileAttacking){
                enemyPathfinding.StopMoving();
            } else {
                enemyPathfinding.MoveTo(roamPosition);
            }

            StartCoroutine(AttackCooldownRoutine());
        }
    }
    //Generate a random direction for mobs
    private Vector2 GetRoamingPosition(){
        timeRoaming = 0f;
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
    private IEnumerator AttackCooldownRoutine(){
        yield return new WaitForSeconds(AttackCooldown);
        canAttack = true;
    }
}
