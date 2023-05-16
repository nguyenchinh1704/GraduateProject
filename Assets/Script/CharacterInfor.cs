using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfor : MonoBehaviour
{
    public SOCoin data;
    public int idCharacter;
    public Text nameChracter;
    public Text priceCharacter;
    public GameObject tick;
    public GameObject btnBuy, btnUse;
    public GameObject character;
    // Start is called before the first frame update
    public static CharacterInfor instance;
    private void OnEnable()
    {
        instance = this;
    }
    public void BtnBuy()
    {
        for (int i = 0; i < data.charater.Count; i++)
        {
            if (idCharacter == data.charater[i].id)
            {
                if (data.charater[i].price <= data.coin)
                {
                    btnBuy.SetActive(false);
                    btnUse.SetActive(true);
                    data.charater[i].ownershipCheck = 1;
                    data.coin = data.coin - data.charater[i].price;
                    GameManagement.instance.boughtEffect.SetActive(true);
                    StartCoroutine(AutoOffEffectBuy());
                }
                else
                {
                    GameManagement.instance.textBuy.SetActive(true);
                    StartCoroutine(AutoOffEffectBuy());
                }
                break;
            }
        }
    }
    public void BtnUse()
    {
        for (int i = 0; i < data.charater.Count; i++)
        {
            if (idCharacter == data.charater[i].id)
            {
                data.charater[i].useCharacter = 1;
                character.SetActive(true);
                GameManagement.instance.textUse.SetActive(true);
                CheckStatusCharater();
                StartCoroutine(AutoOffTextUse());
                break;
            }
        }
    }
    IEnumerator AutoOffTextUse()
    {
        yield return new WaitForSeconds(3f);
        GameManagement.instance.textUse.SetActive(false);
        GameManagement.instance.textBuy.SetActive(false);
    }
    public void CheckStatusCharater()
    {
        for (int i = 0; i < data.charater.Count; i++)
        {
            if (idCharacter != data.charater[i].id)
            {
                data.charater[i].useCharacter = 0;
            }
        }
    }
    public void CharacterOn()
    {
        for (int i = 0; i < data.charater.Count; i++)
        {
            if (idCharacter == data.charater[i].id)
            {
                if (data.charater[i].useCharacter == 1)
                {
                    character.SetActive(true);                   
                }
                else
                {
                    character.SetActive(false);
                }
                break;
            }
        }
    }
    IEnumerator AutoOffEffectBuy()
    {
        yield return new WaitForSeconds(3f);
        GameManagement.instance.textBuy.SetActive(false);
        GameManagement.instance.boughtEffect.SetActive(false);
    }
    public void CheckOwnerShip()
    {
        for (int i = 0; i < data.charater.Count; i++)
        {
            if (idCharacter == data.charater[i].id)
            {
                if (data.charater[i].ownershipCheck == 1)
                {
                    tick.SetActive(true);
                    btnBuy.SetActive(false);
                    btnUse.SetActive(true);
                }
                else
                {
                    tick.SetActive(false);
                    btnBuy.SetActive(true);
                    btnUse.SetActive(false);
                }
                break;
            }
        }
    }
    public void CheckDataCharater()
    {
        for (int i = 0; i < data.charater.Count; i++)
        {
            if (idCharacter == data.charater[i].id)
            {
                string name = data.charater[i].name;
                int price = data.charater[i].price;
                nameChracter.text = name.ToString();
                priceCharacter.text = price.ToString();
                CheckOwnerShip();
                break;
            }
        }
    }
    void Start()
    {
        CheckDataCharater();
        CharacterOn();
    }

    // Update is called once per frame
    void Update()
    {
        CheckOwnerShip();
        CharacterOn();
    }
}
