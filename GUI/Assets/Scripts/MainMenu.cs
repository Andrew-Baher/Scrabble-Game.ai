using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private bool teacherMode = false;
    private bool aiMode = false;
    private bool quitGame = false;

    public void TeacherModeGame()
    {
        teacherMode = true;
        FindObjectOfType<SceneTransitionBegin>().BeginTransition();
    }

    public void AIModeGame()
    {
        aiMode = true;
        FindObjectOfType<SceneTransitionBegin>().BeginTransition();
    }

    public void ExitGame()
    {
        quitGame = true;
        FindObjectOfType<SceneTransitionBegin>().BeginTransition();
    }

    public bool IsTeacherMode()
    {
        return teacherMode;
    }

    public bool IsAIMode()
    {
        return aiMode;
    }

    public bool IsQuit()
    {
        return quitGame;
    }

}
