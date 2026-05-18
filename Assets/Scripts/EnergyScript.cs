using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour
{
    public Sprite s100;
    public Sprite s92;
    public Sprite s83;
    public Sprite s75;
    public Sprite s67;
    public Sprite s59;
    public Sprite s51;
    public Sprite s43;
    public Sprite s35;
    public Sprite s27;
    public Sprite s19;
    public Sprite s11;
    public Sprite s0;

    public GameObject Panel;

    public static float MaxEnergy = 100f;

    private float time = 0f;
    private Image img;

    void Start()
    {
        img = Panel.GetComponent<Image>();
        UpdateSprite();
        Debug.Log(img);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 1f)
        {
            MaxEnergy -= 1;
            MaxEnergy = Mathf.Clamp(MaxEnergy, 0, 100);

            UpdateSprite();

            time = 0f;

            Debug.Log(MaxEnergy);
        }
    }

    public void UpdateSprite()
    {
        if (MaxEnergy >= 100f) img.sprite = s100;
        else if (MaxEnergy >= 92f) img.sprite = s92;
        else if (MaxEnergy >= 83f) img.sprite = s83;
        else if (MaxEnergy >= 75f) img.sprite = s75;
        else if (MaxEnergy >= 67f) img.sprite = s67;
        else if (MaxEnergy >= 59f) img.sprite = s59;
        else if (MaxEnergy >= 51f) img.sprite = s51;
        else if (MaxEnergy >= 43f) img.sprite = s43;
        else if (MaxEnergy >= 35f) img.sprite = s35;
        else if (MaxEnergy >= 27f) img.sprite = s27;
        else if (MaxEnergy >= 19f) img.sprite = s19;
        else if (MaxEnergy >= 11f) img.sprite = s11;
        else img.sprite = s0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Buff")
        {
            if (collision.name == "BatteryCharge50%")
            {
                MaxEnergy += 40f;
            }
            else if (collision.name == "LightingCharge100%")
            {
                MaxEnergy += 70f;
            }

            MaxEnergy = Mathf.Clamp(MaxEnergy, 0, 100);
            UpdateSprite();
        }
    }
}