using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    private int _itemsCollected = 0;
    public int _playerHP = 10;
    public int _playerShield = 0;
    //public static int _playerHP = 10;
    //public static int _playerShield = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }
    /*
    public FixedUpdate()
    {
        //Call SetHeartsDisplay and SetShieldDisplay

    }
    */
    void Start()
    {
        SetHeartsDisplay(_playerHP);
        SetShieldDisplay(_playerShield);
    }
    public void SetHeartsDisplay(int players)
    {
        if (GameObject.Find("hearts"))
        {
            GameObject hearts = GameObject.Find("hearts");

            if (hearts.transform.childCount < 1)
            {
                for (int _playerHP = 0; _playerHP < 11; _playerHP++)
                {
                    GameObject heart = GameObject.Instantiate(Resources.Load("Sprites/heart")) as GameObject;
                    heart.transform.SetParent(hearts.transform);
                }
            }
            for (int _playerHP = 0; _playerHP < hearts.transform.childCount; _playerHP++)
            {
                hearts.transform.GetChild(_playerHP).localScale = new Vector3(1, 1, 1);
            }
            for (int _playerHP = 0; _playerHP < (hearts.transform.childCount - players); _playerHP++)
            {
                hearts.transform.GetChild(hearts.transform.childCount - _playerHP - 1).localScale = Vector3.zero;
            }
        }
    }
    public void SetShieldDisplay(int players)
    {
        if (GameObject.Find("shields"))
        {
            GameObject shields = GameObject.Find("shields");

            if (shields.transform.childCount < 1)
            {
                for (int _playerShield = 0; _playerShield < 1; _playerShield++)
                {
                    GameObject shield = GameObject.Instantiate(Resources.Load("Sprites/shield")) as GameObject;
                    shield.transform.SetParent(shields.transform);
                }
            }
            for (int _playerShield = 0; _playerShield < shields.transform.childCount; _playerShield++)
            {
                shields.transform.GetChild(_playerShield).localScale = new Vector3(1, 1, 1);
            }
            for (int _playerShield = 0; _playerShield < (shields.transform.childCount - players); _playerShield++)
            {
                shields.transform.GetChild(shields.transform.childCount - _playerShield - 1).localScale = Vector3.zero;
            }
        }
    }
    void OnGUI()
    {
        //GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        //GUI.Box(new Rect(20, 50, 150, 25), "Player Sheild:" + _playerShield);
        //GUI.Box(new Rect(20, 80, 150, 25), "Items Collected:" + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WIN!"))
            {
                SceneManager.LoadScene("WinEnding");
                Time.timeScale = 1.0f;
            }
        }
        if (_playerHP <= 0)
        {
            SceneManager.LoadScene("DeathEnding");
            Time.timeScale = 1.0f;
        }
    }

}
