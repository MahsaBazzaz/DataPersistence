using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void increaseByOne()
    {
        GameManager.manager.health ++;
    }
    public void decreaseByOne()
    {
        GameManager.manager.health --;
    }
}
