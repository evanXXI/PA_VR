using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText; 
    public Text highestText;  
    public Text TimeText;
    public TriggerDetector triggerDetector; 
    private int highscore = 0;
    

    void Update()
    { 
         if (triggerDetector.count > highscore)
        {
            highscore = triggerDetector.count;
            highestText.text = highscore.ToString(); 
        }
        scoreText.text = triggerDetector.count.ToString();
        TimeText.text = triggerDetector.remainingTime.ToString();
    }
}
