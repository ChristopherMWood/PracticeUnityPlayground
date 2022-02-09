using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public int startingHealth = 100;
    private int currentHealth;
    private TextMesh statsMesh;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsAlive() {
        return currentHealth > 0;
    }

    public void ShowStats() {
        // GameObject text = new GameObject();
        // TextMesh t = text.AddComponent<TextMesh>();
        // t.text = startingHealth.ToString() + "/100";
        // t.fontSize = 30;

        // t.transform.localEulerAngles += new Vector3(0, 0, 0);
        // t.transform.localPosition += new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    public void ReactToHit(Vector3 hitDirection) {
        currentHealth -= 25;

        if (currentHealth <= 0) {
            currentHealth = 0;
            StartCoroutine(Die(hitDirection));

        }
    }

    private IEnumerator Die(Vector3 hitDirection) {
        // this.transform.Rotate(-90, 0, 0);

        var rigidBody = GetComponent<Rigidbody>();
        // GET ACTUAL HIT DIRECTION
        // Vector3 dir = new Vector3 (100f, 0f, 0f);
        // dir.Normalize ();
        rigidBody.AddForce (hitDirection * 400);
        // Play death audio

        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }
}
