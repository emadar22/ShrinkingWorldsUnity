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
Phase 1
 

Player Controlled By Following Factors: Rigidbody, Colliders, PlayerController, FauxGravityBody(That Uses The FauxGravityAtractor Methods).
 (PlayerController)  Player Control Mechanism Based On Smoothly Rotating And  The Player Car    According To Input.
Factors: 
  1.Speed And Movement =>   Forward Movement With A constant Speed In Fixed   Update.
2. Rotation (Left And Right) => Getting The Horizontal Input Axis From Keyboard Values We Smoothly Slerp The Car Rotational Values To Left Or Right.

 






FauxGravityAttractor:
  It Actually Keeps The Player Car In The  Exact Gravitational Pull By The Sphere /Planet  
Mechanism: Calculate The Rotation Factors Which Should Bend The Rotation Of Player Car Towards Center of Planet 


ShrinkPlanet: Decreases The Size Of Planet  In Update Methods Continuously (Needed to Modify/ Limitize The Shrinkage Factors)






