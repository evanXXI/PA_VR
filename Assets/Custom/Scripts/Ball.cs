using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public AudioSource ballAudio;
    public AudioClip[] collisionSounds;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collisionSounds.Length > 0)
        {
            if (collision.gameObject.CompareTag("CollisionTag"))
            {
                //Choose a random collision sound from array
                int randomIndex = Random.Range(0, collisionSounds.Length);
                
                // Debug log to check the randomIndex
                Debug.Log("Random Index: " + randomIndex);
                
                AudioClip randomSound = collisionSounds[randomIndex];

                // Play the collision sound
                ballAudio.clip = randomSound;
                ballAudio.Play();
            }
        }
        else
        {
            Debug.LogWarning("collisionSounds array is empty!");
        }
    }
}
