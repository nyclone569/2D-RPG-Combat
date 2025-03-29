using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
   public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
   //Set speed for player
   [SerializeField] private float moveSpeed = 1f;

   //Use input actions map to create PlayerControl class and call it 
   private PlayerControls playerControls;

   //Store values incoming from player controls input
   private Vector2 movement;
   private Rigidbody2D rb;
   private Animator myAnimator;
   private SpriteRenderer mySpriteRenderer;

   private bool facingLeft = false;

   private void Awake() {
      playerControls = new PlayerControls();
      rb = GetComponent<Rigidbody2D>();
      myAnimator = GetComponent<Animator>();
      mySpriteRenderer = GetComponent<SpriteRenderer>();
   }

    private void OnEnable()
    {
        playerControls.Enable();
    }

   private void Update() {
      PlayerInput();
   }

   private void FixedUpdate() {
      AdjustPlayerFacingDirection();
      Move();
   }

   private void PlayerInput(){
      // read vectors from player controls class we created before
      movement = playerControls.Movement.Move.ReadValue<Vector2>();

      myAnimator.SetFloat("moveX", movement.x);
      myAnimator.SetFloat("moveY", movement.y);
   }

   private void Move(){
      rb.MovePosition(rb.position + movement*(moveSpeed*Time.fixedDeltaTime));
   }

   private void AdjustPlayerFacingDirection(){
      Vector3 mousePos = Input.mousePosition;
      Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

      if (mousePos.x < playerScreenPoint.x) {
         //flip player sprite
         mySpriteRenderer.flipX = true;
         FacingLeft = true;
      } else {
         mySpriteRenderer.flipX = false;
         FacingLeft = false;
      }
   }
}
