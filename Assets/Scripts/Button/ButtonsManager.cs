using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public Animator animMenu;
    public Animator animIcon;
    public GameObject menu;
    public GameObject icon;
    private float time = 1.5f;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            animMenu = menu.GetComponent<Animator>();
            animIcon = icon.GetComponent<Animator>();
        }
    }

    public void Play()
    {
        StartCoroutine(Transition("Game")); 
    }
    
    public void Menu()
    {
        animMenu.SetBool("MenuActiv", true);
        animIcon.SetBool("IconActiv", true);
    }

    public void End()
    {
        animMenu.SetBool("MenuActiv", false);
        animIcon.SetBool("IconActiv", false);
    }

    public void Home()
    {
        StartCoroutine(Transition("Main"));
    }

    IEnumerator Transition(string scene)
    {
        Fader.sceneEnd = true;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
