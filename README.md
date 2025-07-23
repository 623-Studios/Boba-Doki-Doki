# 🎮 Visual Novel Relationship System

![Unity](https://img.shields.io/badge/Unity-2022.3%20LTS-000000?style=flat&logo=unity&logoColor=white)
![Naninovel](https://img.shields.io/badge/Naninovel-Compatible-FF6B6B?style=flat)
![C#](https://img.shields.io/badge/C%23-9.0-239120?style=flat&logo=c-sharp&logoColor=white)
![MIT License](https://img.shields.io/badge/License-MIT-yellow?style=flat)

A comprehensive, easy-to-use relationship system for Unity visual novels built with Naninovel. Create dynamic character interactions that evolve based on player choices with just two simple commands!

## ✨ **Key Features**

🎯 **Simple Integration** - Just two commands: `@addlove` and `@showstats`  
💕 **Dynamic Relationships** - 5-tier relationship progression system  
🎮 **Real-time Feedback** - Live Inspector updates during gameplay  
📊 **Visual Progress Tracking** - See relationship levels and percentages  
🔧 **Developer-Friendly** - Built-in debugging and testing tools  
⚡ **Performance Optimized** - Lightweight singleton architecture  
🎨 **Fully Customizable** - Adjust max points, relationship curves, and character reactions  

## 🚀 **Quick Start**

### **Installation**
1. Download the relationship system files
2. Add `RelationshipManager.cs` and `WorkingRelationshipCommand.cs` to your project
3. Create a GameObject with the RelationshipManager component
4. Configure your characters in the Inspector

### **Basic Usage**
```csharp
// In your Naninovel script (.nani file)
@addlove CharacterName:matcha Points:10
@showstats

// Matcha-kun's relationship increases by 10 points
// Console shows all character relationship stats
```

## 📋 **Available Commands**

| Command | Description | Example |
|---------|-------------|---------|
| `@addlove` | Add/subtract relationship points | `@addlove CharacterName:tapioca Points:5` |
| `@showstats` | Display all relationship statistics | `@showstats` |

## 🎯 **Relationship Levels**

| Points | Level | Description |
|--------|-------|-------------|
| 0-19 | **Stranger** | Just met, minimal connection |
| 20-39 | **Acquaintance** | Basic familiarity, casual friendship |
| 40-59 | **Friend** | Good relationship, mutual trust |
| 60-79 | **Close Friend** | Strong bond, deep trust |
| 80-100 | **Soulmate** | Maximum relationship level |

## 💡 **Example Implementation**

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

## 🏗️ **Technical Specifications**

```csharp
// Set up a character with custom relationship settings
[SerializeField] CharacterRelationship matcha = new CharacterRelationship
{
    characterName = "matcha",
    relationshipPoints = 0,
    maxPoints = 100
};
```

**System Requirements:**
- Unity 2022.3 LTS or newer
- Naninovel visual novel engine
- .NET Standard 2.1 compatibility

## 📚 **Documentation**

- **[Setup Instructions](Documentation/SetupInstructions.md)** - Complete installation guide
- **[Relationship System Guide](Documentation/RelationshipSystemGuide.md)** - How the system works
- **[Command Reference](Documentation/CommandReference.md)** - All available commands
- **[Developer Notes](Documentation/DeveloperNotes.md)** - Technical implementation details

## 🌟 **Success Stories**

*"This relationship system transformed my visual novel! Players are now emotionally invested in every choice."* - Indie Game Developer

*"The simplicity is brilliant - just two commands for infinite relationship possibilities."* - Visual Novel Creator

## 🛣️ **Roadmap**

- ✅ Core relationship tracking system
- ✅ Real-time Inspector updates
- ✅ Character reaction system
- 🔄 Save/Load relationship persistence
- 📋 Visual relationship status UI
- 🎨 Custom relationship types (Romance, Friendship, Rivalry)

## 🤝 **Contributing**

We welcome contributions! Whether it's bug fixes, feature additions, or documentation improvements, your help makes this system better for everyone.

## 📄 **License**

This project is licensed under the MIT License - see the LICENSE file for details.

## 💬 **Support**

Having issues? Check our documentation or create an issue in this repository. We're here to help make your visual novel relationships amazing!

---

**Made with ❤️ for the visual novel development community**