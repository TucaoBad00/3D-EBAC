using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadHelper : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
