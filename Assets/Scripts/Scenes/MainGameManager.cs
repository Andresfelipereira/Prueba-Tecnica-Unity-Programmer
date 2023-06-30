using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public Animator characterAnimator;

    void Start()
    {
        string selectedCharacterAnimation = PlayerPrefs.GetString("SelectedAnimation");
        if(selectedCharacterAnimation != null)
        {
            characterAnimator.SetBool(selectedCharacterAnimation, true);
        }
    }
}
