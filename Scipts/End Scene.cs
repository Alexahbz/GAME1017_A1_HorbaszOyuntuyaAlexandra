using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public void TryAgainScene()
    {
        SceneManager.LoadScene("Play Scene");
    }
}
