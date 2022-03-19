using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendatsGenerateManager : Singleton<DefendatsGenerateManager>
{
    [System.Serializable]
    public struct Defendats
    {
        public GameObject[] defendatPrefab;
        public List<GameObject> defendatList;
        public Transform parent;
    };

    public Defendats defendats;


    public void Generate()
    {
        defendats.defendatList = new List<GameObject>();

        for (int i = 0; i < GamaManager.Instance.TotalDefendat; i++)
        {
            GameObject newDefendat = Instantiate(defendats.defendatPrefab[Random.Range(0, defendats.defendatPrefab.Length)]);
            newDefendat.GetComponent<DefandatController>().signature = GamaManager.Instance.Signatures[Random.Range(0, GamaManager.Instance.Signatures.Count)];

            newDefendat.SetActive(false);
            newDefendat.transform.SetParent(defendats.parent);
            defendats.defendatList.Add(newDefendat);
        }
    }

    public void StartTour()
    {
        defendats.defendatList[GamaManager.Instance.ComplateDefendats].SetActive(true);
        GamaManager.Instance.CurrentDefendat = defendats.defendatList[GamaManager.Instance.ComplateDefendats];
    }


}
