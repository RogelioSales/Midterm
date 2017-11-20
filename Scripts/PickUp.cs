using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int pointsToAdd;
    public AudioSource coinSoundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterMovement>() == null)
            return;
        KeysScript.AddPoints(pointsToAdd);
        coinSoundEffect.Play();
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
