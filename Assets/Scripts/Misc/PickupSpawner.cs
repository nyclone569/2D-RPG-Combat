using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoinPrefab, healthGlobe, staminaGlobe;

    public void DropItems(){
        int randomNum = Random.Range(1, 5);

        if (randomNum == 1)
        {
            // Instantiate(healthGlobe, transform.position, Quaternion.identity);
            LeanPool.Spawn(healthGlobe, transform.position, Quaternion.identity);   
        }

        if (randomNum == 2)
        {
            LeanPool.Spawn(staminaGlobe, transform.position, Quaternion.identity);
        }

        if (randomNum == 3){
            int randomAmountOfGold = Random.Range(1, 4);
            for (int i = 0; i < randomAmountOfGold; i++)
            {
                LeanPool.Spawn(goldCoinPrefab, transform.position, Quaternion.identity);
            }
        }

    }
}
