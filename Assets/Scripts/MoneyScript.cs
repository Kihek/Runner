using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public Generator moneyGenerator;

       // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moneyGenerator.curSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            moneyGenerator.generateNextDelay();
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