using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 4.0f;
    private Rigidbody2D rb;
    private float movement = 0.0f;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).transform.GetComponent<Animator>();
        spriteRenderer = transform.GetChild(0).transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        movement = Input.GetAxisRaw("Horizontal") * speed;        
        if (movement > 0.01f)
        {
            anim.SetInteger("Direction", 1); spriteRenderer.flipX = true;
            Debug.Log("RIGHT");
        }
        else if(movement < 0.01f)
        {
            anim.SetInteger("Direction", -1); spriteRenderer.flipX = false;            
            Debug.Log("LEFT");
        }
        if(movement == 0f)
        {
            anim.SetInteger("Direction", 0);
            Debug.Log("IDLE");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0.0f));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Ball"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
