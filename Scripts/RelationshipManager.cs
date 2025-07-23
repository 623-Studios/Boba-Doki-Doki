using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterRelationship
{
    [Header("Character Info")]
    public string characterName;
    
    [Header("Relationship Progress")]
    [Range(0, 100)]
    public int relationshipPoints = 0;
    [Range(50, 200)]
    public int maxPoints = 100;
    
    [Header("Display Info (Read Only)")]
    [SerializeField] private string currentLevel;
    [SerializeField] private float progressPercentage;
    
    public float GetRelationshipPercentage()
    {
        progressPercentage = (float)relationshipPoints / maxPoints;
        return progressPercentage;
    }
    
    public string GetRelationshipLevel()
    {
        if (relationshipPoints >= 80) currentLevel = "Soulmate";
        else if (relationshipPoints >= 60) currentLevel = "Close Friend"; 
        else if (relationshipPoints >= 40) currentLevel = "Friend";
        else if (relationshipPoints >= 20) currentLevel = "Acquaintance";
        else currentLevel = "Stranger";
        
        return currentLevel;
    }
    
    // Update display info for Inspector
    public void UpdateDisplayInfo()
    {
        GetRelationshipLevel();
        GetRelationshipPercentage();
    }
}

public class RelationshipManager : MonoBehaviour
{
    [Header("Character Relationships")]
    public List<CharacterRelationship> relationships = new List<CharacterRelationship>();
    
    public static RelationshipManager Instance;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeRelationships();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Add Update method to refresh Inspector in real-time
    void Update()
    {
        // Only update in play mode for performance
        if (Application.isPlaying)
        {
            // Update display info for all relationships
            foreach (var rel in relationships)
            {
                if (rel != null)
                {
                    rel.UpdateDisplayInfo();
                }
            }
        }
    }
    
    void InitializeRelationships()
    {
        // Initialize all 5 characters
        string[] characterNames = { "brownsugar", "character2", "character3", "character4", "character5" };
        
        // Clear existing relationships to avoid duplicates
        if (relationships == null)
            relationships = new List<CharacterRelationship>();
        
        foreach (string name in characterNames)
        {
            if (GetRelationship(name) == null)
            {
                var newRelationship = new CharacterRelationship { characterName = name };
                relationships.Add(newRelationship);
            }
        }
        
        Debug.Log("RelationshipManager initialized with " + relationships.Count + " characters");
    }
    
    // Add this method to initialize relationships in the Inspector
    [ContextMenu("Initialize Relationships")]
    public void InitializeRelationshipsInEditor()
    {
        InitializeRelationships();
        ForceInspectorUpdate();
    }
    
    // Add this method for easy testing in the Inspector
    [ContextMenu("Add 10 Points to Brown Sugar")]
    public void TestAddPoints()
    {
        AddRelationshipPoints("brownsugar", 10);
        ForceInspectorUpdate();
    }
    
    // Add this method to reset all relationships for testing
    [ContextMenu("Reset All Relationships")]
    public void ResetAllRelationships()
    {
        foreach (var rel in relationships)
        {
            rel.relationshipPoints = 0;
            rel.UpdateDisplayInfo();
        }
        ForceInspectorUpdate();
        Debug.Log("All relationships reset to 0");
    }
    
    // Force Inspector to update
    private void ForceInspectorUpdate()
    {
        foreach (var rel in relationships)
        {
            if (rel != null)
            {
                rel.UpdateDisplayInfo();
            }
        }
        
        #if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
    
    public CharacterRelationship GetRelationship(string characterName)
    {
        if (string.IsNullOrEmpty(characterName))
        {
            Debug.LogWarning("GetRelationship called with null or empty character name");
            return null;
        }
        
        return relationships.Find(r => r.characterName.ToLower() == characterName.ToLower());
    }
    
    public void AddRelationshipPoints(string characterName, int points)
    {
        if (string.IsNullOrEmpty(characterName))
        {
            Debug.LogWarning("AddRelationshipPoints called with null or empty character name");
            return;
        }
        
        var relationship = GetRelationship(characterName);
        if (relationship != null)
        {
            int oldPoints = relationship.relationshipPoints;
            string oldLevel = GetLevelForPoints(oldPoints);
            
            relationship.relationshipPoints = Mathf.Clamp(
                relationship.relationshipPoints + points, 
                0, 
                relationship.maxPoints
            );
            
            // Update Inspector display info
            relationship.UpdateDisplayInfo();
            
            Debug.Log($"💕 {characterName}: +{points} points = {relationship.relationshipPoints}/{relationship.maxPoints} ({relationship.GetRelationshipLevel()})");
            
            // Check for level up and store reaction
            string newLevel = relationship.GetRelationshipLevel();
            if (oldLevel != newLevel)
            {
                Debug.Log($"🎉 LEVEL UP! {characterName}: {oldLevel} → {newLevel}!");
                
                // Store the level up info for dialogue use
                lastLevelUpCharacter = characterName;
                lastLevelUpFrom = oldLevel;
                lastLevelUpTo = newLevel;
                hasRecentLevelUp = true;
            }
        }
        else
        {
            Debug.LogWarning($"Character '{characterName}' not found in relationships");
        }
    }
    
    // Add these fields to track level ups for dialogue
    [System.NonSerialized]
    public string lastLevelUpCharacter = "";
    [System.NonSerialized]
    public string lastLevelUpFrom = "";
    [System.NonSerialized]
    public string lastLevelUpTo = "";
    [System.NonSerialized]
    public bool hasRecentLevelUp = false;
    
    // Method to get character reaction dialogue
    public string GetCharacterReaction(string characterName)
    {
        var relationship = GetRelationship(characterName);
        if (relationship == null) return "I don't know you well enough to say...";
        
        string level = relationship.GetRelationshipLevel();
        int points = relationship.relationshipPoints;
        
        // Different reactions based on relationship level
        switch (level)
        {
            case "Stranger":
                if (points < 10) return "We've just met, but you seem nice!";
                else return "I'm starting to feel comfortable around you.";
                
            case "Acquaintance":
                if (points < 30) return "I enjoy talking with you!";
                else return "You're someone I can rely on.";
                
            case "Friend":
                if (points < 50) return "I'm so glad we're friends!";
                else return "You're one of my closest friends now!";
                
            case "Close Friend":
                if (points < 70) return "I trust you completely!";
                else return "You mean so much to me!";
                
            case "Soulmate":
                return "I can't imagine my life without you!";
                
            default:
                return "Our bond is special in its own way.";
        }
    }
    
    // Method to get level up reaction
    public string GetLevelUpReaction(string characterName)
    {
        if (!hasRecentLevelUp || lastLevelUpCharacter != characterName)
            return "";
            
        hasRecentLevelUp = false; // Clear the flag after use
        
        string reaction = "";
        switch (lastLevelUpTo)
        {
            case "Acquaintance":
                reaction = "*smiles warmly* I feel like we're getting to know each other better!";
                break;
            case "Friend":
                reaction = "*lights up with joy* We're really friends now, aren't we? This makes me so happy!";
                break;
            case "Close Friend":
                reaction = "*blushes* You've become someone really special to me...";
                break;
            case "Soulmate":
                reaction = "*tears of joy* You're... you're everything to me! I'm so grateful we found each other!";
                break;
            default:
                reaction = "*happy expression* Our relationship feels stronger now!";
                break;
        }
        
        return reaction;
    }
    
    private string GetLevelForPoints(int points)
    {
        if (points >= 80) return "Soulmate";
        if (points >= 60) return "Close Friend"; 
        if (points >= 40) return "Friend";
        if (points >= 20) return "Acquaintance";
        return "Stranger";
    }
    
    public int GetRelationshipPoints(string characterName)
    {
        var relationship = GetRelationship(characterName);
        return relationship?.relationshipPoints ?? 0;
    }
    
    public void ShowAllStats()
    {
        Debug.Log("=== 💕 RELATIONSHIP STATS 💕 ===");
        foreach (var rel in relationships)
        {
            rel.UpdateDisplayInfo(); // Update Inspector display
            Debug.Log($"{rel.characterName}: {rel.relationshipPoints}/{rel.maxPoints} ({rel.GetRelationshipLevel()})");
        }
        Debug.Log("================================");
    }
}