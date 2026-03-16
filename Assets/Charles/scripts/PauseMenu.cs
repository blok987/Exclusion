using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private GameObject pauseMenu;
    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true); 
        Time.timeScale = 0f; 
    }
    public void Resume(InputAction.CallbackContext ctx)
    {   
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void toggle(InputAction.CallbackContext ctx)
    { 
        isPaused = !isPaused; // Toggle the paused state
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f; 
    }
    
    public void back()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale back to 1
    }   
}
