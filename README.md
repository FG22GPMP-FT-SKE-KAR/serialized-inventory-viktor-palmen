[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/IBKm1bu9)

![](Marc%20Assign.PNG)

This is an Assignment from FutureGames MobileworkShop Course, 

OVERVIEW

This Unity-based Inventory App is designed as a mobile-friendly application for managing a simple item inventory system.

---Features---
Health Potions

Players can obtain Health Potions by clicking a designated button.
The count of available Health Potions is displayed on the UI.
Players can use or "drink" Health Potions through another UI button, reducing the amount of available potions.

---Cooldown Mechanism---
There's a 20-second cooldown timer for obtaining new Health Potions.
The timer countdown is displayed, giving players visual feedback on when they can next obtain a Health Potion.

---Serialization---
The application saves the number of Health Potions and the cooldown timer.
This data is loaded back when the app restarts, making sure players cannot bypass the timer by restarting the app.

---Technical Details---
The app is built on Unity with C# scripting.
The UI is designed using TextMesh Pro for better text rendering.
Data persistence is achieved through Unity's PlayerPrefs.
