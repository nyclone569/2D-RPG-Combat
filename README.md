# 2D-RPG-Unity
This is a simple 2D top-down RPG project developed using **Unity** as a way to practice and learn the fundamentals of game development. The project currently includes basic movement and simple combat mechanics, and will be expanded in the future with more features like a story, skill and level system, quests.

---

## 📌 Current Features

### 🎮 Core Gameplay
- **Player Movement**: 4-direction movement with basic animations (use WASD)
- **Weapon System**: 3 switchable weapons (use keys 1, 2, 3 to swap)
  - Sword (melee swing)
  - Arrow (fire projectile)
  - Magic staff (magic beam)
- **Player Stats**:
  - Health & Stamina
  - Death animation when health reaches 0
- **Enemy Stats**:
  - Health only 
  - Death when health reaches 0

### 🤖 Enemy AI & Pathfinding
- **3-State AI**:
  - `Idle`: Stays still
  - `Roam`: Moves in a random direction
  - `Attack`: Uses abilities to attack the player
- **Enemy Attacks**:
  - `Slime`: Deals damage on contact
  - `Grape`: Launches a projectile into air that falls onto the player
  - `Shooter`: Fires oscillating projectiles
- **No advanced navigation** — all movement is based on random direction (will update in the future)

### 🧾 UI System
- Health bar & stamina slot for player
- Weapon selection UI (3 weapon icons)
- Coin counter (basic currency display)

### 💰 Economy System (Prototype)
- Coins dropped from:
  - Destroyable objects (e.g. bushes)
  - Enemies upon death
- No shop or upgrades system yet (planned)

### 🎨 Visual Effects
- **Screen Shake**: Triggered when the player takes damage
- **Canopy Parallax**: Scrolling background layer (tilemap)
- **Canopy Transparency**:
  - Tilemaps and environment become transparent when player walks under them
- **Custom Shaders**:
  - Glow effect on torches
  - Flash effect on hit
  - Scrolling background in menu

### 🔊 Audio System
- **AudioManager** with categorized sounds:
  - Menu background music
  - In-game background music
  - Attack sounds 
  - Dash sound
  - Map transition sound
  - Player hurt SFX
  - Enemy death SFX
- **Volume control sliders** in the settings menu

---

## ❗ Not Yet Implemented

- ❌ Story or narrative system  
- ❌ Skill tree system
- ❌ Experience / leveling system  
- ❌ Inventory / equipment system  
- ❌ NPCs, questlines or dialogue  
- ❌ Shop / coin usage

These features are planned for future development as part of the learning process.

---

## 🧠 Purpose of the Project

This is a **free, non-commercial, personal learning project** created to:

- Practice Unity 2D game development
- Implement modular systems (combat, UI, audio)
- Experiment with shader graph & post-processing
- Lay the groundwork for future projects

---

## 🙌 Notes
- I'm still new to game developer, so if you have any suggestion or feedback, feel free to contact me at: 📧 `nyclone569@gmail.com`
- All assets used in this project are from **free resources** (e.g. [itch.io](https://itch.io), [craftpix.net](https://craftpix.net)), and some lightly edited using **Aseprite**.