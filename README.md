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

Car store :

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/5455e93c-f0a0-4503-a179-057bdab89f96


GamePlay :

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/aed179be-37fb-4a1a-8c06-88609924ae96


 ## Phase 2 hours distribution :
 

1) Studing and Understand how UI works in unity
Image, text, anchor points, scale, types on canvas 

Setting up main menu, hud and results screen

5 hrs


2) How to save data in unity permenently 
json file and prefebs 

used this knowledge to save highscore and in Game Currency in the project
5 hrs


pattern to program shop 
made shop where i can unlock cars using in game currency and can buy and select them

15 hrs

AI setup in unity
Navmesh baking and Navmesh Agent to find the shortest parth
math and physics involved behind NPC players

15 hrs

VFX and Audio Manager In Unity
5 hrs

How Scenes work in unity 
used to make seperate menu screen from gameplay scene
5 hrs

# phase 3 part-1 

## phase 3 part-1 missions
1) shrinking of planet visual
2) camera setting 
3) shape seleection screen
4) based on shape selection set planet shape accordingly
5) updating controls of car and AI so they can set there movment on each shape either its cube or pentagon

## Phase 3 part-1 

Phase 3-1: Adding Multiple Planets Modes

1)Cubical Planet
2)Dodecagon
Working Mechanism: Both planets follow the same mechanism as the globe.
Planets require the major two components for their shrinking and gravitational pull effect.

<img width="410" alt="Screenshot_27" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/962d070e-7557-4b1f-b11d-a37002994c47">


In the shrink planet, FixedUpdate is responsible for shrinking (we just need to scale down the planet for the shrinking effect).


<img width="403" alt="Screenshot_28" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/5ccce06e-e6c9-4897-98bd-f1b872800c07">


Gravity Attracter is responsible for the attraction force and moving rotation towards the planet


<img width="405" alt="Screenshot_29" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/5893e700-bc1e-4a9b-b454-3038f83932cf">



Improving the  size calculation Of Planets 


<img width="413" alt="Screenshot_30" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/8b790130-9223-4bfa-8d51-f192e3c6a611">

Runtime update Of planet size handled by shrink planet in The fixed update

<img width="408" alt="Screenshot_31" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/243a5356-91d8-4004-9069-8d1f3010c4ce">


## phase 3 part-1 results
Earth shrinking

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/a55373d1-59a7-4e61-abb7-35a281860ece
 
Dodecagon

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/347ed7c1-7852-4a76-adf8-c1ab3e070199

Cube

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/06e8cd07-ca3b-48fe-b9dc-876b8c788812


# Phase 3 Part-2

## Phase 3 missions:

Adding Multiple Dice Shapes For Player Running On Planet;
1. 12 Sided Dice
2. Cubical Dice
3. 10 Sided Dice
4. 8 Sided Dice
     All Above Dice Shapes Has Been Adjusted With Repeated Prefabs And Different Coins Patterns. It Took Around 4 - 5 Hours To Make Their Ready Usable Prefabs.

<img width="289" alt="Screenshot_17" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/3f272d87-4069-4fe5-b884-4a5a53c1001c">

Planets Activation Process:
When game starts, the planet selected from the main menu is activated initially. Then, when the bar is filled and the "Planet Jump" button is pressed, the following process occurs:
There is a list of game objects on the GameManager, and we activate the required planet with a specific number that comes from the PlayerPrefs Manager.
"SelectPlanetNum" adds one number for every bar filling process. So, with the progress of the game, the "SelectPlanetNum" increases, and the next shapes become active one after another.

<img width="375" alt="Screenshot_18" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/7de867e4-49e0-4ade-ab91-43d471b862a2">

<img width="415" alt="Screenshot_19" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/10757af7-1d4e-4714-9880-c3cb0d63928f">

Bar filling mechanism:
The bar fills up (very smoothly) every time when the player enters the coin collider. After the calculated amount of coins collected (5 coins for one-time bar filling), we proceed to the next planet shifting and transformation process. The script on the camera can only follow perfectly one central planet; otherwise, changing the position for the planet causes problems in camera following.

Detection in the PlayerController and calling the "UpdateBarFilling" method.


<img width="412" alt="Screenshot_20" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/28043ab3-1dde-40a8-81db-2a6339cf68ab">

How is the bar filled?
Using a coroutine, we smoothly lerp (using Mathf.Lerp) the fill image (bar) values. When it reaches the maximum value, we spawn a new planet. It took around two hours to implement the bar filling mechanism.

Calculations:
Maximum Value = 10;
Every time the function is called, += 0.2
So, in 5 times coin collection => 0.2 * 5 = 1;


<img width="408" alt="Screenshot_21" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/ad830c27-b33b-4767-bdb5-0b268c46e9fc">


Planet Shifting and Transformation Process:

Planet Spawn:
When the bar fills up to maximum capacity, a planet is instantiated next to the player with a margin of 15 distance in the x-direction.


<img width="399" alt="Screenshot_22" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/a0278236-6f3d-4379-919d-f8068ca36c30">

Planet Transformation Process:
Using a coroutine, we perform the following operations:

1-Temporarily deactivating the player components to avoid controller interference.
2-Applying smoke particles effect on pre and post-transformation phases.
3-Activating the aeroplane and deactivating the player's body.
4-Implementing smooth projectile movement from one planet to another planet.

<img width="409" alt="Screenshot_23" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/7e9ad29d-c4ca-424b-86d4-d433c86c6f37">


Aeroplane Movement:
Central Point Calculation.
The aeroplane will fly in a projectile motion style for better visual effects. Initially, we calculate the central point between two planets, and we determine a Vector3 point right above the central point.

Movement in calculated distance and time frames: 

<img width="407" alt="Screenshot_24" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/8ae8bc32-5056-44ac-8923-2058780565b6">

Movement:    Initial Position=> Central Point => Target Point
It took along 4-5 Hours for handling the transformation process.


Camera Following Aeroplane Controllers:
Two to three approaches have been tried for camera following the plane:

1) Using the camera controller that follows the player. The camera follows the target in both positional and rotational factors.



<img width="395" alt="Screenshot_25" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/3efe22b4-8007-4a4c-bc71-d1345b4b7d81">

Problems Faced: The camera follow script works efficiently when the target is in a central position (new Vector3), but when there is a margin in position transformation, it can't focus on the player, which looks unpleasant.

2) To overcome the camera following problems, I tried another script that somewhat works like the previous controller.
   
  <img width="406" alt="Screenshot_26" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/c14ba18f-70e9-409c-9640-698d6c78e027">


Problems Faced: This camera controller does not properly follow at different rotations and passes through colliders, which also looks unpleasant.

3)Making the camera a child of the aeroplane:
This plan also fails because the game manager's system only allows no camera in the child of the player object.


Note: Each Process For Camera Transition Took Around 4 Hours 

## Phase 3 Pending Tasks:
Still need time to use other approaches like:

1)Moving player and camera on the waypoints.

2)reating an animation for the best camera and player movement that includes jumping over the next planet.

3)Need some time to tackle this issue: Camera following the aeroplane.

## Phase 3 part2 results :


Run 1:

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/30378c91-57b6-475d-878f-9130cdc32fea

Run 2:

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/623d8dae-b382-4b68-b34f-425533bf60f0

# Phase 4 Planning and progress 

## Previous tasks 
In the previus scenario we are generating gravitational pull towards the center point of the 3D models even if the models shapes vary and are irregular this approach works. Then using raycast we set a model of the car to the box that is in contact with the surface under influence of the gravitational pull.

figure :

<img width="528" alt="Screenshot_32" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/f9d0efc5-932f-4c71-92fa-4a30828af87a">

## Current task 

In the torus shape 3D model we can not set the center point of the shape and center of gravity cause our car will need to move on the surface of the donut hence to achieve this I will use the following points :
- Dividing torus model into 7 pieces like shown in diagram
- Each model will have its own center point which are small green circles
- Box shape model as shown in diagram will act as gameobject that will act as center of gravity for the car
- This box will smoothly lerp towards the center point of the torus model piece on which car is present 
- As car shift from one piece to another the box will smoothly lerp towards the center point of next shape this will keep the car linked to the surface while it 
  translates across the torus.
- Lerp will help in smoothly transfer of gravity point from one object to another without giving jerky effect
- I am using trigger in between pieces to note which next donut piece our car is entering




<img width="563" alt="Screenshot_33" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/7a0b0bfc-20ef-414e-bc6e-cc1991754eca">


## Working mechanism 
 
The torus is divided into six shapes. Each part is connected to the next shape so it feels no distance between shapes and looks like a torus.

<img width="372" alt="Screenshot_34" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/7bd79de2-12b1-4304-aef6-c7b66a7c0b31">


1)There is a capsule that has a FauxGravityAttractor script on it that works in dealing with gravity effect, and on player moving from one part of the torus to another part, the capsule just lerps up to the centre of the next part to create gravity effect on the current part.


<img width="402" alt="Screenshot_35" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/450027be-c694-4a39-8fcd-65828eadef61">


The gravity body contains a FauxGravityAttractor component on it, which handles the gravity attract mechanism with specific attraction levels.

The update methods in the player script call the method from FauxGravityAttractor script as follows:

<img width="398" alt="Screenshot_36" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/70baff6f-aa85-4e96-b55c-52db6d1e7abd">

The values for gravity variables are set to 15 because it requires more attraction than other planets.

2) Each part of the torus has two colliders, front and back, which have references to the next or previous body colliders so we can activate next body colliders by script and lerp the capsule for gravity effect.

<img width="313" alt="Screenshot_37" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/df536f42-aabd-420b-b119-cfacc7971192">

Each shape has its own script, ShapeShiftTrigger, which handles the trigger events.

<img width="395" alt="Screenshot_38" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/bd312520-e204-49c5-a268-55621d7e25a9">

Event callbacks in ActionOnEnter and ActionOnExit are from GameManager.

3) The main capsule, which has the FauxGravityAttractor, handles overall colliders and FauxGravityAttractor body references for lerp. How the capsule lerps: from initial to final position and then becomes a child of the current part/patch of the torus.
   

<img width="404" alt="Screenshot_39" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/b0a4802f-e8c2-4506-abbb-d5d748113e39">

Lerp from the current patch of the torus to another by detecting the shape-shifting trigger with their public references.

4)Adding coins and meteors. Coins are easily placeable, but meteors require more gravity effect for proper collision. In this stage, fewer meteors are falling to avoid collisions with meteors. AI cars are also reduced to avoid collision with the player, specifically for this shape.

<img width="378" alt="Screenshot_40" src="https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/0d703d7c-7e53-43ce-924a-ee00b0fed157">

 5) Controller smoothing, setting the car above the surface always, collider settings, etc.
   
 6) Jump from one planet to another planet mechanism works on previous structure.


## Hours distribution phase 4 :

- R&D/Brainstorming for how we actually control player movements in Torus: 2 hrs
- Setting the Torus colliders, adding scripts to triggers: 3 hrs
- Player cam control, lerping from patch to another patch, and writing generic code: 6 hrs
- Merging into game flow with stages and jump to the next planet: 3 hrs
- Adding into main menu + polishing the game: 4 hrs

## Results Phase 4 :

https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/0db17672-2c15-42dd-950b-ac70787fee45





https://github.com/emadar22/ShrinkingWorldsUnity/assets/82322531/a13462ae-6eb2-4dea-a30b-9f8478043e36







