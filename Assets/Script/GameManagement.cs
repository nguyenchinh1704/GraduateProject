using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using EazyEngine.UI;
using UnityEngine.UI;
using UnityExtensions.Tween;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public GameObject timerText;
    public UIElement timerTween;
    public int timeReady;
    public int coin = 0;
    public Text perentRound;
    public Image percentRoundImage;
    public Text coinNumber, spoilsCoinDefeat;
    public Text spoilCoinVictory;
    public static GameManagement instance;
    public UIElement menuStart;
    public UIElement menuDefeat;
    public UIElement menuVictory;
    public UIElement menuShop;
    public UIElement menuPause;
    public UIElement menuOption;
    public SOCoin dataCoin;
    public int spoils = 0;
    public Text sumCoin;
    public GameObject btnPause, titleInGame;
    public GameObject boughtEffect, textBuy, textUse;
    public Image effectMenuStart;
    private void OnEnable()
    {
        instance = this;
    }
    public void ChangeColor()
    {
        StartCoroutine(AutoChangeColorRed());
        StartCoroutine(AutoChangeColorYellow());
        StartCoroutine(AutoChangeColorGreen());
    }
    IEnumerator AutoChangeColorRed()
    {
        yield return new WaitForSeconds(1f);
        effectMenuStart.color = Color.red;
        
    }
    IEnumerator AutoChangeColorYellow()
    {
        yield return new WaitForSeconds(3f);
        effectMenuStart.color = Color.yellow;
    }
    IEnumerator AutoChangeColorGreen()
    {
        yield return new WaitForSeconds(5f);
        effectMenuStart.color = Color.green;
    }
    IEnumerator UpdateTimer() // Coroutine clockCutdown
    {
        timerText.SetActive(true);
        while (timeReady > 0)
        {
            timer.text = string.Format("{0}", timeReady);
            timerTween.show();
            timeReady--;
            yield return new WaitForSeconds(1f);

        }
        if (timeReady == 0)
        {
            timer.text = timeReady.ToString("Ready Go!");
            timer.color = Color.green;
            StartCoroutine(AutoOff());
        }

    }
    IEnumerator AutoOff()
    {
        yield return new WaitForSeconds(1f);
        timerText.SetActive(false);
        PlayerController.instance.playerAnimator.SetTrigger("Run");
        PlayerController.instance.isStarted = true;
        PlayerController.instance.isRun = true;
        PlayerController.instance.isToStraight = true;
        btnPause.SetActive(true);
        titleInGame.SetActive(true);
    }

    public void ButtonQuitInPause()
    {
        SceneManager.LoadScene("Round1");
    }
    public void ButtonStart()
    {
        menuStart.show();
        StartCoroutine(PrepareStart());
        StartCoroutine(UpdateTimer());
        CharacterInfor.instance.CharacterOn();
    }
    IEnumerator PrepareStart()
    {
        yield return new WaitForSeconds(2f);
        Quaternion newVector = Quaternion.Euler(0, 0, 0);
        PlayerController.instance.transform.rotation = Quaternion.Slerp(transform.rotation, newVector, Time.deltaTime);
    }
    public void ButtonNextRound()
    {
        menuVictory.close();
    }

    public void ButtonClosePopUpDefeat()
    {

        menuDefeat.close();
        CloseMenuStart();
        SceneManager.LoadScene("Round1");
    }

    public void ButtonCloseShop()
    {
        menuShop.close();
    }

    public void ButtonPause()
    {
        PlayerController.instance.isRun = false;
        PlayerController.instance.isStarted = false;
        menuPause.show();
    }
    public void ButtonClosePause()
    {
        PlayerController.instance.isRun = true;
        PlayerController.instance.isStarted = true;
        menuPause.close();
    }

    public void ButonOpenShop()
    {
        menuShop.show();
    }
    public TweenPlayer menuStartClose;
    public void CloseMenuStart()
    {
        menuStartClose.Stop();
        menuStartClose.normalizedTime = 0;
    }

    public void ButtonOption()
    {
        menuOption.show();
    }
    public void ButtonCloseOption()
    {
        menuOption.close();
    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag == "Path")
    //    {
    //        PlayerController.instance.isGround = true;
    //    }
    //    else
    //    {
    //        PlayerController.instance.isGround = false;
    //    }
    //}

    void Start()
    {
        coin = 0;
        CheckOnCharater();
        ChangeColor();
    }

    public void CheckCoinInGame()
    {
        int currentCoin;
        currentCoin = dataCoin.coin;
        sumCoin.text = currentCoin.ToString();      
    }
    // Update is called once per frame
    void Update()
    {
        coinNumber.text = coin.ToString();
        perentRound.text = string.Format("{0}" + "%", PlayerController.instance.percentRound);
        CheckCoinInGame();
    }
    public List<CharacterInfor> listCharacter;
    public void CheckOnCharater()
    {
        for (int i = 0; i < listCharacter.Count; i++)
        {
            listCharacter[i].CharacterOn();
        }
    }
}
