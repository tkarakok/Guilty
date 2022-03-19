using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    public int totalDefandant;
    public List<Sprite> signatures;
}
