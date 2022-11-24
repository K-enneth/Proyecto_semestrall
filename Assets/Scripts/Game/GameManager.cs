using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] List<Sprite> powerUpSprites;


    private static GameManager _instance;


    private bool gameOver = false;

    private PowerUpId currentPowerUpId;
    private int powerUpAmount = 0;
    Sprite powerUpSprite;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    var go = Resources.Load("Game/GameManager") as GameObject;
                    Instantiate(go, Vector3.zero, Quaternion.identity);
                    go.AddComponent<GameManager>();
                    _instance = go.GetComponent<GameManager>();

                }
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }


    public void HideGameOver() {
        gameOver = false;
    }
    public void UpdateHealth(int health) {
        HUDScreen.instance.UpdateHealth(health);
        if (health <= 0&&!gameOver) {
            gameOver = true;
            GameOverScreen.instance.ShowScreen();
        }

    }
    public void UpdateCoins(int coins)
    {
        HUDScreen.instance.UpdateCoins(coins);


    }

    public void UpdatePowerUp(int amount)
    {
        powerUpAmount = amount;
        HUDScreen.instance.UpdatePowerUp(amount);


    }
    public void UpdatePowerUp(PowerUpId powerUpId, int amount)
    {
        powerUpAmount = amount;
        currentPowerUpId = powerUpId;
        if ((int)powerUpId >= 0)
        {
            HUDScreen.instance.UpdatePowerUp(powerUpSprites[(int)powerUpId], amount);
        }

    }
    public void UpdatePowerUp(PowerUpId powerUpId)
    {
      
        currentPowerUpId = powerUpId;
        if ((int)powerUpId >= 0)
        {
            HUDScreen.instance.UpdatePowerUp(powerUpSprites[(int)powerUpId]);
        }

    }
    public void SaveGame() {
        SaveSystem.instance.Load( out GameData gameData);
        if (gameData == null) {
            gameData = new GameData();

        }
        gameData.heroData.currentPowerUpId = currentPowerUpId;
        gameData.heroData.powerUpAmount = powerUpAmount;

        gameData.levelData.sceneId = SceneHelper.instance.GetCurrentSceneId();

        SaveSystem.instance.Save(gameData);


    }

}
