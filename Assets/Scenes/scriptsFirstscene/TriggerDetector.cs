using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public GameObject objectToMove;
    public int count = 0;
    public bool operating = false;
    public bool start = false;
    public float countdownTime = 60f; 
    public float remainingTime { get; private set; }
    public AudioSource audioActivate;
    public AudioSource audioBuzzer;
    public AudioSource randomAudio;
    public AudioClip[] audioClips;
    private bool isMoving = false;
    private bool movingLeft = true;
    private bool reset = false;
    private float ObjCoord;

    
    private void Start() {
        ObjCoord = objectToMove.transform.position.x;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) || start)
        {
            start = false;
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
            if(remainingTime == 1)
            {
                audioBuzzer.Play();
            }
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
        float speed = 0.4f;
        float targetX = ObjCoord - 0.7f;

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
        float speed = 0.4f;
        float targetX = ObjCoord + 0.7f;

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
        float speed = 0.4f;; 

        if (objectToMove.transform.position.x < ObjCoord)
        {
            objectToMove.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        else if(objectToMove.transform.position.x > ObjCoord)
        {
            objectToMove.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(objectToMove.transform.position.x > ObjCoord - 0.005 && objectToMove.transform.position.x < ObjCoord + 0.005)
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
