using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0; // Pause whole game operations
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Resume whole game operations
    }
}