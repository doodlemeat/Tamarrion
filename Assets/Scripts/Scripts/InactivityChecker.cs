using UnityEngine;
using System.Collections;

public class InactivityChecker
{
    public bool ActiveCheck()
    {
        if (Input.anyKeyDown)
            return true;
        else if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            return true;

        return false;
    }
}