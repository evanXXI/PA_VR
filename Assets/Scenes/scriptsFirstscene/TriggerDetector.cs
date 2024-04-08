using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public GameObject objectToMove;
    public int count = 0;
    public bool operating = false;
    public float countdownTime = 15f; 
    public float remainingTime { get; private set; }
    public AudioSource audioActivate;
    public AudioSource randomAudio;
    public AudioClip[] audioClips;
    private bool isMoving = false;
    private bool movingLeft = true;
    private bool reset = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            operating = true;
            audioActivate.Play();
            count = 0;
            remainingTime = countdownTime;
            StartCoroutine(StartCountdown());
        } 

        if (isMoving && operating)
        {
            if (movingLeft)
            {
                MoveHoopLeft();
            }
            else
            {
                MoveHoopRight();
            }
        }

        if(!operating && !reset)
        {
            ResetHoopPosition();
        }
    }

    private System.Collections.IEnumerator StartCountdown()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        operating = false;
        isMoving = false;
        reset = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sphere" && operating)
        {
            count += 15;
            PlayRandomSound(); 
            if (count == 75)
            {
                isMoving = true;
            }
        }
    }

    private void MoveHoopLeft()
    {
        float speed = 1.0f;
        float targetX = 7.97f;

        if (objectToMove.transform.position.x > targetX)
        {
            objectToMove.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            movingLeft = false;
        }
    }

    private void MoveHoopRight()
    {
        float speed = 1.0f;
        float targetX = 11.5f;

        if (objectToMove.transform.position.x < targetX)
        {
            objectToMove.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            movingLeft = true;
        }
    }

    private void ResetHoopPosition()
    {
        float speed = 1.0f;
        float targetX = 9.7f;

        if (objectToMove.transform.position.x < targetX)
        {
            objectToMove.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        else if(objectToMove.transform.position.x > targetX)
        {
            objectToMove.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(objectToMove.transform.position.x > targetX - 0.005 && objectToMove.transform.position.x < targetX + 0.005)
        {
        reset = true;
        }
        
    }
      public void PlayRandomSound()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex]; 
            randomAudio.clip = randomClip; 
            randomAudio.Play(); 
        }
    }
}
