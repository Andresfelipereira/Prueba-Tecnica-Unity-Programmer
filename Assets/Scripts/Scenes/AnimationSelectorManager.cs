using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationSelectorManager : MonoBehaviour
{
    public Animator characterAnimator;
    public GameObject notSelectedAnimationMsg;

    void Start()
    {
        notSelectedAnimationMsg.SetActive(false);
        if (PlayerPrefs.GetString("SelectedAnimation") != "") 
        {
            PlayerPrefs.SetString("SelectedAnimation", "");
        }
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetString("SelectedAnimation") == "")
        {
            StartCoroutine(ShowNotSelectedAnimationMsg());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void StartHouseDancingAnimation()
    {
        Button pressedBtn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        pressedBtn.enabled = false;
        notSelectedAnimationMsg.SetActive(false);
        characterAnimator.StopPlayback();
        characterAnimator.SetBool("HouseDancing", true);
        characterAnimator.SetBool("MacarenaDance", false);
        characterAnimator.SetBool("WaveHipHopDance", false);
        PlayerPrefs.SetString("SelectedAnimation", "HouseDancing");
    }

    public void StartMacarenaDanceAnimation()
    {
        notSelectedAnimationMsg.SetActive(false);
        characterAnimator.StopPlayback();
        characterAnimator.SetBool("HouseDancing", false);
        characterAnimator.SetBool("MacarenaDance", true);
        characterAnimator.SetBool("WaveHipHopDance", false);
        PlayerPrefs.SetString("SelectedAnimation", "MacarenaDance");
    }

    public void StartWaveHipHopDanceAnimation()
    {
        notSelectedAnimationMsg.SetActive(false);
        characterAnimator.SetBool("HouseDancing", false);
        characterAnimator.SetBool("MacarenaDance", false);
        characterAnimator.SetBool("WaveHipHopDance", true);
        PlayerPrefs.SetString("SelectedAnimation", "WaveHipHopDance");
    }

    IEnumerator ShowNotSelectedAnimationMsg()
    {
        notSelectedAnimationMsg.SetActive(true);
        yield return new WaitForSeconds(2);
        notSelectedAnimationMsg.SetActive(false);
    }
}
