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


Player controlled by following factors: Rigidbody, colliders, PlayerController, FauxGravityBody (that uses the FauxGravityAttractor methods).
(PlayerController) Player control mechanism based on smoothly rotating and the player car according to input.
Factors:

Speed and movement => forward movement with a constant speed in fixed update.
Rotation (left and right) => getting the horizontal input axis from keyboard values we smoothly slerp the car rotational values to left or right.

<img width="339" alt="Screenshot_2" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/d1ee2569-2aae-4f16-a674-f656eb01d924">

<img width="480" alt="Screenshot_3" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/2924582b-36b9-4bfa-86b1-712f1c8f6e0d">

FauxGravityAttractor:
It actually keeps the player car in the exact gravitational pull by the sphere/planet.
Mechanism: Calculate the rotation factors which should bend the rotation of player car towards center of planet.

<img width="460" alt="Screenshot_4" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/ae2de4ca-19c5-45af-bb47-7da4be5c85ec">

ShrinkPlanet: Decreases the size of planet in update methods continuously (needed to modify/limitize the shrinkage factors).

<img width="460" alt="Screenshot_5" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/ab00240c-6099-4a40-af9d-aaab05538708">

In Phase 1, we handle spawning meteors, collisions, and particle handling for the post effects.

MeteorSpawner: Spawns the meteors on runtime as prefabs on the random unit sphere values.

<img width="460" alt="Screenshot_13" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/1fc78a69-dc6c-4ac3-a194-43b5eacb26e6">

Meteor: Script on the meteor that handles the collision of the meteor on the contact points of the planet.

<img width="461" alt="Screenshot_14" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/01decd3e-ef26-4a67-a0c5-9efcf9ca0eae">

The meteor also contains the FauxGravityBody script as player that helps to keep molding the direction and rotation and movement towards the planet.

Crater: That handles the post collision effects of meteor colliding to the surface of the Earth and destroys the object.

<img width="459" alt="Screenshot_15" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/dce97674-c90e-4550-8637-9b5b147ecd34">

PlayerCollision: Handles the collision of the player car to meteor and the death phase.

<img width="337" alt="Screenshot_16" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/42fcd760-ac82-49f2-ac68-81b05661d2a8">

Thats a rough docomentaion Of game flow.




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

## Phase 2 :
Missions done in phase 2 :
-Result screen 
- coin collection
- Car selection system
- AI cars
- Main menu setup

## Scripts from phase 2:
AI cars:
Cars with AI controller move to random path on the planet. Components include Rigidbody for collision detection, AI controller for car axis and movement controls, Faux Gravity Body for gravitational effect. Level fails on collision with player.
<img width="208" alt="Screenshot_6" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/1a32965a-62dc-4296-9f4e-e7b77bd3ad58">

AI car control mechanism includes moving position and rotating by slerping the angular factors towards planet.


<img width="392" alt="Screenshot_7" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/92c1912b-1c75-4a89-bc2d-b15395cd9ddc">

The script on player for collision detection detects when it collides with AI.

<img width="397" alt="Screenshot_8" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/34ed2e54-d56c-4ffe-b1c5-4a084ec512e3">

Coins and Economy Management:
Coins on the planet, when triggered with player car, add coins value in the top coin bar that are stored for purchasing different player model vehicles. Detection:

<img width="378" alt="Screenshot_9" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/cf003211-f594-4694-a323-5f0a918fef81">

Sound Manager:
With generic functions, we just pass the name/string of audio clip that we want to play. We handle overall sounds and SFX flow.

<img width="390" alt="Screenshot_10" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/2a1962e1-aa51-4c53-94ba-25c8a948ac97">


Player Selection and UI Overall Gameplay:
Player selection includes player purchasing, selection, and spawning in the gameplay scene.
UI references with player prefabs and player prices are player controlling factors.

<img width="396" alt="Screenshot_11" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/e3128f29-3c63-44b9-a1ba-2ecb0068ceb3">


Left, right, spawning, buying, and selection of the player are handled by script by checking all factors. For example, if there is enough money, then we
can buy a car.

<img width="281" alt="Screenshot_12" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/a9535278-1df8-4ee2-b53f-8654df78348e">

.

## Phase 2 results :









