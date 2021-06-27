using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjects : MonoBehaviour
{
    public GameObject stormTrooper;
    private float tempoSpawnStormTrooper;
    public GameObject powerUp;
    public float tempoSpawnPowerUp = 3;
    private float spawnTimePowerUp;
    public GameObject virus;
    public float tempoSpawnVirus = 1;
    private float spawnTimeVirus;

    void Update(){
        if (Time.time > spawnTimePowerUp){
            criarPowerUp();
            spawnTimePowerUp = Time.time + tempoSpawnPowerUp;
        }

        if (Time.time > spawnTimeVirus){
            criarVirus();
            spawnTimeVirus = Time.time + tempoSpawnVirus;
        }
    }
    void criarPowerUp(){
        Vector3 posicao = new Vector3(9.5f, -3.9f, 0f);
        
        if (tempoSpawnStormTrooper == 5){
            Instantiate(stormTrooper, posicao, Quaternion.identity);
            tempoSpawnStormTrooper = 0;
        } else {
            Instantiate(powerUp, posicao, Quaternion.identity);
            tempoSpawnStormTrooper += 1;
        }
    }

    void criarVirus(){
        Vector3 posicao = new Vector3(8f, -3.9f, 0f);

        Instantiate(virus, posicao, Quaternion.identity);
    }
}
