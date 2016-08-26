using UnityEngine;
using System.Collections;

public class Spell_Teleport : SpellBase
{
    float maxDistance = 20.0f;
    public GameObject FirstEndPosParticleSys;
    public float FirstEndPosParticleHeight = 0;
    public GameObject SecondEndPosParticleSys;
    public float SecondEndPosParticleHeight = 2;

    public override void use()
    {
        base.use();
        Vector3 teleportPosition = _playerMovement.transform.position;
        Vector3 teleportDirection = _playerMovement.gameObject.transform.forward;
        teleportDirection.y = 0; // playerMovement.gameObject.transform.position.y + 2.0f;

        Ray ray = new Ray(_playerMovement.gameObject.transform.position + new Vector3(0, 1, 0), teleportDirection);
        RaycastHit raycastInfo = new RaycastHit();
        bool raycast = Physics.Raycast(ray, out raycastInfo, maxDistance);
        if (raycast)
        {
            teleportPosition = raycastInfo.point;
        }
        else
        {
            teleportPosition = _playerMovement.gameObject.transform.position + teleportDirection * maxDistance;
        }

        _playerMovement.transform.position = teleportPosition;
        if (FirstEndPosParticleSys)
            Instantiate(FirstEndPosParticleSys, teleportPosition + new Vector3(0, FirstEndPosParticleHeight, 0), FirstEndPosParticleSys.transform.rotation);
        if (SecondEndPosParticleSys)
            Instantiate(SecondEndPosParticleSys, teleportPosition + new Vector3(0, SecondEndPosParticleHeight, 0), SecondEndPosParticleSys.transform.rotation);

        Teleport_fade[] list = Player.player.GetComponentsInChildren<Teleport_fade>();
        foreach (Teleport_fade tp in list)
        {
            tp.Teleported = true;
        }
        Player.player.GetComponent<Teleport_fade>().Teleported = true;
    }
}