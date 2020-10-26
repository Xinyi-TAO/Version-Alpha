using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    //private float horizontalMovement;
/*
  void FixedUpdate(){
    float horizontalMovement = Input.GetAxis("Horizontal")* moveSpeed * Time.deltaTime;
    if (Input.GetButtonDown("Jump")){
      isJumping = true;
    }
    MovePlayer(horizontalMovement);
  }

  void MovePlayer(float _horizontalMovement){
    Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
    rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    if(isJumping==true){
      rb.AddForce(new Vector2(0f, jumpForce));
      isJumping = false;
    }
  }
*/
    void Update(){
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
      if(isGrounded || (!isGrounded && rb.velocity.y <0.1)){
        animator.SetBool("IsJumping", false);
      }
      else{
          animator.SetBool("IsJumping", true);
      }
      if(!isGrounded && rb.velocity.y < -0.1){
        animator.SetBool("IsFalling", true);
      }
      else{
        animator.SetBool("IsFalling", false);
      }
      //horizontalMovement = moveSpeed * Time.deltaTime;


      if (Input.GetButtonDown("Jump") && isGrounded){
        isJumping = true;
      }

      Flip(rb.velocity.x);


      float characterVelocity = Mathf.Abs(rb.velocity.x);
      animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
      float horizontalMovement = Input.GetAxis("Horizontal")* moveSpeed * Time.deltaTime;
      MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true){
          rb.AddForce(new Vector2(0f, jumpForce));
          isJumping = false;
        }
    }

    void Flip(float _velocity){
       if(_velocity > 0.1f){
         spriteRenderer.flipX = false;
       }else if (_velocity < -0.1f){
         spriteRenderer.flipX = true;
       }
    }

    private void OnDrawGizmos(){
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
