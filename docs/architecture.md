# ASTRO DODGE – Architecture

## Core Systems

GameManager  
PlayerController  
EnemySpawner  
EnemyController  
ScoreManager  
LeaderboardManager  
UIManager

---

## System Interaction

PlayerController
↓
GameManager
↓
ScoreManager
↓
LeaderboardManager
↓
UIManager

---

## Folder Structure

Assets
 ├ Scripts
 ├ Prefabs
 ├ Scenes
 ├ Sprites
 ├ Audio
 └ UI
