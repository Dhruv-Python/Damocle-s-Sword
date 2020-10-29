using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioClip bossDeath, bossShoot, coreExplosion, enemyDeath, enemyShoot, explosion, turrentShoot;
    static AudioSource audioSrc;

    void Start()
    {
        bossDeath = Resources.Load<AudioClip> ("BossDeath_Sound");

        bossShoot = Resources.Load<AudioClip> ("BossShoot_Sound");

        coreExplosion = Resources.Load<AudioClip> ("CoreExplosion_Sound");

        enemyDeath = Resources.Load<AudioClip> ("EnemyDeath_Sound");

        enemyShoot = Resources.Load<AudioClip> ("EnemyShoot_Sound");

        explosion = Resources.Load<AudioClip> ("Explosion_Sound");

        turrentShoot = Resources.Load<AudioClip> ("turrentShoot_Sound");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
            case "BossDeath_Sound":
                audioSrc.PlayOneShot(bossDeath);
                break;
            case "BossShoot_Sound":
                audioSrc.PlayOneShot(bossShoot);
                break;
            case "CoreExplosion_Sound":
                audioSrc.PlayOneShot(coreExplosion);
                break;
            case "EnemyDeath_Sound":
                audioSrc.PlayOneShot(enemyDeath);
                break;
            case "EnemyShoot_Sound":
                audioSrc.PlayOneShot(enemyShoot);
                break;
            case "Explosion_Sound":
                audioSrc.PlayOneShot(explosion);
                break;
            case "turrentShoot_Sound":
                audioSrc.PlayOneShot(turrentShoot);
                break;
        }
    }

}
