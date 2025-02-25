using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginScene : MonoBehaviour
{
    public Button play;

    public void Start()
    {
        play.onClick.AddListener(LoadPlayScene);
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("Play Scene");
    }


}


