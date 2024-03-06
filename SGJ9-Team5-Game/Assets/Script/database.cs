using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Database/BGM Database")]
public class BGMDatabase : ScriptableObject
{
    [SerializeField]
    private List<BGMData> bgmList = new List<BGMData>();

    public List<BGMData> BGMList
    {
        get { return bgmList; }
    }

    public void AddBGM(BGMData bgmData)
    {
        bgmList.Add(bgmData);
    }

    public void RemoveBGM(BGMData bgmData)
    {
        bgmList.Remove(bgmData);
    }
}