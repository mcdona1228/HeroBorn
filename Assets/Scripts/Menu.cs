using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)
    {
        //GetComponent<GameBehavior>().SetHeartsDisplay(GameManager._playerHP);
        //GetComponent<GameBehavior>().SetShieldDisplay(GameBehavior._playerShield);
    }

}
