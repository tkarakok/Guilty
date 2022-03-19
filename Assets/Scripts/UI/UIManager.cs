using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject inGamePanel;
    public GameObject endGamePanel;
    [Header("InGame")]
    public Image defandatSignature, judgeSignature;
    public GameObject filesPanel;

    #region Private Fields
    private GameObject _currentPanel;
    #endregion

    private void Start()
    {
        _currentPanel = mainMenuPanel;

    }

    #region Panel Change Function
    /// <summary>
    /// we changing panels
    /// </summary>
    /// <param name="openPanel"> opening panel </param>
    public void PanelChange(GameObject openPanel)
    {
        _currentPanel.SetActive(false);
        openPanel.SetActive(true);
        _currentPanel = openPanel;
    }
    #endregion

    #region StartButton
    public void StartButton()
    {
        PanelChange(inGamePanel);
        EventManager.Instance.InGame();
    }

    #endregion

    public void OpenFilesPanel(bool open){
        filesPanel.SetActive(open);
    }

    public void UpdateSignature(GameObject defandat)
    {
        defandatSignature.sprite = defandat.GetComponent<DefandatController>().signature;
        judgeSignature.sprite = GamaManager.Instance.Signatures[Random.Range(0, GamaManager.Instance.Signatures.Count)];
    }

    public void ResetFilesPanel()
    {
        defandatSignature.sprite = null;
        judgeSignature.sprite = null;
    }

    public void CheckSignature(bool guilty)
    {
        OpenFilesPanel(false);
        if (guilty)
        {
            if (judgeSignature.sprite == defandatSignature.sprite)
            {
                GamaManager.Instance.ComplateDefendats++;
                GamaManager.Instance.CurrentDefendat.GetComponent<DefandatController>().Guilty();
                EventManager.Instance.NextDefendat();
            }
            else
            {
                Debug.Log("GAME OVER");
            }
        }
        else
        {
            if (judgeSignature.sprite != defandatSignature.sprite)
            {
                GamaManager.Instance.ComplateDefendats++;
                GamaManager.Instance.CurrentDefendat.GetComponent<DefandatController>().NonGuilty();
                EventManager.Instance.NextDefendat();
            }
            else
            {
                Debug.Log("Game");
            }
        }
    }
}
