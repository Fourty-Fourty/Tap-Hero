using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public enum ItemType
    {
        NoAds
    }

    public ItemType itemType;
    public Text priceText;
    private string defaultText;


    void Start()
    {
        defaultText = priceText.text;
        StartCoroutine(LoadPriceRoutine());
    }

    public void Clicktobuy()
    {
        switch (itemType)
        {
            case ItemType.NoAds:
                PurchaseManager.Instance.BuyNoAds();
                break;
        }
    }

    private IEnumerator LoadPriceRoutine()
    {
        while (!PurchaseManager.Instance.IsInitialized())
            yield return null;

        string loadPrice = "";

        switch (itemType)
        {
            case ItemType.NoAds:
                loadPrice= PurchaseManager.Instance.GetProductPriceFromStore(PurchaseManager.Instance.No_Ads);
                break;
        }

        priceText.text = defaultText + " " + loadPrice;
    }

}
