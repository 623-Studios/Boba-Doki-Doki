using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("addlove")]
public class AddLoveCommand : Command
{
    public StringParameter CharacterName;
    public IntegerParameter Points;

    public override UniTask Execute(AsyncToken asyncToken = default)
    {
        Debug.Log("=== AddLove command START ===");
        
        // Safety check for RelationshipManager
        if (RelationshipManager.Instance == null)
        {
            Debug.LogError("RelationshipManager.Instance is NULL! Make sure RelationshipManager component is attached to a GameObject in the scene.");
            return UniTask.CompletedTask;
        }
        
        // Check if character name was provided
        if (!Assigned(CharacterName))
        {
            Debug.LogError("CharacterName parameter not assigned in @addlove command!");
            return UniTask.CompletedTask;
        }
        
        // Default points to 5 if not specified
        int pointsToAdd = Assigned(Points) ? Points : 5;
        
        Debug.Log($"Adding {pointsToAdd} points to {CharacterName}");
        
        // Add relationship points
        RelationshipManager.Instance.AddRelationshipPoints(CharacterName, pointsToAdd);
        
        Debug.Log("=== AddLove command END ===");
        return UniTask.CompletedTask;
    }
}

[CommandAlias("showstats")]
public class ShowStatsCommand : Command
{
    public override UniTask Execute(AsyncToken asyncToken = default)
    {
        Debug.Log("=== ShowStats command START ===");
        
        if (RelationshipManager.Instance == null)
        {
            Debug.LogError("RelationshipManager.Instance is NULL!");
            return UniTask.CompletedTask;
        }
        
        RelationshipManager.Instance.ShowAllStats();
        
        Debug.Log("=== ShowStats command END ===");
        return UniTask.CompletedTask;
    }
}
