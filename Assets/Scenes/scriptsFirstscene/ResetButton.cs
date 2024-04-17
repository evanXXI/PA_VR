using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit; 

public class ResetButton : MonoBehaviour
{
    public UIManager UIManager; 
    
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => operating());
    }
    
    void operating()
    { 
        UIManager.reset = true;
    }
}
