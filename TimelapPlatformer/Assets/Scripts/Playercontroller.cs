using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{   
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    Animator anim;
    private bool facingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        //Right
        if (Input.GetKeyDown(KeyCode.D))
        {

          anim.SetInteger("State", 1);

         }
        
        if (Input.GetKeyUp(KeyCode.D))
        {

          anim.SetInteger("State", 0);

         }

        //Left
        if (Input.GetKeyDown(KeyCode.A))
        {

          anim.SetInteger("State", 1);

         }
         
         if (Input.GetKeyUp(KeyCode.A))
        {

          anim.SetInteger("State", 0);

         }

        //Sprint
        if (Input.GetKeyDown(KeyCode.R))
        {

          anim.SetInteger("State", 2);

         }

         if (Input.GetKeyUp(KeyCode.R))
        {
          
          anim.SetInteger("State", 0);
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {

          anim.SetInteger("State", 3);

         }

         if (Input.GetKeyUp(KeyCode.W))
        {
          
          anim.SetInteger("State", 0);
        }
        //Character Flipping
        animator.SetFloat("HorizontalValue", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("VerticalValue", Input.GetAxis("Vertical"));

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }

        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }
    }

    //Flip scaler
     void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); 
            }
        }
    }
}
