using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State {
        Roaming
    }

    private State state;
    private EnemyPathfinding enemyPathfinding;

    private void Awake() {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.Roaming;
    }

    private IEnumerator RoamingRoutine(){
        while(state == State.Roaming){
            Vector2 roamPosition = GetRoamingPosition();
            enemyPathfinding.MoveTo(roamPosition);
            yield return new WaitForSeconds(2f);
        }
    }

    //Generate a random direction for mobs
    private Vector2 GetRoamingPosition(){
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(RoamingRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
