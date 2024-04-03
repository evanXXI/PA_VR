using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
    
public class GameController : MonoBehaviour
{
    [SerializeField] private InputActionAsset _actionAsset; // Référence a notre input action Asset
    
    void Start()
    {
        //On recupere l'action qu'on a créé a partir de l'action Map 
        var jump = _actionAsset.FindActionMap("XRI RightHand").FindAction("Sauter");
        
        //On "Active" l'action créé 
        jump.Enable();

        //on associe une fonction callback que l'on donne en parametre a l'evenement Performed pour l'action créé
        jump.performed += OnJumpPerformed;
    }

    //On créé notre fonction callback qui contiendra toute notre logique de code
    private void OnJumpPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
    }
}