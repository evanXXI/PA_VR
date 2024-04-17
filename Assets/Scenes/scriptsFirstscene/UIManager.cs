using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text highestText;
    public Text TimeText;
    public TriggerDetector triggerDetector;
    public AudioSource audioHighscore;
    public bool reset = false;
    private int highscore = 0;
    private bool playHighscoreAudio = false;

    void Start()
    {

        highscore = PlayerPrefs.GetInt("BestScore", 0);
        highestText.text = highscore.ToString();
    }

    void Update()
    {
        scoreText.text = triggerDetector.count.ToString();
        TimeText.text = Mathf.RoundToInt(triggerDetector.remainingTime).ToString();

        if (triggerDetector.count > highscore)
        {
            highscore = triggerDetector.count;
            highestText.text = highscore.ToString();
            playHighscoreAudio = true;


            PlayerPrefs.SetInt("BestScore", highscore);
            PlayerPrefs.Save();
        }

        if (reset || Input.GetKeyDown(KeyCode.R))
        {
            triggerDetector.count = 0;
            ResetHighScore();
        }

        if(!triggerDetector.operating && playHighscoreAudio)
        {
            audioHighscore.Play();
            playHighscoreAudio = false;
        }

    }

    void ResetHighScore()
    {
        highscore = 0;
        PlayerPrefs.SetInt("BestScore", highscore);
        PlayerPrefs.Save();
        highestText.text = highscore.ToString();
        reset = false;
    }
}
