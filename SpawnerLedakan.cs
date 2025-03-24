using UnityEngine;

public class SpawnerLedakan : MonoBehaviour
{
    public PoolerLedakan poolLedakan;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform SpawnLedakan(Vector3 posisi)
    {
        ParticleSystem efekLedakan = poolLedakan.GetLedakan();
        AudioSource audio = efekLedakan.GetComponent<AudioSource>();
        efekLedakan.transform.position = posisi;

        efekLedakan.Play();
        audio.clip = poolLedakan.ledakan.AmbilAudio();
        audio.pitch = Random.Range(1.0f, 1.8f);
        audio.Play();

        return efekLedakan.transform;
    }
}
