using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Start()
    {
        //GameManager._playerHP = 10;
        //gameManager._playerShield = 0;
    }
}