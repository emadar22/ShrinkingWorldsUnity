# Shrinking Worlds
 a thrilling 3D adventure game where you must navigate a shrinking planet under siege by relentless meteoroids. As the pilot of a high-speed space car, your mission is to survive for as long as possible while collecting valuable coins scattered across the planet's surface. a TSP game with WASD Controls.
 
 #<img width="590" alt="Screenshot_1" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/e8dc0472-3df2-4fd7-b7c3-c7761f52cf82">.

## Phase 1
Missions done in phase 1 :
- Earth Shrinking
- Player car controls
- Main menu to start and exit the game
- Meterior falling
- Player collide with meterior and destroy
## Scripts from phase 1

Player Controlled By Following Factors: Rigidbody, Colliders, PlayerController, FauxGravityBody(That Uses The FauxGravityAtractor Methods).
 (PlayerController)  Player Control Mechanism Based On Smoothly Rotating And  The Player Car    According To Input.
Factors: 
  1.Speed And Movement =>   Forward Movement With A constant Speed In Fixed   Update.
2. Rotation (Left And Right) => Getting The Horizontal Input Axis From Keyboard Values We Smoothly Slerp The Car Rotational Values To Left Or Right.

<img width="339" alt="Screenshot_2" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/d1ee2569-2aae-4f16-a674-f656eb01d924">

<img width="480" alt="Screenshot_3" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/2924582b-36b9-4bfa-86b1-712f1c8f6e0d">

FauxGravityAttractor:
  It Actually Keeps The Player Car In The  Exact Gravitational Pull By The Sphere /Planet  
Mechanism: Calculate The Rotation Factors Which Should Bend The Rotation Of Player Car Towards Center of Planet 

<img width="460" alt="Screenshot_4" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/ae2de4ca-19c5-45af-bb47-7da4be5c85ec">

ShrinkPlanet: Decreases The Size Of Planet  In Update Methods Continuously (Needed to Modify/ Limitize The Shrinkage Factors)

<img width="460" alt="Screenshot_5" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/ab00240c-6099-4a40-af9d-aaab05538708">

## Phase 1 Results 

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/88f189bb-9937-4ddd-9c5f-b03bdc20b8dc




https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/5b50a7a7-08aa-4e18-96e8-a4df68755fb9



## Phase 1 Hours Distribution 



PHASE 1

Learned about unity basic
Interface
Physics
Collision
Camera
Light
Animation

15 hrs

Learned about C# Programming in unity

Special Functions 
start, update, fixed update,on enable, awake

15 hrs

World Shrink 
Math behind reducing earth radius and diameter

5hrs

how input works in unity and in which function we need to call the commands

5hrs

can controls, car physics and collision setup
how texture works in unity

10hrs


