using UnityEngine;

public class SpriteChanger : MonoBehaviour
{

    public Sprite spriteCrouch;
    public Sprite spriteStand;
    private SpriteRenderer spriteRenderer;
    PlayerScript player;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer.sprite = spriteStand;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsCrouching == true)
        {
            spriteRenderer.sprite = spriteCrouch;
        }
        else
        {
            spriteRenderer.sprite = spriteStand;
        }
    }
}
