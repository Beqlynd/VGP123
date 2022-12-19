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
                    GameManager.instance.Lives++;
                    break;
                case PickupType.Score:
                    GameManager.instance.Score++;
                    break;
                case PickupType.Weapon:
                    GameManager.instance.Weapon++;
                    break;
                    /*case PickupType.Powerup:
                        curPlayer.StartJumpforceChange();
                        break;*/
            }

            Destroy(gameObject);
        }
    }
}
