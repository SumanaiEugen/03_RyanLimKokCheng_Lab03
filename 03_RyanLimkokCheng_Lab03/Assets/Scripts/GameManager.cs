using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnRestartClick()
    {
        SceneManager.LoadScene("GamePlay_Level 1");
    }
}
