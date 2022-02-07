using System.Collections;
using System.Collections.Generic;
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

    public void ShowStats() {
        // GameObject text = new GameObject();
        // TextMesh t = text.AddComponent<TextMesh>();
        // t.text = startingHealth.ToString() + "/100";
        // t.fontSize = 30;

        // t.transform.localEulerAngles += new Vector3(0, 0, 0);
        // t.transform.localPosition += new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    public void ReactToHit() {
        currentHealth -= 25;

        if (currentHealth <= 0) {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die() {
        this.transform.Rotate(-90, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}
