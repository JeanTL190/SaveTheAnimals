using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyController : EnemyController
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileCooldown = 2f;
    [SerializeField] private float projectileSpeed = 7f;

    private bool canFire = true;

    private void Update ()
    {
        // Ranged enemy attack routine
        if (CanSeePlayer())
        {
            
            // If the player is at the right of the enemy and the enemy is facing right
            // or if the player is at the left of the enemy and the enemy is facing left
            if ((player.transform.position.x > this.transform.position.x && !isFacingRight)
                || (player.transform.position.x < this.transform.position.x && isFacingRight))
            {
                Debug.Log("Fire!");
                if (canFire)
                    FireProjectile();
            }
        }
    }

    private void FireProjectile ()
    {
        Arrow projectileObj;
        canFire = false;
        GameObject newProjectile = Instantiate(projectile, this.transform.position, Quaternion.identity);
        projectileObj = newProjectile.GetComponent<Arrow>();
        projectileObj.FireDirection(Vector3.Normalize(player.transform.position - newProjectile.transform.position) * projectileSpeed);
        StartCoroutine(Cooldown(projectileCooldown));
    }

    IEnumerator Cooldown (float time)
    {
        yield return new WaitForSeconds(time);
        canFire = true;
    }
}
