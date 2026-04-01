using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject inv;

    [SerializeField] private GameObject pauseMenu;
    public void Start()
    {
        inv = GameObject.Find("stuff background");

    }
    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true); 
        Time.timeScale = 0f; 

    }
    public void Resume()
    {   
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void toggle()
    {
        
        
            isPaused = !isPaused; // Toggle the paused state
            pauseMenu.SetActive(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
        
    }
    
    public void back()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale back to 1
        SceneManager.LoadScene("main menu");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle();
        }
        if (isPaused == true)
        {
            inv.SetActive(false);
        }
        else
        {
            inv.SetActive(true);
        }
    }
}
