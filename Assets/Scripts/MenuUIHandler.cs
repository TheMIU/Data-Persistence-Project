using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    private string PlayerName;
    public TextMeshProUGUI bestPlayerDetail;

    private void Start()
    {
        PersistanceManager.Instance.LoadPlayer();
        bestPlayerDetail.text = $"Best Score: {PersistanceManager.Instance.HighScore.ToString()} " +
            $"\nBest Player: {PersistanceManager.Instance.BestPlayer}";
    }

    public void StartNew()
    {
        PersistanceManager.Instance.CurruntPlayer = PlayerName;
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

    public void getName(string name)
    {
        PlayerName = name;
    }
}
