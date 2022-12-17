using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public enum PickupType
    {
        Life = 0,
        Score = 1,
        Weapon = 2
    }

    public PickupType currentPickup;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController curPlayer = collision.gameObject.GetComponent<PlayerController>();

            switch (currentPickup)
            {
                case PickupType.Life:
                    curPlayer.Lives++;
                    break;
                case PickupType.Score:
                    curPlayer.Score++;
                    break;
                case PickupType.Weapon:
                    curPlayer.Weapon++;
                    break;
                    /*case PickupType.Powerup:
                        curPlayer.StartJumpforceChange();
                        break;*/
            }

            Destroy(gameObject);
        }
    }
}
