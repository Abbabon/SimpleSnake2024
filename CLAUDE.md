# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Unity 2D Snake game built with Unity 2022.3.39f1. The game features a classic snake that grows as it eats food, with collision detection for walls and self-collision leading to game over.

## Architecture

The game uses a simple two-script architecture:

- **GameManager** (`Assets/Scripts/GameManager.cs`) - Singleton that manages game state, score, food spawning, wall creation, and game over logic
- **PlayerController** (`Assets/Scripts/PlayerController.cs`) - Singleton that handles snake movement, input processing, and snake body management

### Key Design Patterns
- Singleton pattern for both GameManager and PlayerController
- Event-driven communication between managers
- Grid-based movement system with configurable step timing

### Game Flow
1. GameManager creates walls and spawns initial food
2. PlayerController creates initial snake head
3. Input drives snake movement in discrete steps
4. Collision detection with walls triggers game over
5. Food collision increases score and spawns new food
6. Snake grows by adding new head and keeping tail when eating food

## Unity Project Structure

- `Assets/Scripts/` - Contains the two main game scripts
- `Assets/Prefabs/` - Game object prefabs (Food, SnakePart, Wall)
- `Assets/Scenes/MainScene.unity` - Main game scene
- `Assets/Textures/` - Sprite textures for game objects

## Development Commands

This is a Unity project, so development is done through the Unity Editor:

- Open the project in Unity 2022.3.39f1
- Build through Unity Editor: File → Build Settings → Build
- Play in editor using the Play button
- The game restarts on any key press after game over

## Game Controls

- Arrow keys for snake movement (Up, Down, Left, Right)
- Any key to restart after game over