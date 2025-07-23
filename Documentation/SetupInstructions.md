# 🛠️ Complete Setup Guide

## 📋 Prerequisites

Before you begin, make sure you have:
- **Unity 2022.3 LTS** or newer
- **Naninovel** visual novel engine installed and configured
- Basic understanding of Unity Inspector and C# scripting
- A working Naninovel project with characters set up

---

## 📥 **Step 1: Download and Import Files**

1. **Download the relationship system files:**
   - `RelationshipManager.cs`
   - `WorkingRelationshipCommand.cs`

2. **Import into your Unity project:**
   ```
   Assets/
   ├── Scripts/
   │   ├── RelationshipManager.cs
   │   └── WorkingRelationshipCommand.cs
   ```

3. **Ensure proper placement:**
   - Both files must be in your project's Scripts folder
   - Unity should compile without errors
   - Check the Console for any missing dependencies

---

## 🎮 **Step 2: Create RelationshipManager GameObject**

1. **Create a new GameObject:**
   - Right-click in Hierarchy
   - Create Empty → Rename to "RelationshipManager"

2. **Add the RelationshipManager component:**
   - Select the RelationshipManager GameObject
   - Click "Add Component" in Inspector
   - Search for "RelationshipManager" and add it

3. **Configure the component:**
   - The system will auto-initialize with 5 characters
   - Characters will have placeholder names initially

---

## ⚙️ **Step 3: Configure Your Characters**

### **Inspector Setup**

1. **Expand the Relationships list** in the RelationshipManager component
2. **Configure each character entry:**

| Setting | Purpose | Example |
|---------|---------|---------|
| **Character Name** | Must match script usage exactly | "brownsugar", "matcha", "tapioca" |
| **Relationship Points** | Current relationship level | 0, 25, 50, 75 |
| **Max Points** | Maximum possible relationship | 100, 150, 200 |

### **Character Name Examples**

```csharp
// Your boba-themed characters
brownsugar  // Brown Sugar-senpai
matcha      // Matcha-kun  
tapioca     // Tapioca Pearl-chan
taro        // Taro-chan
milktea     // Milk Tea-chan
```

### **Max Points Configuration**

```csharp
// Character with low max (hard to please)
Taro-chan: Max Points = 50

// Character with high max (many relationship levels)  
Brownsugar: Max Points = 200
```

---

## 🧪 **Step 4: Test Your Setup**

### **Basic Functionality Test**

1. **Create a new Naninovel script** (`.nani` file):
   ```
   @char matcha
   Matcha-kun: Hello! Let's test the relationship system.

   @addlove CharacterName:matcha Points:10
   Matcha-kun: I feel closer to you now! (+10 relationship)

   @showstats
   ; Check the console to see all relationship stats
   ```

2. **Run the scene** and check:
   - Console shows relationship point changes
   - Inspector updates in real-time
   - No error messages appear

### **Inspector Verification**

✅ **During Play Mode, you should see:**
- Relationship points updating in real-time
- Current Level displaying correctly ("Stranger", "Friend", etc.)
- Progress Percentage calculating automatically

---

## 📝 **Step 5: Script Integration**

### **Adding Relationship Points**
```csharp
// Add points (positive relationship building)
@addlove CharacterName:tapioca Points:15

// Subtract points (negative actions)
@addlove CharacterName:brownsugar Points:-5

// Use default 5 points if not specified
@addlove CharacterName:matcha
```

### **Viewing Relationship Stats**
```csharp
// Show all character relationships in console
@showstats
```

### **Example Story Integration**
```csharp
@char milktea
Milk Tea-chan: Thank you for helping me with the new recipe!

@choice "It was my pleasure!" goto:positive
@choice "No problem." goto:neutral

*positive
@addlove CharacterName:milktea Points:10
Milk Tea-chan: *beams with happiness* You're so kind!
@showstats
@stop

*neutral
@addlove CharacterName:milktea Points:3  
Milk Tea-chan: I appreciate it.
@stop
```

---

## 🎛️ **Step 6: Advanced Configuration**

### **Relationship Progression Curves**

Different characters can have different maximum relationships:

```csharp
// Romantic interest - full relationship possible
matcha: Max Points = 100

// Close friend only - limited romantic potential  
tapioca: Max Points = 75

// Casual acquaintance - surface-level relationship
character5: Max Points = 50
```

### **Character Personality Modifiers**

Adjust point gains based on character personalities:

```csharp
// Easy-going character (gains points quickly)
@addlove CharacterName:milktea Points:15

// Reserved character (gains points slowly)
@addlove CharacterName:taro Points:5

// Tsundere character (volatile point changes)
@addlove CharacterName:brownsugar Points:8
```

---

## 🐛 **Troubleshooting**

### **Common Issues**

**RelationshipManager not found:**
- ✅ Ensure RelationshipManager GameObject exists in scene
- ✅ Component must be attached and enabled
- ✅ Scene must be running (Play Mode)

**Character name errors:**
- ✅ Check spelling in both Inspector and script
- ✅ Names are case-sensitive: "matcha" ≠ "Matcha"
- ✅ Make sure character is added to the relationships list
- ✅ Points parameter defaults to 5 if not specified

**Console errors:**
- ✅ Check Unity Console for specific error messages
- ✅ Ensure Naninovel is properly installed
- ✅ Verify script syntax is correct

### **Debug Commands**

Use these built-in methods for testing:

```csharp
// In Inspector context menu:
- "Initialize Relationships" - Reset character list
- "Add 10 Points to Brown Sugar" - Quick test
- "Reset All Relationships" - Clear all progress
```

---

## ⚡ **Performance Tips**

1. **Limit relationship updates** - Don't call @addlove every dialogue line
2. **Use @showstats sparingly** - Only when needed for debugging
3. **Keep character lists reasonable** - 5-10 characters maximum recommended
4. **Set appropriate max points** - Higher values = more granular progression

---

## 🎯 **Next Steps**

Once your relationship system is working:

1. **Read the [Relationship System Guide](RelationshipSystemGuide.md)** - Learn advanced techniques
2. **Check the [Command Reference](CommandReference.md)** - Master all available commands  
3. **Review [Developer Notes](DeveloperNotes.md)** - Understand the technical implementation
4. **Start building your story** - Create meaningful character interactions!

---

**🎉 Congratulations!** Your relationship system is now ready to create dynamic, emotionally engaging visual novel experiences!