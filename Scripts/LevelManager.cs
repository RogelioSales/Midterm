using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private CharacterMovement character;
    public GameObject deathParticle;
    public float respawnDelay;
    private new CameraControl camera;
   
	// Use this for initialization
	void Start ()
    {
        character = FindObjectOfType<CharacterMovement>();
        camera = FindObjectOfType<CameraControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
  
    }
    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticle, character.transform.position, character.transform.rotation);
        character.enabled = false;
        character.GetComponent<Renderer>().enabled= false;
        camera.isFollowing = false;
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        camera.isFollowing = true;
        character.enabled = true;
        character.GetComponent<Renderer>().enabled = true;
        character.transform.position = currentCheckpoint.transform.position;
    }
}
