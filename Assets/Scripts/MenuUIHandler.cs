using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameText;
    [SerializeField] private TMP_Dropdown collectorId;


    public void StartGame()
    {
        DataManager.Instance.StartValues(collectorId.value,nameText.text);
        ChangeScene(1);
    }
    public void ChangeScene(int idScene)
    {
        SceneManager.LoadScene(idScene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
