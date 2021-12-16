using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Behavior : MonoBehaviour
{
    public GameBehavior gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");
            gameManager.Items += 1;
            Debug.Log(gameManager.Items);
        }
        if (this.CompareTag("Sheild"))
        {
            collision.gameObject.GetComponent<PlayerBehavior>()._playerShield++;
            collision.gameObject.GetComponent<PlayerBehavior>().ShieldChange();
            Debug.Log("Armored Up!!!");
        }
        if (this.CompareTag("Apple"))
        {
            collision.gameObject.GetComponent<PlayerBehavior>()._playerHP++;
            collision.gameObject.GetComponent<PlayerBehavior>().HealthChange();
            
            Debug.Log("Health Gained!!!");
        }
        //if (this.CompareTag("BossKiller"))
        //collision.gameObject.GetComponent<PlayerBehavior>()._BossKiller==true;
        //collision.gameObject.GetComponent<PlayerBehavior>().BossKillerChange(); (add public void on player behavior/Add bosskiller to game behavior)
    }
}
