# 📚 Command Reference Guide

## 🎯 **Overview**

This guide provides complete documentation for the two custom Naninovel commands in the Visual Novel Relationship System. These commands allow you to build dynamic character relationships through point-based interactions.

---

## 📋 **Available Commands**

### **1. @addlove - Add/Subtract Relationship Points**

**Purpose:** Modify a character's relationship points based on player choices or story events.

**Syntax:**
```csharp
@addlove CharacterName:[character] Points:[number]
```

**Parameters:**
- **CharacterName** (Required): The exact character name as defined in RelationshipManager
- **Points** (Optional): Number of points to add/subtract. Defaults to 5 if not specified.

**Examples:**

**Basic Usage:**
```csharp
# Add 10 points to matcha
@addlove CharacterName:matcha Points:10

# Subtract 5 points from brownsugar  
@addlove CharacterName:brownsugar Points:-5

# Use default 5 points for tapioca
@addlove CharacterName:tapioca
```

**Story Integration:**
```csharp
@char milktea
Player: "I brought you your favorite flavor!"
Milk Tea-chan: *lights up with joy* Really?! Thank you so much!
@addlove CharacterName:milktea Points:15

@char taro
Player: "Sorry, I forgot to bring what you asked for..."
Taro-chan: *disappointed* Oh... that's okay, I guess.
@addlove CharacterName:taro Points:-3
```

**Point Values Guide:**
- **+15 to +20**: Major positive actions (gifts, saving them, confession)
- **+8 to +12**: Medium positive actions (helping, compliments, quality time)
- **+3 to +7**: Small positive actions (greeting, small talk, kindness)
- **-3 to -7**: Small negative actions (ignoring, mild rudeness)
- **-8 to -15**: Major negative actions (betrayal, serious conflict)

---

### **2. @showstats - Display All Relationship Statistics**

**Purpose:** Show current relationship points and levels for all characters in the console log.

**Syntax:**
```csharp
@showstats
```

**Parameters:** None

**Examples:**

**Basic Usage:**
```csharp
# Display all relationship stats
@showstats
```

**Testing Integration:**
```csharp
@char matcha
Matcha-kun: How do you feel about everyone in the boba shop?
@showstats

# Console will show:
# === 💕 RELATIONSHIP STATS 💕 ===
# brownsugar: 45/100 (Friend)
# matcha: 32/100 (Acquaintance)  
# tapioca: 18/100 (Stranger)
# taro: 67/100 (Close Friend)
# milktea: 8/100 (Stranger)
# ================================
```

**Debug Usage:**
```csharp
# Use for testing and balancing
Player makes a major choice...
@addlove CharacterName:brownsugar Points:20
@addlove CharacterName:matcha Points:-10
@showstats
; Check console to see how the choice affected all relationships
```

---

## 🎮 **Relationship Level System**

Your system uses these relationship levels based on points:

| Points Range | Level | Description |
|--------------|-------|-------------|
| 0-19 | **Stranger** | Just met, minimal connection |
| 20-39 | **Acquaintance** | Basic familiarity, casual friendship |
| 40-59 | **Friend** | Good relationship, mutual trust |
| 60-79 | **Close Friend** | Strong bond, deep trust |
| 80-100 | **Soulmate** | Maximum relationship level |

---

## 💡 **Best Practices**

### **Character Name Matching**
```csharp
# ✅ CORRECT - matches RelationshipManager exactly
@addlove CharacterName:brownsugar Points:10

# ❌ WRONG - case mismatch
@addlove CharacterName:BrownSugar Points:10

# ❌ WRONG - parameter name error  
@addlove characterName:brownsugar points:10
```

### **Point Economy Balance**
```csharp
# ✅ GOOD - Gradual progression
@addlove CharacterName:matcha Points:5   # Small positive interaction
@addlove CharacterName:matcha Points:10  # Medium positive choice
@addlove CharacterName:matcha Points:15  # Major story moment

# ❌ AVOID - Too extreme
@addlove CharacterName:matcha Points:50  # Jumps too many levels at once
```

### **Story Pacing**
```csharp
# ✅ GOOD - Regular relationship building
Scene 1: @addlove CharacterName:tapioca Points:8
Scene 3: @addlove CharacterName:tapioca Points:6  
Scene 5: @addlove CharacterName:tapioca Points:12

# Check progress periodically
@showstats
```

---

## 🔧 **Troubleshooting**

### **Common Issues**

**Character Not Found:**
```
❌ Problem: "Character 'Matcha' not found in relationships"
✅ Solution: Use exact name from RelationshipManager: "matcha"
```

**Parameter Not Assigned:**
```
❌ Problem: "CharacterName parameter not assigned"
✅ Solution: Always include CharacterName parameter
```

**RelationshipManager Missing:**
```
❌ Problem: "RelationshipManager.Instance is NULL!"
✅ Solution: Ensure RelationshipManager component is in scene
```

### **Testing Commands**
```csharp
# Test your setup
@addlove CharacterName:brownsugar Points:25
@showstats

# Should show in console:
# "💕 brownsugar: +25 points = 25/100 (Acquaintance)"
# "=== 💕 RELATIONSHIP STATS 💕 ==="
```

---

## 📈 **Implementation Examples**

### **Choice-Based Relationships**
```csharp
@char brownsugar
Brown Sugar-senpai: Would you like to study together?

@choice "Yes, I'd love to!" goto:study_yes
@choice "Sorry, I'm busy." goto:study_no

*study_yes
@addlove CharacterName:brownsugar Points:12
Brown Sugar-senpai: Great! I'm so happy we can spend time together.
@showstats
@stop

*study_no
@addlove CharacterName:brownsugar Points:-2
Brown Sugar-senpai: Oh... okay, maybe another time.
@stop
```

### **Character Development Arcs**
```csharp
# Beginning of story
@addlove CharacterName:matcha Points:5
Matcha-kun: Nice to meet you!

# Middle of story  
@addlove CharacterName:matcha Points:10
Matcha-kun: I'm starting to really enjoy our conversations.

# Major story event
@addlove CharacterName:matcha Points:20
Matcha-kun: Thank you for believing in me when no one else did!

# Check final relationship
@showstats
```

### **Multiple Character Interactions**
```csharp
# Helping at the boba shop affects multiple relationships
@char milktea
@char tapioca
Milk Tea-chan & Tapioca Pearl-chan: Thank you for helping us today!

@addlove CharacterName:milktea Points:8
@addlove CharacterName:tapioca Points:8
@showstats

# Both characters gained relationship points
```

---

This command reference covers all functionality available in your current relationship system implementation. The system focuses on building meaningful connections through consistent point-based interactions! 💕