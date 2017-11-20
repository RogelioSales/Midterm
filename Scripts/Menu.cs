using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public string startLevel;
    public string credits;
    public string back;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartGame()
    {
        SceneManager.LoadScene(startLevel);
    }
    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }
    public void Back()
    {
        SceneManager.LoadScene(back);
    }
    public void QuitGame()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }
}
