using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Camera cameraObj;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject aimIndicator;

    private Rigidbody2D crosshairBody;

    private WeaponController weapon;
    private PlayerWalk playerWalk;
    private Sounds sounds;

    private Vector2 mousePosition;
    private float mouseRotation;

    private void Awake ()
    {
        weapon = GetComponent<WeaponController>();
        playerWalk = GetComponent<PlayerWalk>();
        sounds = GetComponent<Sounds>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handles mouse movement and crosshair movement
        mousePosition = cameraObj.ScreenToWorldPoint(Input.mousePosition);
        mouseRotation = (Mathf.Atan2(mousePosition.x - this.transform.position.x, mousePosition.y - this.transform.position.y) * Mathf.Rad2Deg - 90f) * -1f;
        if (mouseRotation < 0f)
        {
            mouseRotation += 360f;
        }

        // Normalize the mouse movement to the position the player is facing
        if (playerWalk.GetRight())
        {
            // If the player is facing right
            if ((mouseRotation > 90f) && (mouseRotation <= 180f))
            {
                mouseRotation = 180f - mouseRotation;
            }
            else if ((mouseRotation > 180f) && (mouseRotation < 270f))
            {
                mouseRotation = -mouseRotation + 180f;
            }
            aimIndicator.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            // If the player is facing left
            if (mouseRotation > 270f)
            {
                mouseRotation = -mouseRotation + 180f;
            }
            else if (mouseRotation < 90f)
            {
                mouseRotation = 180f - mouseRotation;
            }
            aimIndicator.transform.localScale = new Vector3(1f, -1f, 1f);
        }

        // crosshairBody.MovePosition(mousePosition);
        aimIndicator.transform.rotation = Quaternion.Euler(0f, 0f, mouseRotation);

        /*
        // Handles the firing routine (with energy)
        if ((energy.GetEnergy() >= 10f) && (Input.GetButtonDown("Fire1")))
        {
            weapon.Fire(mouseRotation);
            audioManager.PlaySound("EnemySuperBolt");
            energy.ChangeEnergy(-10f);
        } */

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(playerWalk.GetRight());
            sounds.StartSom(3);
            weapon.Fire(mouseRotation);
        }
    }
}
