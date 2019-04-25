using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterNapolean : MonoBehaviour
{
    public float moveSpeed = 3f;
    float velX;
    float velY;
    bool facingRight = true;
    Rigidbody2D rigBody;
    public static float healthAmount;
    public GameObject gameOverText, restartButton, blood;
    public static CharacterNapolean instance;

    public float jumpForce;
    bool isJumping;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
        healthAmount = 1;
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(velX));
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(velX * moveSpeed, velY);
        Jump();

        if(healthAmount <= 0)
        {
            if(gameObject != null)
            {
                gameOverText.SetActive(true);
                restartButton.SetActive(true);
                Instantiate(blood, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
            
        }
    }

    void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if(velX > 0)
        {
            facingRight = true;
        } else if (velX < 0)
        {
            facingRight = false;
        }
        if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    void Jump()
    {
        if(Input.GetKeyDown (KeyCode.Space) && !isJumping)
        {
            isJumping = true;
           

            rigBody.AddForce(new Vector2 (rigBody.velocity.x, jumpForce));

        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            rigBody.velocity = Vector2.zero;

        }

        if (other.gameObject.tag.Equals("Enemy"))
        {
            healthAmount -= 0.1f;
        }

        else if (other.gameObject.tag.Equals("Enemy1"))
        {
            healthAmount -= 0.2f;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    

}
