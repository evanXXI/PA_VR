using UnityEngine;
using UnityEngine.UI;

public class StartBotton : MonoBehaviour
{
    public TriggerDetector triggerDetector; 
   
    

    void Update()
    { 
        triggerDetector.operating = true;
    }
}
