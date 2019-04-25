using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

    public int count;
    public Text countText;
    public float speed;
    public bool MoveRight;
    public GameObject blood;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

    void OnCollisionEnter2D (Collision2D col)
     {
         if (col.gameObject.tag.Equals("Bullet"))
         {
             Instantiate (blood, transform.position, Quaternion.identity);
             Destroy (col.gameObject);
             Destroy(gameObject);
             count = count + 1;
             SetCountText();
        }
     }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

}
