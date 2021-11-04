using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Death()
    {
        SceneManager.LoadScene("DeathScene");
    }

    public void GetInstr()
    {
        SceneManager.LoadScene("InstructionScene");
    }
}
