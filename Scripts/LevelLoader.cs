using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private bool playerInZone;
    public string levelToLoad;
    void Start()
    {
        playerInZone = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && playerInZone)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
        }

    }

}
