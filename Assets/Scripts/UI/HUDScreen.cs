using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDScreen : MonoBehaviour
{


    [SerializeField] List<Image> heartImages;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Image powerUpIconImage;
    [SerializeField] TextMeshProUGUI powerUpAmountText;

    private static HUDScreen _instance;

    public static HUDScreen instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HUDScreen>();
                if (_instance == null)
                {
                    var go = Resources.Load("UI/HUD") as GameObject;
                    go = Instantiate(go, Vector3.zero, Quaternion.identity);
                    _instance = go.GetComponent<HUDScreen>();

                }
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }
}

    /*
    public void UpdateHealth(int health) {
        for (int i = 0; i < heartImages.Count; i++) {
            if ((i+1)<=health)
            {
                heartImages[i].color = new Color(1, 1, 1, 1);
            }
            else {
                heartImages[i].color = new Color(1, 1, 1, 0);

            }

        }
    }

    public void UpdateCoins(int coins) {
        coinsText.text ="x "+ coins.ToString();
    }


    public void UpdatePowerUp(  int amount)
    {

        if (amount <= 0) {
            powerUpIconImage.color = new Color(1, 1, 1, 0);
        }
        powerUpAmountText.text = "x " + amount;

    }
    public void UpdatePowerUp(Sprite icon,int amount)
    {
        powerUpIconImage.color = new Color(1, 1, 1, 1);

        powerUpIconImage.sprite= icon;
        powerUpAmountText.text = "x " + amount;
    }
    public void UpdatePowerUp(Sprite icon)
    {
        powerUpIconImage.color = new Color(1, 1, 1, 1);

        powerUpIconImage.sprite = icon;
    }
}
    */