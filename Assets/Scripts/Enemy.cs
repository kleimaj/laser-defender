using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] float health = 100;
    [SerializeField] int score = 150;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] float projectileSpeed = -5f;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip destroyedSound;

    void Start() {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);    
    }

    void Update() {
        CountDownAndShoot();
    }

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f) {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire() {
        PlayShootSFX();
        GameObject projectile = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        // if there's no damageDealer, don't do anything
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0) {
            FindObjectOfType<GameSession>().UpdateScore(score);
            Destroy(gameObject);
            PlayDestroyedSFX();
            TriggerDestroyedVFX();
        }
    }

    private void PlayDestroyedSFX() {
        AudioSource.PlayClipAtPoint(destroyedSound, Camera.main.transform.position);
    }

    private void PlayShootSFX() {
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
    }

    private void TriggerDestroyedVFX() {
        GameObject explosion = Instantiate(destroyedVFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
    }
}
