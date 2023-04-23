using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound_Controller : MonoBehaviour {

    //Declarations
    public static AudioClip explosionSound,enemyShotSound,enemyDamageSound;
    private static AudioSource audioSource;
    private static float enemyShotVolume;
    private static float explosionVolume;
    private static float enemyDamageVolume;
    //Volume sliders
    [Range(0.01f, 1f)]
    public float enemyShotVolumeValue;
    [Range(0.01f, 1f)]
    public float explosionVolumeValue;
    [Range(0.01f, 1f)]
    public float enemyDamageVolumeValue;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        explosionSound = Resources.Load<AudioClip>("ExplosionSound");
        enemyShotSound = Resources.Load<AudioClip>("EnemyShot");
        enemyDamageSound = Resources.Load<AudioClip>("EnemyDamageSound");
        enemyShotVolume = enemyShotVolumeValue;
        explosionVolume= explosionVolumeValue;
        enemyDamageVolume= enemyDamageVolumeValue;
    }

    //Plays the chosen sound clip
    public static void EnemySound(string clip)
    {
        switch (clip)
        {
            case "ExplosionSound":
                audioSource.PlayOneShot(explosionSound);

                audioSource.volume = explosionVolume;
                break;
            case "EnemyShot":

                audioSource.PlayOneShot(enemyShotSound);
                
                audioSource.volume = enemyShotVolume;
                break;
            case "EnemyDamageSound":

                audioSource.PlayOneShot(enemyDamageSound);

                audioSource.volume = enemyDamageVolume;
                break;
        }
    }
}
