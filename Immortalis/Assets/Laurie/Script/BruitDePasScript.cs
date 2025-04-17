using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitDePasScript : MonoBehaviour
{
    public AudioSource[] bruitsdepas;
    public Player_movement velocityPlayer;

    public float intervalTempsPas = 0.4f; // temps entre les pas
    private float timerPas;

    void Update()
    {
        Vector3 velocity = velocityPlayer.Velocity;
        float vitesse = new Vector2(velocity.x, velocity.z).magnitude; // on ignore Y pour éviter les sauts

        if (vitesse > 0.1f) // Si le joueur bouge
        {
            timerPas -= Time.deltaTime;

            if (timerPas <= 0f)
            {
                int randomIndex = Random.Range(0, bruitsdepas.Length);
                bruitsdepas[randomIndex].Play();
                timerPas = intervalTempsPas;
            }
        }
        else
        {
            // Reset le timer pour éviter que le son joue instantanément à la reprise
            timerPas = 0f;
        }
    }
}