using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public BoxCollider2D Crouching;
    public BoxCollider2D Standing;

    PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerScript>();

        Crouching.enabled = false;
        Standing.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.OnGround == false)
        {
            Crouching.enabled = false;
            Standing.enabled = true;
        }
        else
        {
            if(player.IsCrouching == true)
            {
                Crouching.enabled = true;
                Standing.enabled = false;
            }
            else
            {
                Crouching.enabled = false;
                Standing.enabled = true;
            }
        }
    }
}
