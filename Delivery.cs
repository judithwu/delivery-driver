using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour {
    
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    [SerializeField] float deleteDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Collided");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, deleteDelay);
        } else if (other.tag == "Customer" && hasPackage) {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
