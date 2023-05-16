using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{  
    public float speedRun,speedNext, jumpHeight;
    public bool isGround, isJumping, isStarted, isRun;
    public static PlayerController instance;
    public float positionY;
    Rigidbody player;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float nextPositionX;
    public Animator playerAnimator;
    public double percentRound;
    public SOCoin dataCoin;
    public AudioSource SFXCoin;
    public AudioSource SFXDefeat;
    public AudioSource SFXVictory;
    public AudioSource music;
    public bool isToStraight, isToTheLeft, isToTheRight, isNext;
    private void OnEnable()
    {
        instance = this;
    }

    //public void CheckRun()
    //{
    //    if (transform.position.x <= -nextPositionX )
    //    {
    //        isNext = false;
    //        isToTheLeft = false;
    //        isToTheRight = false;
    //        isToStraight = true;
    //        isGround = true;
    //    }
    //    if (transform.position.x >= -0.015 && transform.position.x <= 0.015)
    //    {
    //        isNext = false;
    //        isToTheLeft = false;
    //        isToTheRight = false;
    //        isToStraight = true;
    //        isGround = true;
    //    }
    //    if (transform.position.x >= nextPositionX)
    //    {
    //        isNext = false;
    //        isToTheRight = false;
    //        isToTheLeft = false;
    //        isToStraight = true;
    //        isGround = true;
    //    }
    //}
    public void MovePlayerRun()
    {
        if (isStarted == true && isRun == true )
        {
            if (isToStraight == true)
            {
                transform.Translate(0, 0, 1 * speedRun * Time.deltaTime);
            }
            if (isToTheLeft == true && isNext == true)
            {
                transform.Translate(-1 * speedNext * Time.deltaTime, 0, 0);
            }
            if (isToTheLeft == true && isNext == false)
            {
                transform.Translate(0, 0, 1 * speedRun * Time.deltaTime);
                isNext = true;
            }
            if (isToTheRight == true && isNext == true)
            {
                transform.Translate(1 * speedNext * Time.deltaTime, 0, 0);
            }
            if (isToTheRight == true && isNext == false)
            {
                transform.Translate(0, 0, 1 * speedRun * Time.deltaTime);
                isNext = true;

            }
        }
        
    }
    public void MovePlayerJump()
    {
        if (isGround == true && player.transform.position.y <= (positionY + 0.1))
        {
            player.velocity = Vector3.up * jumpHeight;
            isGround = false;
            isPress = true;
        }

    }

    // Start is called before the first frame update
    public Transform target;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        positionY = transform.position.y;
        CameraFollow.instance.target = transform;
    }

    public bool isPress;
    void Update()
    {
        MovePlayerRun();
        if (isPress == true)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isStarted == true)
            {
                startTouchPosition = Input.GetTouch(0).position;

            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isStarted == true)
            {
                endTouchPosition = Input.GetTouch(0).position;
                if (endTouchPosition.y - startTouchPosition.y > 500)
                {
                    isPress = false;                   
                    MovePlayerJump();
                }
                else if (endTouchPosition.x < startTouchPosition.x)
                {
                    isPress = false;                   
                    ToTheLeft();
                }
                else if (endTouchPosition.x > startTouchPosition.x)
                {
                    isPress = false;
                    ToTheRight();
                }
            }
        }
        
    }

    //public void MoveSlip()
    //{
    //    playerAnimator.SetTrigger("Slip");
    //    StartCoroutine(BackRun());
    //}
    //IEnumerator BackRun()
    //{
    //    yield return new WaitForSeconds(1f);
    //    playerAnimator.SetTrigger("Run");
    //}

    public void ToTheLeft()
    {
        if (transform.position.x >= -nextPositionX)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }
        isToStraight = false;
        isToTheLeft = true;
        float positionX = transform.position.x;
    }   
    
    public void ToTheRight()
    {
        if(transform.position.x <= nextPositionX)
        {
            isNext = true;
        }
        else
        {
            isNext = false;
        }
        isToStraight = false;
        isToTheRight = true;
        float positionX = transform.position.x;

    }
   

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CenterPath")
        {
            isToStraight = true;
            isPress = true;
            isNext = false;
            isToTheLeft = false;
            isToTheRight = false;
            isGround = true;
        }
        if(other.gameObject.tag == "LeftPath")
        {
            Debug.Log("Triggle");
            isToStraight = true;
            isPress = true;
            isNext = false;
            isToTheLeft = false;
            isToTheRight = false;
            isGround = true;
        }
        if (other.gameObject.tag == "RightPath")
        {
            isToStraight = true;
            isPress = true;
            isNext = false;
            isToTheRight = false;
            isToTheLeft = false;
            isGround = true;
        }
        if (other.gameObject.tag == "Coin")
        {
            GameManagement.instance.coin ++;
            SFXCoin.Play();
            Debug.Log(GameManagement.instance.coin);
        }        
        if(other.gameObject.tag == "Die")
        {
            isRun = false;
            playerAnimator.SetTrigger("Die");
            PlayerPrefs.SetInt("CoinSave", GameManagement.instance.coin);
            StartCoroutine(CheckDefeatPopup());
            PlayerPrefs.SetInt("Spoils", GameManagement.instance.coin);
            music.Stop();
            SFXDefeat.Play();
            GameManagement.instance.spoils = PlayerPrefs.GetInt("Spoils");
            GameManagement.instance.spoilsCoinDefeat.text = string.Format("{0}", GameManagement.instance.spoils);
            percentRound = System.Math.Truncate((player.transform.position.z) * 100 / (PathManagement.instance.lengthPath));
            GameManagement.instance.percentRoundImage.fillAmount = Mathf.InverseLerp(0,100, ((player.transform.position.z) * 100 / (PathManagement.instance.lengthPath)));
            dataCoin.coin = dataCoin.coin + PlayerPrefs.GetInt("CoinSave");
        }
        if(other.gameObject.tag == "Finish")
        {
            GameManagement.instance.menuVictory.show();
            music.Stop();
            SFXVictory.Play();
            PlayerPrefs.SetInt("CoinSave", GameManagement.instance.coin);
            PlayerPrefs.SetInt("Spoils", GameManagement.instance.coin);
            GameManagement.instance.spoils = PlayerPrefs.GetInt("Spoils");
            GameManagement.instance.spoilCoinVictory.text = string.Format("{0}", GameManagement.instance.spoils);
            dataCoin.coin = dataCoin.coin + PlayerPrefs.GetInt("CoinSave");
        }
    }
    IEnumerator CheckDefeatPopup()
    {
        yield return new WaitForSeconds(1f);
        GameManagement.instance.menuDefeat.show();
    }
}
