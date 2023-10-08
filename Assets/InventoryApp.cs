using UnityEngine;
using UnityEngine.UI;
using TMPro; // Include the TextMesh Pro namespace
using System;

public class InventoryApp : MonoBehaviour
{
    public Button obtainPotionButton;
    public Button usePotionButton;  // Button to use a potion, assign in Unity Editor
    public TMP_Text potionCountText;
    public TMP_Text cooldownText;

    private int potionCount;
    private float cooldownTime = 20f;
    private float nextUseTime;

    void Start()
    {
        potionCount = PlayerPrefs.GetInt("HealthPotions", 0);

        // Load saved DateTime for next use
        string nextUseTimeTicksStr = PlayerPrefs.GetString("NextUseTimeTicks", "0");
        long nextUseTimeTicks = long.Parse(nextUseTimeTicksStr);
        DateTime nextUseDateTime = new DateTime(nextUseTimeTicks);
        
        // Calculate remaining cooldown in seconds
        double remainingCooldown = (nextUseDateTime - DateTime.UtcNow).TotalSeconds;

        // Initialize nextUseTime based on remaining cooldown
        nextUseTime = Time.time + (float)remainingCooldown;

        // Initialize UI
        UpdatePotionCountText();
        UpdateCooldownText();

        // Add button click listener
        obtainPotionButton.onClick.AddListener(ObtainPotion);

        // Add button click listener for using a potion
        usePotionButton.onClick.AddListener(UsePotion);
    }

    void Update()
    {
        // Check if the button should be enabled or disabled
        if (Time.time >= nextUseTime)
        {
            obtainPotionButton.interactable = true;
            UpdateCooldownText();
        }
        else
        {
            obtainPotionButton.interactable = false;
            UpdateCooldownText(Mathf.Ceil(nextUseTime - Time.time).ToString());
        }
    }

    void ObtainPotion()
    {
        if (Time.time >= nextUseTime)
        {
            // Add potion to inventory
            potionCount++;
            UpdatePotionCountText();

            // Update next use time
            nextUseTime = Time.time + cooldownTime;

            // Save data
            SaveData();
        }
    }

    void UpdatePotionCountText()
    {
        potionCountText.text = $"Potions: {potionCount}";
    }

    void UpdateCooldownText(string text = "Ready")
    {
        cooldownText.text = $"Cooldown: {text}";
    }

    void SaveData()
    {
       PlayerPrefs.SetInt("HealthPotions", potionCount);

        // Save DateTime for next use time
        DateTime nextUseDateTime = DateTime.UtcNow.AddSeconds(nextUseTime - Time.time);
        string nextUseTimeTicksStr = nextUseDateTime.Ticks.ToString();
        PlayerPrefs.SetString("NextUseTimeTicks", nextUseTimeTicksStr);

        PlayerPrefs.Save();
    }
    public void UsePotion()
    {
        if (potionCount > 0)  // Make sure there's at least one potion to use
        {
            potionCount--;  // Decrement the potion count
            
            // Perform any game logic here, e.g., restore player health
            
            // Update the UI and save the new data
            UpdatePotionCountText();
            SaveData();
        }
        else
        {
            Debug.Log("Out of potions!");  // Log or inform the player that there are no potions left
        }
    }
}
