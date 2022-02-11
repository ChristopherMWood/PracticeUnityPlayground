using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthBar;
    public ReactiveTarget target;

    private void Start()
    {
        target = transform.parent.GetComponent<ReactiveTarget>();
        healthBar.maxValue = target.startingHealth;
        healthBar.value = target.currentHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
