﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public void ToOptions()
    {
        Application.LoadLevel("Options");
    }
}
