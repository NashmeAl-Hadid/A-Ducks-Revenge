using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound_Controller : MonoBehaviour {
    
    //Declarations
    public static AudioClip shotSound, pickUpSound, playerJumpSound,playerDamageSound;
    private static AudioSource audioSource;
    private static float playerShotVolume;
    private static float playerJumpVolume;
    private static float weaponPickUpVolume;
    private static float playerDamageVolume;
    //Volume sliders
    [Range(0.01f,1f)]
    public float ShotVolumeValue;
    [Range(0.01f, 1f)]
    public float DeathVolumeValue;
    [Range(0.01f, 1f)]
    public float PickUpVolumeValue;
    [Range(0.01f, 1f)]
    public float playerJumpVolumeValue;
    [Range(0.01f, 1f)]
    public float playerDamageVolumeValue;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        playerJumpSound = Resources.Load<AudioClip>("JumpSound");
        shotSound = Resources.Load<AudioClip>("ShotSound");
        pickUpSound = Resources.Load<AudioClip>("WeaponPickUpSound");
        playerDamageSound = Resources.Load<AudioClip>("PlayerDamageSound");
        playerShotVolume = ShotVolumeValue;
        playerJumpVolume = playerJumpVolumeValue;
        weaponPickUpVolume= PickUpVolumeValue;
        playerDamageVolume = playerDamageVolumeValue;      
    }

    //Plays the chosen sound clip
    public static void PlayerSound(string clip)
    {
        switch (clip)
        {
            case "JumpSound":
                audioSource.PlayOneShot(playerJumpSound);

                audioSource.volume = playerJumpVolume;
                break;
            case "ShotSound":
                audioSource.PlayOneShot(shotSound);
                
                audioSource.volume = playerShotVolume;
                break;

            case "PickUpSound":
                audioSource.PlayOneShot(pickUpSound);

                audioSource.volume = weaponPickUpVolume;
                break;

            case "PlayerDamageSound":
                audioSource.PlayOneShot(playerDamageSound);

                audioSource.volume = playerDamageVolume;
                break;
        }
    }
}
