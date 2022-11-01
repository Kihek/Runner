using UnityEngine;

public class WallScript : MonoBehaviour
{
    public Generator wallGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * wallGenerator.curSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            wallGenerator.generateNextDelay();
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
