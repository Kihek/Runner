using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;
    float highscore;
    [SerializeField, Range(0,20)]
    int money = 5;

    public bool OnGround = false;
    public bool IsBoosted = false;
    bool IsAlive = true;
    public bool IsCrouching = false;
    bool CanJump = true;

    Rigidbody2D RB;

    public Text ScoreTxt;
    public Text CoinTxt;
    public Text GameOver;
    public Button YesBtn;
    public Button NoBtn;

    public GameObject gameover;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        gameover.SetActive(false);
        Time.timeScale = 1;
        highscore = PlayerPrefs.GetFloat("score");       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(OnGround == true && CanJump == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                OnGround = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (OnGround == true)
            {
                if (IsCrouching == false)
                {
                    IsCrouching = true;
                    CanJump = false;
                }
                else
                {
                    IsCrouching = false;
                    CanJump = true;
                }
            }           
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (money >= 5)
            {
                money -= 5;
                IsBoosted = true;
                CoinTxt.text = "Coins: " + money.ToString();
            }
        }

        if (IsAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE: " + score.ToString("F");
        }
        else
        {          
            if (score > highscore)
            {
                GameOver.text = "Вы проиграли\nНовый рекорд!\nВы набрали: " + score.ToString("F") + " очков\nХотите начать игру заново?";
            }
            else
            {
                GameOver.text = "Вы проиграли\nВы набрали: " + score.ToString("F") + " очков\nХотите начать игру заново?";
            }
            gameover.SetActive(true);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if(OnGround == false)
            {
                OnGround = true;
            }
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            money++;
            CoinTxt.text = "Coins: " + money.ToString();
        }

        if (collision.gameObject.CompareTag("barrel"))
        {
            if (IsBoosted == false)
            {
                IsAlive = false;
                Time.timeScale = 0;
                if (score > highscore)
                {
                    PlayerPrefs.SetFloat("score", score);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                IsBoosted = false;
            }

        }

        if (collision.gameObject.CompareTag("wall"))
        {
            if (IsBoosted == false)
            {
                IsAlive = false;
                Time.timeScale = 0;
                if(score > highscore)
                {
                    PlayerPrefs.SetFloat("score", score);
                    PlayerPrefs.Save();
                }              
            }
            else
            {
                IsBoosted = false;
            }
        }

        if (collision.gameObject.CompareTag("bunny"))
        {
            if (IsBoosted == false)
            {
                IsAlive = false;
                Time.timeScale = 0;
                if (score > highscore)
                {
                    PlayerPrefs.SetFloat("score", score);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                IsBoosted = false;
            }
        }

        if (collision.gameObject.CompareTag("booster"))
        {
            IsBoosted = true;
        }
    }
}
