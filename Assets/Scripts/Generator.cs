using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject barrel;
    public GameObject wall;
    public GameObject coin;
    public GameObject bunny;
    public GameObject booster;

    public float minSpeed;
    public float maxSpeed;
    public float curSpeed;

    public float speedMultiplier;
    // Start is called before the first frame update
    void Awake()
    {
        curSpeed = minSpeed;
        generateBarrel();
    }

    public void generateNextDelay()
    {
        float randomDel;
        if (curSpeed >= 20)
        {
            randomDel = Random.Range(0.5f, 1.0f);
        }
        else
        {
            randomDel = Random.Range(0.8f, 2.0f);
        }
        
        int randomObs = Random.Range(1, 101);
        if (randomObs >= 1 && randomObs <= 40)
        {
            Invoke("generateBarrel", randomDel);
        }
        else
        {
            if (randomObs >= 41 && randomObs <= 80)
            {
                Invoke("generateWall", randomDel);
            }
            else
            {
                if (randomObs >= 81 && randomObs <= 90)
                {
                    Invoke("generateBunny", randomDel);
                }
                else
                {
                    if (randomObs >= 91 && randomObs <= 95)
                    {
                        Invoke("generateCoin", randomDel);
                    }
                    else
                    {
                        Invoke("generateBooster", randomDel);
                    }
                }
            }
        }        
    }

    void generateBarrel()
    {
        GameObject BarrelInst = Instantiate(barrel, transform.position, transform.rotation);
        BarrelInst.GetComponent<BarrelScript>().barrelGenerator = this;
    }

    void generateWall()
    {
        GameObject WallInst = Instantiate(wall, transform.position, transform.rotation);
        WallInst.GetComponent<WallScript>().wallGenerator = this;
    }

    void generateCoin()
    {
        GameObject CoinInst = Instantiate(coin, transform.position, transform.rotation);
        CoinInst.GetComponent<MoneyScript>().moneyGenerator = this;
    }

    void generateBunny()
    {
        GameObject BunnyInst = Instantiate(bunny, transform.position, transform.rotation);
        BunnyInst.GetComponent<BunnyScript>().bunnyGenerator = this;
    }

    void generateBooster()
    {
        GameObject BoosterInst = Instantiate(booster, transform.position, transform.rotation);
        BoosterInst.GetComponent<BoosterScript>().boosterGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (curSpeed < maxSpeed)
        {
            curSpeed += speedMultiplier;
        }
    }
}