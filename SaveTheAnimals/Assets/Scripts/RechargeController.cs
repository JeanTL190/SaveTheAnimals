using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject rechargeTooltip;

    private EnergyController energy;

    private PlayerWalk walkController;
    private PlayerDash dashController;
    private PlayerJump jumpController;
    private PlayerFire fireController;

    private Rigidbody2D playerBody;

    private Sounds sounds;

    private SpriteRenderer sprite;

    private bool isHealing = false;
    private float repeatRate = 0.5f;
    private float timer = 0;

    private void Awake ()
    {

        walkController = player.GetComponent<PlayerWalk>();
        dashController = player.GetComponent<PlayerDash>();
        jumpController = player.GetComponent<PlayerJump>();
        fireController = player.GetComponent<PlayerFire>();

        energy = player.GetComponent<EnergyController>();
        playerBody = player.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        sounds = GetComponent<Sounds>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        Debug.Log("Here!");
        if (collision.CompareTag("Player"))
            rechargeTooltip.SetActive(true);
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            rechargeTooltip.SetActive(false);
    }


    private void OnTriggerStay2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (energy.GetEnergy() < 100f)
                {
                    StartHealing();
                }

            }
        }
    }

    private void StartHealing ()
    {
        StartCoroutine(HealEnergy());
    }

    IEnumerator HealEnergy ()
    {
        InputStatus(false);
        playerBody.velocity = Vector2.zero;
        while (energy.GetEnergy() < 100f)
        {
            yield return new WaitForSeconds(0.5f);
            // PlaySound
            energy.ChangeEnergy(25f);
        }
        InputStatus(true);
    }

    // Disable the various inputs from the player
    private void InputStatus (bool status)
    {
        walkController.canWalk = status;
        dashController.canDash = status;
        jumpController.canJump = status;
        fireController.canFire = status;
    }
}
