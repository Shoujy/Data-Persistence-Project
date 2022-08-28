using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputField inputName;
    [SerializeField] Text BestScoreAndName;

    private int bestScore;
    private string bestScoreName;

    private void Awake()
    {
        DataManger.Instance.LoadPlayerData();

        bestScore = DataManger.Instance.bestScore;
        bestScoreName = DataManger.Instance.bestScoreName;
        inputName.text = DataManger.Instance.inputName;
    }

    private void Start()
    {
        BestScoreAndName.text = "Best Score: " + bestScoreName + " : " + bestScore;
    }

    public void StartGame()
    {
        DataManger.Instance.inputName = inputName.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
