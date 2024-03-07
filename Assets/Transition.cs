using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    public Animator animator;
    public void FadeToScene(string sceneName)
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete(){
        SceneManager.LoadScene("MainGame");
    }
}
