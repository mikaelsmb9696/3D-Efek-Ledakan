using UnityEngine;

[CreateAssetMenu(fileName = "TemplateLedakanSO", menuName = "Ledakan/TemplateLedakanSO")]
public class TemplateLedakanSO : ScriptableObject
{
    public ParticleSystem[] koleksiLedakan;
    public AudioClip[] koleksiAudio;    
}
