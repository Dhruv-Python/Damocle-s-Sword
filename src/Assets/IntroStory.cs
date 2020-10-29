using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroStory : MonoBehaviour
{
    [SerializeField] GameObject Text;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject BG;
    [SerializeField] AudioSource OST;

    private void Update()
    {
        Text.transform.position += new Vector3(0f, 40 * Time.deltaTime);

        if(Time.time >= 60f)
        {
            FinishStory();
        }

        if(Input.GetButtonDown("Fire1")) { FinishStory(); }
    }

    private void FinishStory()
    {
        mainMenu.SetActive(true);
        BG.SetActive(true);
        OST.Play(0);
        gameObject.SetActive(false);
    }
}
