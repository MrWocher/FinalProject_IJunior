using UnityEngine;

public class ShootZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.OnShootZone();
            player.Drum.TransitToWeaponStage();
            GetComponent<Collider>().enabled = false;
        }
    }
}
