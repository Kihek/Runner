using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public Generator barrelGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * barrelGenerator.curSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            barrelGenerator.generateNextDelay(); 
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }
}
