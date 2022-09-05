/*
 * Title : IsmissileController.cs
 * Authors : Titus Abele, Benjamin Mouchet, Guillaume Mouchet, Dorian Tan
 * Date : 25.08.2022
 * Source : 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsmissileController : MonoBehaviour
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        destroyIsmissile.Play();

        if (collision.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Ground"))
        {        
            Debug.Log("touche ground");
            Destroy(gameObject);
        }
    }

    /***************************************************************\
     *                      Attributes private                     *
    \***************************************************************/

    // Components
    private Rigidbody2D rb;

    //Audios
    [SerializeField] private AudioSource destroyIsmissile;
    [SerializeField] private AudioSource IsmissileSound;
}
