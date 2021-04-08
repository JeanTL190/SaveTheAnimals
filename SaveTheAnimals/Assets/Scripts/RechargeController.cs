using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject rechargeTooltip;
    [SerializeField] private GameObject checkpoint;

    private EnergyController energy;

    private PlayerWalk walkController;
    private PlayerDash dashController;
    private PlayerJump jumpController;
    private PlayerFire fireController;

    private Rigidbody2D playerBody;

    [SerializeField] private Transform checkpointTransform;
    [SerializeField] private Transform thisTransform;

    private Sounds sounds;

    private SpriteRenderer sprite;

    private bool isHealing = false;
    private bool canHeal = false;
    private float repeatRate = 0.5f;
    private float timer = 0;

    private void Awake ()
    {

        walkController = player.GetComponent<PlayerWalk>();
        dashController = player.GetComponent<PlayerDash>();
        jumpController = player.GetComponent<PlayerJump>();
        fireController = player.GetComponent<PlayerFire>();

        thisTransform = gameObject.GetComponent<Transform>();

        energy = player.GetComponent<EnergyController>();
        playerBody = player.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        sounds = GetComponent<Sounds>();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rechargeTooltip.SetActive(true);
            canHeal = true;
            checkpointTransform.position = thisTransform.position;
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rechargeTooltip.SetActive(false);
            canHeal = false;
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
            yield return new WaitForSeconds(0.01f);
            sounds.StartSom(0);
            energy.ChangeEnergy(1f);
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

    private void Update()
    {
        if(canHeal && Input.GetKeyDown(KeyCode.E))
            StartCoroutine(HealEnergy());
        Debug.Log(this.canHeal);
    }
}

