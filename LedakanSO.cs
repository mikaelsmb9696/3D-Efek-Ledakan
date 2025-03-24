using UnityEngine;

[CreateAssetMenu(fileName = "LedakanSO", menuName = "Ledakan/LedakanSO")]
public class LedakanSO : ScriptableObject
{
    [Min(0.1f)]
    public float scale = 1;
    [Min(0.1f)]
    public float durasi = 2;
    [Min(0.1f)]
    public float radius = 1;
    [Min(1)]
    public int totalPercikan = 1;
    public TemplateLedakanSO templateLedakan;

    public void EditLedakan(ParticleSystem ledakan)
    {
        ParticleSystem[] ledakans = ledakan.GetComponentsInChildren<ParticleSystem>();

        for (int i = 0; i < ledakans.Length; i++)
        {
            ParticleSystem.MainModule main = ledakans[i].main;
            ParticleSystem.MinMaxCurve lifetime = main.startLifetime;
            ParticleSystem.ShapeModule shape = ledakans[i].shape;
            ParticleSystem.EmissionModule emission = ledakans[i].emission;
            ParticleSystem.Burst burst = emission.GetBurst(0);
            ParticleSystem.MinMaxCurve count = burst.count;

            main.duration = durasi;
            
            lifetime.constantMin *= durasi;
            lifetime.constantMax *= durasi;                        
            shape.radius *= radius;
            
            count.constantMin *= totalPercikan;
            count.constantMax *= totalPercikan;

            main.startLifetime = lifetime;
            burst.count = count;
            emission.SetBurst(0, burst);
        }

        ledakan.transform.localScale = scale * Vector3.one;
    }

    public AudioClip AmbilAudio()
    {
        return templateLedakan.koleksiAudio[Random.Range(0, templateLedakan.koleksiAudio.Length)];
    }
}
