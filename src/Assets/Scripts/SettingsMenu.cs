using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
   public AudioMixer audioMixer;

   private void Start() {
      SaveSystem.SaveData(200, 200);
      OpponentHPIncreaser.SetOriginal();
   }

   public void SetVolume (float volume)
   {
      audioMixer.SetFloat("volume", Mathf.Log10 (volume) * 20);
   }

   public void SetFullScreen (bool isFullscreen)
   {
      Screen.fullScreen = isFullscreen;
   }

}
