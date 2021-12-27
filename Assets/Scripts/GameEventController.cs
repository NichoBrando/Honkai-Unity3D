using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnAreas;

    [SerializeField]
    private GameObject commonMobPrefab;
    
    [SerializeField]
    private Text TotalMobsLabel;
    
    [SerializeField]
    private Text WaveLabel;
    
    [SerializeField]
    private Health playerHealth;
    
    private int waveNumber = 0;
    private int totalMobs = 0;
    private int killedMobs = 0;

    void Start()
    {
        StartCoroutine("startWave");
    }

    public void onKillMob() 
    {
        TotalMobsLabel.text = $"{++killedMobs}/{totalMobs}";
        if (killedMobs == totalMobs) {
            StartCoroutine("startWave");
        }
    }

    IEnumerator startWave()
    {
        WaveLabel.text = $"Wave {++waveNumber}";
        killedMobs = 0;
        totalMobs += 5;
        yield return new WaitForSeconds(2f);
        playerHealth.restore();
        StartCoroutine("generateMobsWave");
    }

    void spawnMobs(int mobsQuantity)
    {
        for (int i = 0; i < mobsQuantity; i++) 
        {
            GameObject newMob = Instantiate(commonMobPrefab);
            newMob.gameObject.transform.position = spawnAreas[i].gameObject.transform.position;
            if (waveNumber > 3) {
                newMob.gameObject.GetComponent<EnemyFollow>().updateSpeed(waveNumber / 2);
            }
        }
    }

    IEnumerator generateMobsWave()
    {
        int spawnLimit = spawnAreas.Length;
        int totalMobsToSpawn = totalMobs;
        TotalMobsLabel.text = $"0/{totalMobs}";
        while (totalMobsToSpawn != 0) {
            int mobsQuantity = 0;
            
            if (totalMobsToSpawn > spawnLimit) {
                mobsQuantity = spawnLimit;
                totalMobsToSpawn -= spawnLimit;
            } 
            else {
                mobsQuantity = totalMobsToSpawn;
                totalMobsToSpawn = 0;
            }
            spawnMobs(mobsQuantity);
            yield return new WaitForSeconds(2f);
        }
    }

}
