using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create BGMData")]
public class BGMData : ScriptableObject
{
    [SerializeField]
    private string bgmName; //BGMの名前
    [SerializeField]
    private AudioClip bgmClip; //BGMのAudioClipを指定。
    [SerializeField]
    [Range(0, 1)]
    private float bgmVolume; //BGMのボリューム

    public string BGMName => bgmName;
    public AudioClip BGMClip => bgmClip;
    public float BGMVolume => bgmVolume;
}