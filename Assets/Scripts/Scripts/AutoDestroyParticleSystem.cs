using UnityEngine;
using System.Collections;

public class AutoDestroyParticleSystem : MonoBehaviour
{
    public bool DestroyWhenOrphan = false;
    public float _Delay = 0;
    private float DelayCurrent = 0;
    private ParticleSystem particleSys;

    public float Delay
    {
        get
        {
            return _Delay;
        }
        set
        {
            _Delay = value;
            DelayCurrent = value;
        }
    }

    void Start()
    {
        DelayCurrent = Delay;
        particleSys = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (particleSys && !particleSys.IsAlive())
        {
            Destroy(gameObject);
        }

        if (DestroyWhenOrphan)
        {
            if (!transform.parent && particleSys.enableEmission)
                RunDelayDestruction();
        }
        else
        {
            if (particleSys.enableEmission && Delay > 0)
                RunDelayDestruction();
        }
    }

    void RunDelayDestruction()
    {
        DelayCurrent -= Time.deltaTime;
        if (DelayCurrent <= 0)
        {
            DelayCurrent = 0;
            particleSys.enableEmission = false;
            particleSys.loop = false;
            foreach (Transform child in gameObject.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}