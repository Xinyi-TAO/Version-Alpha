using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    public float speed;
    public float Jumpforce;
    [SerializeField]private Animator anim;
    public LayerMask ground;
    public Collider2D coll;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SwitchAnim();

    }

    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal"); // [-1,0,1]
        float facedirection = Input.GetAxisRaw("Horizontal");
        //left & right
        if(horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
            anim.SetFloat("running",Mathf.Abs(facedirection));
        }
        //change face direction
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection,1,1);
        }
        //jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, Jumpforce);
            anim.SetBool("jumping", true);
        }
    }

    void SwitchAnim()
    {
        anim.SetBool("idle", false);

        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }

        if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling",false);
            anim.SetBool("idle",true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Collection")
        {
            Destroy(collision.gameObject);
            
        }

    }
}
