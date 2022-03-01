using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoPlayerGameButtonManager : MonoBehaviour
{
    public void loadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
