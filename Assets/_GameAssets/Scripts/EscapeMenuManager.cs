using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuManager : MonoBehaviour
{
    [SerializeField] GameObject escapeMenu;
    
    bool status;
    private void Awake()
    {
        status= false;
    }
    private void Start()
    {
         escapeMenu.SetActive(status);
    }
    public void EscapeMenu()
    {
        escapeMenu.SetActive(!status);
        status = !status;
    }

}
