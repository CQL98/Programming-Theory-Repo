using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject principalPanel;
    [SerializeField] private GameObject scorePanel; 
    private bool isPrincipalPanel = true;

    [SerializeField] private TMP_InputField nameText;
    [SerializeField] private TMP_Dropdown collectorId;
    [SerializeField] private TextMeshProUGUI dataTable;

    public void ChangePanel()
    {
        isPrincipalPanel = !isPrincipalPanel;
        if (!isPrincipalPanel)
        {
            LoadAllCollectors();
        }
        principalPanel.SetActive(isPrincipalPanel);
        scorePanel.SetActive(!isPrincipalPanel);
    }

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
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadAllCollectors()
    { 
        List<PlayerCollector> collectorScores = DataManager.Instance.GetLoadPlayerCollector(); 
        string auxTable = "";
        foreach (var item in collectorScores)
        {
            auxTable += "|" + DataManager.Instance.GetNameCollector(item.idCollector) + "|" + DataManager.FormatString(item.capacity,8) + "|" 
                            + DataManager.FormatString(item.namePlayer,12) + "|" + DataManager.FormatScore(item.topScore) + "|" + "\n";
        } 
        dataTable.text = auxTable;
    }

}
