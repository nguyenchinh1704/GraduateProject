using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EazyEngine.UI;

public class MenuShop : MonoBehaviour
{
    public SOCoin dataCoin;
    public GameObject buttonUseAmy, buttonUseChoonYung, buttonUseGranny, buttonUseMiChelle;
    public GameObject buttonBuyAmy, buttonBuyChoonYung, buttonBuyGranny, buttonBuyMiChelle;
    public GameObject tickAmy, tickChoonYung, tickGranny, tickMiChelle;
    public UIElement textMessage;
    public GameObject textMessageUse;


    public void ButtonBuyCharacter()
    {

    }
/*    public void ButtonBuyAMY()
    {
        if (dataCoin.priceAMY < dataCoin.coin)
        {
            boughtEffect.SetActive(true);
            StartCoroutine(AutoOffBought());
            buttonUseAmy.SetActive(true);
            buttonBuyAmy.SetActive(false);
            tickAmy.SetActive(true);
            dataCoin.ownershipCheckAMY = 1;
            dataCoin.coin = dataCoin.coin - dataCoin.priceAMY;
        }
        else
        {
            textMessage.show();
            StartCoroutine(AutoOffBought());
        }
    }

    public void ButtonBuyCHOONYUNG()
    {
        if (dataCoin.priceCHOONYUNG < dataCoin.coin)
        {
            boughtEffect.SetActive(true);
            StartCoroutine(AutoOffBought());
            buttonBuyChoonYung.SetActive(false);
            buttonUseChoonYung.SetActive(true);
            tickChoonYung.SetActive(true);
            dataCoin.ownershipCheckCHOONYUNG = 1;
            dataCoin.coin = dataCoin.coin - dataCoin.priceCHOONYUNG;
        }
        else
        {
            textMessage.show();
            StartCoroutine(AutoOffBought());
        }
    }
    public void ButtonBuyGRANNY()
    {
        if (dataCoin.priceGRANNY < dataCoin.coin)
        {
            boughtEffect.SetActive(true);
            StartCoroutine(AutoOffBought());
            buttonBuyGranny.SetActive(false);
            buttonUseGranny.SetActive(true);
            tickGranny.SetActive(true);
            dataCoin.ownershipCheckGRANNY = 1;
            dataCoin.coin = dataCoin.coin - dataCoin.priceGRANNY;
        }
        else
        {
            textMessage.show();
            StartCoroutine(AutoOffBought());
        }
    }
    public void ButtonBuyMICHELLE()
    {
        if (dataCoin.priceMICHELLE < dataCoin.coin)
        {
            boughtEffect.SetActive(true);
            StartCoroutine(AutoOffBought());
            buttonBuyMiChelle.SetActive(false);
            buttonUseMiChelle.SetActive(true);
            tickMiChelle.SetActive(true);
            dataCoin.ownershipCheckMICHELLE = 1;
            dataCoin.coin = dataCoin.coin - dataCoin.priceMICHELLE;
        }
        else
        {
            textMessage.show();
            StartCoroutine(AutoOffBought());
        }
    }
    IEnumerator AutoOffBought()
    {
        yield return new WaitForSeconds(3f);
        boughtEffect.SetActive(false);
        textMessage.close();
    }

    IEnumerator AutoOffMessageUse()
    {
        yield return new WaitForSeconds(2f);
        textMessageUse.SetActive(false);
    }
    public void ButtonUseAMY()
    {
        dataCoin.hasUseAMY = 1;
        dataCoin.hasUseCHOONYUNG = 0;
        dataCoin.hasUseGRANY = 0;
        dataCoin.hasUseMICHELLE = 0;
        dataCoin.hasUseORTIZ = 0;
        textMessageUse.SetActive(true);
        CheckUseAmy();
        StartCoroutine(AutoOffMessageUse());
    }
    public void ButtonUseCHOONYUNG()
    {
        dataCoin.hasUseAMY = 0;
        dataCoin.hasUseCHOONYUNG = 1;
        dataCoin.hasUseGRANY = 0;
        dataCoin.hasUseMICHELLE = 0;
        dataCoin.hasUseORTIZ = 0;
        textMessageUse.SetActive(true);
        CheckUseChoonYung();
        StartCoroutine(AutoOffMessageUse());
    }
    public void ButtonUseGRANNY()
    {
        dataCoin.hasUseAMY = 0;
        dataCoin.hasUseCHOONYUNG = 0;
        dataCoin.hasUseGRANY = 1;
        dataCoin.hasUseMICHELLE = 0;
        dataCoin.hasUseORTIZ = 0;
        textMessageUse.SetActive(true);
        CheckUseGranny();
        StartCoroutine(AutoOffMessageUse());
    }
    public void ButtonUseMICHELLE()
    {
        dataCoin.hasUseAMY = 0;
        dataCoin.hasUseCHOONYUNG = 0;
        dataCoin.hasUseGRANY = 0;
        dataCoin.hasUseMICHELLE = 1;
        dataCoin.hasUseORTIZ = 0;
        textMessageUse.SetActive(true);
        CheckUseMiChelle();
        StartCoroutine(AutoOffMessageUse());
    }
    public void ButtonUseORTIZ()
    {
        dataCoin.hasUseAMY = 0;
        dataCoin.hasUseCHOONYUNG = 0;
        dataCoin.hasUseGRANY = 0;
        dataCoin.hasUseMICHELLE = 0;
        dataCoin.hasUseORTIZ = 1;
        textMessageUse.SetActive(true);
        CheckUseOrtiz();
        StartCoroutine(AutoOffMessageUse());
    }

    public void OwnershipCheckAMY()
    {
        if (dataCoin.ownershipCheckAMY == 1)
        {
            buttonUseAmy.SetActive(true);
            buttonBuyAmy.SetActive(false);
            tickAmy.SetActive(true);
        }
    }
    public void OwnershipCheckCHOONYUNG()
    {
        if (dataCoin.ownershipCheckCHOONYUNG == 1)
        {
            buttonBuyChoonYung.SetActive(false);
            buttonUseChoonYung.SetActive(true);
            tickChoonYung.SetActive(true);
        }
    }
    public void OwnershipCheckGRANNY()
    {
        if (dataCoin.ownershipCheckGRANNY == 1)
        {
            buttonBuyGranny.SetActive(false);
            buttonUseGranny.SetActive(true);
            tickGranny.SetActive(true);
        }
    }
    public void OwnershipCheckMICHELLE()
    {
        if (dataCoin.ownershipCheckMICHELLE == 1)
        {
            buttonBuyMiChelle.SetActive(false);
            buttonUseMiChelle.SetActive(true);
            tickMiChelle.SetActive(true);
        }
    }

    public void CheckUseAmy()
    {
        if (dataCoin.hasUseAMY == 1)
        {
            GameManagement.insatnce.AMY.SetActive(true);
            GameManagement.insatnce.CHOONYUNG.SetActive(false);
            GameManagement.insatnce.GRANNY.SetActive(false);
            GameManagement.insatnce.MICHELLE.SetActive(false);
            GameManagement.insatnce.ORTIZ.SetActive(false);
        }

    }
    public void CheckUseChoonYung()
    {
        if (dataCoin.hasUseCHOONYUNG == 1)
        {
            GameManagement.insatnce.AMY.SetActive(false);
            GameManagement.insatnce.CHOONYUNG.SetActive(true);
            GameManagement.insatnce.GRANNY.SetActive(false);
            GameManagement.insatnce.MICHELLE.SetActive(false);
            GameManagement.insatnce.ORTIZ.SetActive(false);
        }

    }
    public void CheckUseGranny()
    {
        if (dataCoin.hasUseGRANY == 1)
        {
            GameManagement.insatnce.AMY.SetActive(false);
            GameManagement.insatnce.CHOONYUNG.SetActive(false);
            GameManagement.insatnce.GRANNY.SetActive(true);
            GameManagement.insatnce.MICHELLE.SetActive(false);
            GameManagement.insatnce.ORTIZ.SetActive(false);
        }

    }
    public void CheckUseMiChelle()
    {
        if (dataCoin.hasUseMICHELLE == 1)
        {
            GameManagement.insatnce.AMY.SetActive(false);
            GameManagement.insatnce.CHOONYUNG.SetActive(false);
            GameManagement.insatnce.GRANNY.SetActive(false);
            GameManagement.insatnce.MICHELLE.SetActive(true);
            GameManagement.insatnce.ORTIZ.SetActive(false);
        }

    }
    public void CheckUseOrtiz()
    {
        if (dataCoin.hasUseORTIZ == 1)
        {
            GameManagement.insatnce.AMY.SetActive(false);
            GameManagement.insatnce.CHOONYUNG.SetActive(false);
            GameManagement.insatnce.GRANNY.SetActive(false);
            GameManagement.insatnce.MICHELLE.SetActive(false);
            GameManagement.insatnce.ORTIZ.SetActive(true);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OwnershipCheckAMY();
        OwnershipCheckCHOONYUNG();
        OwnershipCheckGRANNY();
        OwnershipCheckMICHELLE();
        CheckUseAmy();
        CheckUseChoonYung();
        CheckUseGranny();
        CheckUseMiChelle();
        CheckUseOrtiz();
    }
    public void CheckUseAll()
    {
        CheckUseAmy();
        CheckUseChoonYung();
        CheckUseGranny();
        CheckUseMiChelle();
        CheckUseOrtiz();
    }*/
}
