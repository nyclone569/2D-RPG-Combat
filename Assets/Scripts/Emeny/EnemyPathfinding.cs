using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private KnockBack knockBack;
    private SpriteRenderer spriteRenderer;

    private void Awake(){
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {        
        if (knockBack.GettingKnockedBack){
            return;
        }
      rb.MovePosition(rb.position + moveDirection*(moveSpeed*Time.fixedDeltaTime));

      if(moveDirection.x <0){
            spriteRenderer.flipX =true;
      } else {
        spriteRenderer.flipX =false;
      }
    }

    public void MoveTo(Vector2 targetPosition){
        moveDirection = targetPosition;
    }

    public void StopMoving(){
        moveDirection = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
