using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundDisplay : MonoBehaviour
{

    public static event Action OnNextRound;

    public void NextRoundButton()
    {
        OnNextRound?.Invoke();
    }

}
