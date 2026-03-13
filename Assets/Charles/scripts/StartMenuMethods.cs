using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;
using Unity.VisualScripting;

public class StartMenuMethods : MonoBehaviour
{
    //this is genrilized so it can be used for multiple buttons to start diffrent scenes
    public void startbutton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quitbutton()
    {
        Debug.Log("Quit the game");
        Application.Quit();
    }
    //this brings you to the credits scene
    public void credtsbutton() 
    {        
        SceneManager.LoadScene("Credits");
    }
    //this just restarts the current scene
    public void restartbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
}
