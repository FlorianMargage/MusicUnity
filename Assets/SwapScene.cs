using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    public void SceneWelcome()
    {
        SceneManager.LoadScene("Welcome");
    }
    public void SceneMelody()
    {
        SceneManager.LoadScene("Melody");
    }

    public void SceneTrial()
    {
        SceneManager.LoadScene("Trial");
    }

    public void SceneStartChallenge()
    {
        SceneManager.LoadScene("StartChallenge");
    }

    public void SceneChallenge()
    {
        SceneManager.LoadScene("Challenge");
    }
}
