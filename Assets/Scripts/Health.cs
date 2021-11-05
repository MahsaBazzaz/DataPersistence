using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void increaseByOne()
    {
        GameManager.manager.health++;
        PlayerPrefs.SetInt("health", GameManager.manager.health); // NOT a good solution
    }
    public void decreaseByOne()
    {
        GameManager.manager.health--;
        PlayerPrefs.SetInt("health", GameManager.manager.health);
    }
}
