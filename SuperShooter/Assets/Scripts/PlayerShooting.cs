using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public int bulletsAmount;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    Animator animator;
    float lastShootTime;
    public float fireRate;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && bulletsAmount > 0 && Time.timeScale > 0)
        {
            animator.SetBool("Shooting", true);

            // animator will only set true on 1 frame we press down button, so the animation can't 
            // be played successfully, so we check the lastShootTime and use GetKey instead GetKeyDown 
            // to keep shooting, to prevent shooting in every frame, we use fireRate, if lastShootTime
            // less than fireRate, we keep the boolean true and play the whole animation first and don't
            // shoot in this frame.
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < fireRate)
            {
                return;
            }
            lastShootTime = Time.time;

            bulletsAmount--;
            muzzleEffect.Play();
            shootSound.Play();

            //Instantiate(prefab, transform.position, transform.rotation);
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }
        else
        {
            animator.SetBool("Shooting", false);
        }
    }
}
