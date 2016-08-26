using UnityEngine;
using System.Collections;

public class AutoRemoveTrailObject : MonoBehaviour
{
    private Xft.XWeaponTrail trail;
    private bool RemoveActivated = false;
    private float TargetFrames;
    private float CurrentFrame;

    void Start()
    {
        trail = gameObject.GetComponent<Xft.XWeaponTrail>();
    }

    void Update()
    {
        if (RemoveActivated)
        {
            --CurrentFrame;
            if (CurrentFrame <= 0)
                Destroy(gameObject);
        }
    }

    public void ActivateRemove()
    {
        RemoveActivated = true;
        CurrentFrame = trail.MaxFrame;
    }
}
