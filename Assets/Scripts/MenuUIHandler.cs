using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI m_TextMesh;

    private void Start()
    {
        SaveManager.Instance.LoadNameScore();
        m_TextMesh.text = "Best Score: " + SaveManager.Instance.PlayerName + " : " + SaveManager.Instance.HighScore;
    }
    public void NewStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
