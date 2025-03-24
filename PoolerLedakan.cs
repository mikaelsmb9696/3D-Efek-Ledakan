using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolerLedakan : MonoBehaviour
{
    public LedakanSO ledakan;
    public int totalDuplikat = 2;

    List<ParticleSystem> listLedakan = new List<ParticleSystem>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsiPool();
    }

    public void IsiPool()
    {
        ParticleSystem ledakanFlag;

        for (int i = 0; i < ledakan.templateLedakan.koleksiLedakan.Length; i++)
        {
            for (int j = 0; j < totalDuplikat; j++)
            {
                ledakanFlag = Instantiate(ledakan.templateLedakan.koleksiLedakan[i]);
                ledakanFlag.gameObject.SetActive(false);
                ledakan.EditLedakan(ledakanFlag);
                listLedakan.Add(ledakanFlag);
            }
        }
    }

    public ParticleSystem GetLedakan()
    {
        if(listLedakan.Count == 0)
        {
            IsiPool();
        }

        ParticleSystem ledakanFlag = listLedakan[Random.Range(0, listLedakan.Count)];
        listLedakan.Remove(ledakanFlag);

        ledakanFlag.gameObject.SetActive(true);
        StartCoroutine(MasukinLedakanBalik(ledakanFlag));        

        return ledakanFlag;
    }

    private IEnumerator MasukinLedakanBalik(ParticleSystem ledakanFlag)
    {
        yield return new WaitForSeconds(1.0f);

        while (ledakanFlag.isPlaying)
        {
            yield return null;
        }

        ledakanFlag.gameObject.SetActive(false);
        listLedakan.Add(ledakanFlag);
    }
}
