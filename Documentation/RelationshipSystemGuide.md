# 📖 Relationship System Guide

## 🎯 **System Overview**

The Visual Novel Relationship System is designed to create dynamic, engaging character interactions that evolve based on player choices. At its core, it tracks numerical relationship values for each character and provides meaningful feedback through relationship levels and character reactions.

### **Three-Layer Architecture**

1. **Data Layer** - `CharacterRelationship` stores points, levels, and character info
2. **Management Layer** - `RelationshipManager` handles all relationship logic and updates
3. **Command Layer** - `@addlove` and `@showstats` provide Naninovel integration

---

## 💕 **How Relationships Work**

### **Point-Based Progression**

Every character relationship is tracked through a simple point system:

```csharp
// Example: Bubble tea shop conversation
@char tapioca
Tapioca Pearl-chan: Want to try my new flavor combination?

# Player choice affects relationship
@choice "I'd love to!" goto:boba_yes
@choice "Maybe another time..." goto:boba_maybe

*boba_yes
@addlove CharacterName:tapioca Points:10
Tapioca Pearl-chan: *beams with happiness* Thank you for trying it!
@showstats
@stop

*boba_maybe  
@addlove CharacterName:tapioca Points:-2
Tapioca Pearl-chan: Oh... okay, maybe next time then.
@showstats
@stop
```

### **Relationship Level Thresholds**

The system automatically converts points into meaningful relationship levels:

| Points Range | Level | Meaning | Story Implications |
|--------------|-------|---------|-------------------|
| **80-100** | Soulmate | Deep emotional bond | Romance routes, life-changing events |
| **60-79** | Close Friend | Strong mutual trust | Personal secrets, major story arcs |
| **40-59** | Friend | Solid relationship | Regular hangouts, meaningful conversations |
| **20-39** | Acquaintance | Basic familiarity | Casual interactions, small favors |
| **0-19** | Stranger | Minimal connection | Formal interactions, getting to know each other |

---

## 🎮 **Implementation Strategies**

### **Gradual Relationship Building**

```csharp
# Build relationship through repeated interactions
@char matcha
Matcha-kun: "Thank you for helping me today!"
@addlove CharacterName:matcha Points:5

# Later in the story...
@char matcha  
Matcha-kun: "You're always so kind to me."
@addlove CharacterName:matcha Points:8

# Show current stats
@showstats
```

### **Relationship Types Through Max Points**

Different characters can have different relationship potentials:

```csharp
// Different characters have different maximum relationships
Matcha-kun: Max 100 points (full romance possible)
Tapioca Pearl-chan: Max 75 points (close friend only)
Taro-chan: Max 50 points (casual friend maximum)
```

### **Character Personality Integration**

Adjust point gains based on character personalities:

**Easy-Going Characters** (High point gains)
- Gain: +15 for positive actions
- Loss: -3 for negative actions
- Example: Milk Tea-chan (cheerful, forgiving personality)

**Reserved Characters** (Slow point gains)  
- Gain: +5 for positive actions
- Loss: -8 for negative actions
- Example: Taro-chan (shy, cautious personality)

**Tsundere Characters** (Volatile point changes)
- Gain: +12 for breakthrough moments
- Loss: -10 for misunderstandings
- Example: Brown Sugar-senpai (proud, complex personality)

---

## 🎭 **Advanced Features**

### **Level-up Detection**

The system automatically detects when relationships reach new levels:

```csharp
# Track when relationships reach certain thresholds
@checkRelationship characterName:milktea minPoints:50 maxPoints:50
    # This triggers exactly when hitting 50 points
    Milk Tea-chan: "I feel like we've really connected!"
    @set hasReachedFriend true
```

### **Character Memory System**

Characters can react to relationship history:

```csharp
# Matcha reacts to your relationship with Tapioca
@checkRelationship characterName:tapioca minPoints:75
    @char matcha
    Matcha-kun: "I see you and Tapioca are getting really close..."
    @checkRelationship characterName:matcha minPoints:60
        Matcha-kun: "I... I'm a little jealous, honestly."
        @addlove CharacterName:matcha Points:-3
```

### **Special Events and Milestones**

Create memorable moments based on relationship levels:

```csharp
# Special birthday event for close friends
@checkRelationship characterName:brownsugar minPoints:70
    # Brown Sugar remembers your birthday
    @char brownsugar
    Brown Sugar-senpai: "Happy birthday! I made you something special."
    @addlove CharacterName:brownsugar Points:15
    @set hasBirthdayEvent true
```

---

## 🏆 **Advanced Scenarios**

### **Love Triangles**

Handle competing romantic interests:

```csharp
# Handle competing romantic interests
@checkRelationship characterName:matcha minPoints:60
    @checkRelationship characterName:brownsugar minPoints:60
        # Both characters interested - create tension
        Matcha-kun: "I saw you with Brown Sugar-senpai yesterday..."
        @addlove CharacterName:matcha Points:-5
        @addlove CharacterName:brownsugar Points:-3
```

### **Group Dynamics**

Friend groups where relationships affect each other:

```csharp
# Friend groups where relationships affect each other
@checkRelationship characterName:milktea minPoints:80
    # Other boba shop members respect you more
    @addlove CharacterName:tapioca Points:5
    @addlove CharacterName:taro Points:5
    Tapioca Pearl-chan: "Milk Tea-chan really trusts you!"
```

### **Redemption Arcs**

Allow players to repair damaged relationships:

```csharp
# Allow players to repair damaged relationships
@checkRelationship characterName:brownsugar maxPoints:10
    # Relationship is very low - offer redemption arc
    Brown Sugar-senpai: "I don't know if I can trust you anymore..."
    @choice "Let me make it up to you" goto:redemption_start
    @choice "I understand" goto:accept_consequences
```

---

## ⚖️ **Balancing Guidelines**

### **Point Economy**

Recommended point values for different interaction types:

**Major Positive Actions (+15 to +25)**
- Saving a character from danger
- Major personal sacrifice
- Romantic confession acceptance
- Life-changing support

**Medium Positive Actions (+8 to +12)**
- Thoughtful gifts
- Emotional support during crisis
- Choosing character's side in conflict
- Remembering important details

**Small Positive Actions (+3 to +7)**
- Kind words and compliments
- Small favors and help
- Spending quality time together
- Showing interest in hobbies

**Small Negative Actions (-3 to -7)**
- Ignoring or dismissing concerns
- Minor disappointments
- Choosing someone else over them
- Forgetting promises

**Major Negative Actions (-10 to -20)**
- Betraying trust
- Public embarrassment
- Serious conflicts
- Romantic rejection

### **Pacing Recommendations**

**Story Arc Structure:**
- **Act 1 (0-25 points)**: Getting to know each other, establishing baseline
- **Act 2 (25-60 points)**: Building friendship, deepening connection
- **Act 3 (60-100 points)**: Close bonds, romance potential, major story moments

**Session-by-Session Growth:**
- Aim for 5-15 point changes per major scene
- Allow for both positive and negative fluctuations
- Create meaningful choice consequences

---

## 🎨 **Best Practices**

### **For Writers**

1. **Make every choice matter** - Even small interactions should affect relationships
2. **Show, don't just tell** - Let relationship levels influence dialogue and reactions
3. **Create meaningful consequences** - High/low relationships should unlock different story paths
4. **Balance is key** - Not every interaction needs huge point swings

### **For Developers**

1. **Test relationship curves** - Ensure progression feels natural
2. **Monitor point distribution** - Use @showstats frequently during development
3. **Plan for edge cases** - What happens at 0 points? At maximum?
4. **Consider save/load** - How will relationships persist between sessions?

### **For Game Designers**

1. **Character differentiation** - Each character should feel unique in how relationships develop
2. **Multiple relationship types** - Not everything has to be romantic
3. **Meaningful choice variety** - Offer different ways to build relationships
4. **Player agency** - Always provide paths to improve damaged relationships

---

## 🔮 **Future Possibilities**

This system provides a foundation for advanced relationship mechanics:

- **Save/Load persistence** - Relationships that carry between sessions
- **Visual relationship displays** - UI elements showing current status
- **Cross-character reactions** - Characters commenting on other relationships
- **Relationship-gated content** - Story paths that require specific relationship levels
- **Dynamic dialogue** - Character speech patterns that change with relationship level

---

The relationship system transforms static visual novels into dynamic, emotionally engaging experiences where every choice matters and every character feels alive! 💕