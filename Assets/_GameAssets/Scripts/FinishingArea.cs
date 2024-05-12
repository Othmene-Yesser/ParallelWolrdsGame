using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingArea : MonoBehaviour
{
    [SerializeField] GameObject uiCanvas;

    InputManager input;

    bool canUse;

    static readonly string Player = "Player";

    private void Awake()
    {
        input = FindAnyObjectByType<InputManager>();
        uiCanvas.SetActive(false);
    }

    private void Start()
    {
        if (uiCanvas == null)
            Debug.LogError("Unassigned variable " + nameof(uiCanvas));

        canUse = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player))
        {
            //! Enable UI
            uiCanvas.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(Player) && canUse)
        {
            //! use then put a cooldown 
            if (input.b_Interact)
            {
                //! iInteract and invoke function
                Debug.Log("Insert interaction");
                CheckIfKilledBosses();
                canUse = false;
                Invoke(nameof(InteractCooldown), 0.5f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Player))
        {
            //! Disable Ui
            uiCanvas.SetActive(false);
        }
    }
    private void InteractCooldown()
    {
        canUse = true;
    }

    private void CheckIfKilledBosses()
    {
        if (SaveManager.CheckIfBeatenBothBosses())
        {
            //! Play Credits sscen
            Debug.Log("Finished the game");
        }
    }

}
