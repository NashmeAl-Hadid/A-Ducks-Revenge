using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSound_Controller : MonoBehaviour {
    //Declarations
    public static AudioClip coinSound, deathSound,checkpointSound,explosionSound,potionSound,leverSound;
    private static AudioSource audioSource;
    private static float playerDeathVolume;
    private static float potionVolume;
    private static float leverVolume;
    private static float checkpointVolume;
    private static float explosionVolume;
    //Volume sliders
    [Range(0.01f, 1f)]
    public float explosionVolumeValue;
    [Range(0.01f, 1f)]
    public float potionVolumeValue;
    [Range(0.01f, 1f)]
    public float DeathVolumeValue;
    [Range(0.01f, 1f)]
    public float checkpointVolumeValue;
    [Range(0.01f, 1f)]
    public float leverVolumeValue;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coinSound = Resources.Load<AudioClip>("CoinSound");
        deathSound = Resources.Load<AudioClip>("YouDiedSound");
        checkpointSound = Resources.Load<AudioClip>("CheckpointSound");
        explosionSound = Resources.Load<AudioClip>("ExplosionSound");
        potionSound = Resources.Load<AudioClip>("PotionSound");
        leverSound = Resources.Load<AudioClip>("LeverSound");
        playerDeathVolume = DeathVolumeValue;
        checkpointVolume = checkpointVolumeValue;
        explosionVolume = explosionVolumeValue;
        potionVolume = potionVolumeValue;
        leverVolume = leverVolumeValue;
    }

    //Plays the chosen sound clip
    public static void OtherSound(string clip)
    {
        switch (clip)
        {
            case "CoinSound":
                audioSource.PlayOneShot(coinSound);
             
                break;

            case "YouDiedSound":
                audioSource.PlayOneShot(deathSound);

                audioSource.volume = playerDeathVolume;
                break;

            case "CheckpointSound":
                audioSource.PlayOneShot(checkpointSound);

                audioSource.volume = checkpointVolume;
                break;
            case "ExplosionSound":
                audioSource.PlayOneShot(explosionSound);

                audioSource.volume = explosionVolume;
                break;

            case "PotionSound":
                audioSource.PlayOneShot(potionSound);

                audioSource.volume = potionVolume;
                break;

            case "LeverSound":
                audioSource.PlayOneShot(leverSound);

                audioSource.volume = leverVolume;
                break;
        }
    }
}
