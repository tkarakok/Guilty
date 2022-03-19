using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamaManager : Singleton<GamaManager>
{
    public LevelSettings levelSettings;
    public Transform guiltyPoint,nonGuiltyPoint;

    #region Private Fields
    private int _totalDefendat;
    private int _complateDefendats = 0;
    private List<Sprite> signatures;
    private GameObject _currentDefendat;
    #endregion


    #region Encapsullation
    public int TotalDefendat { get => _totalDefendat; set => _totalDefendat = value; }
    public List<Sprite> Signatures { get => signatures; set => signatures = value; }
    public int ComplateDefendats { get => _complateDefendats; set => _complateDefendats = value; }
    public GameObject CurrentDefendat { get => _currentDefendat; set => _currentDefendat = value; }
    #endregion

    private void Start()
    {
        TotalDefendat = levelSettings.totalDefandant;
        SignaturesGenrate();
        DefendatsGenerateManager.Instance.Generate();
    }


    void SignaturesGenrate(){
        Signatures = new List<Sprite>();
        for (int i = 0; i < levelSettings.signatures.Count; i++)
        {
            Signatures.Add(levelSettings.signatures[Random.Range(0,levelSettings.signatures.Count)]);
        }
    }

    
}
