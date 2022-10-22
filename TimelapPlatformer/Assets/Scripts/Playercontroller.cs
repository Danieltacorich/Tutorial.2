using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Playercontroller : MonoBehaviour
{   
    private Rigidbody2D rd2d;
    public float speed;
   
    // Scoring & Life
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public TextMeshProUGUI livesText;
    private int count;
    private int lives;

    // Sprite & Animation
    Animator anim;
    private SpriteRenderer _renderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();

        // Score n Lives
        score = 0;
        lives = 5;
        score.text = scoreValue.ToString();
        lives.text = scoreValue.ToString(); 

        // Animation
        anim = GetComponent<Animator>();

        //Flip
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
        {
           Debug.LogError("Player Sprite is missing a renderer");
        }
        SetCountText();
    }

    void Update()
    {
        //Flip
          if (Input.GetAxisRaw("Horizontal") > 0)
          {
            _renderer.flipX = false;
          }
          else if (Input.GetAxisRaw("Horizontal") < 0)
          {
            _renderer.flipX = true;
          }   

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

       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       Vector2 position = transform.position;
       position.x = position.x + 3.0f * horizontal * Time.deltaTime;
       position.y = position.y + 3.0f * vertical * Time.deltaTime;
       transform.position = position;

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
            score = score + 1;
            Destroy(collision.collider.gameObject);
            SetCountText();
        }
        else if (collision.collider.tag == "Enemy")
        {
            lives = lives - 1;
            SetCountText();
        }
        if (collision.collider.tag == "Death")
        {
            lives = lives - 1;
            transform.position = new Vector3(0 , 0 , 0 );
            SetCountText();
        }

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
