using UnityEngine;

public class BoosterScript : MonoBehaviour
{
    public Generator boosterGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * boosterGenerator.curSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            boosterGenerator.generateNextDelay();
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
            Destroy(this.gameObject);
        }
    }
}
