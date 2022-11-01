using UnityEngine;

public class BunnyScript : MonoBehaviour
{
    public Generator bunnyGenerator;

    Rigidbody2D RB;

    public bool OnGround = false;
    bool canJump = false;

    public float JumpForce;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * bunnyGenerator.curSpeed * Time.deltaTime);
        if (OnGround == true && canJump == true)
        {
            RB.AddForce(Vector2.up * JumpForce);
            OnGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            bunnyGenerator.generateNextDelay();
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (OnGround == false)
            {
                OnGround = true;
            }
        }

        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }

    }
}
