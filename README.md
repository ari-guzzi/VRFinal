# VRFinal

# Final Project Proposal: XR Arcade

*The Red Queen's Reflection Labyrinth*

*Ari Guzzi*

## Project Description

A Queen of Hearts from Alice in Wonderland-themed maze puzzle. I  want to use components of my VR Interaction project to solve the puzzles. For instance, I use my rotating block function to align something that clears a path or picks up an object, rotate it, and place it to get through. Stretch goal: I want some enemy: maybe a section where if you hit tripwires, you get shot by arrows, so you must navigate through, or maybe have a section where you fight the queen's guards.

## Feature Breakdown

1. **Lasers**: To open doors, the player must rotate mirrors and bounce a laser off them to hit the designated spot.<br>
    - **Estimated Challenge - 2:** I am unsure how to create the laser that bounces off mirrors, and getting the reflections will be hard. Peter Note: Have each object be a laser receiver and emitter and have a disconnecting system<br>
2. **Mirrors**: A mirror that can be rotated and has lasers bounce off it. Ideally, it's reflective - Peter Note: real mirrors have a huge performance cost to add another camera - Google "Unity very reflective material"<br>
    - **Estimated Challenge—3:** I think getting the reflections will be challenging, but rotating will be easy.<br>
3. **Have Moving System**: Allow the player to move around with a joystick. <br>
    - **Estimated Challenge—1:** I bet it'll be easy to implement based on what friends who have done it said.<br>
4. **Have jumping**: Allow character to hop around<br>
    - **Estimated Challenge—3:** I think getting the reflections will be hard, but rotating will be easy.<br>
5. **Pick up the block, rotate it, and place it**: Have the player place a block on something to do some puzzle. Peter note: give block wings to avoid having to do physics<br>
    - **Estimated Challenge—3:** Picking up and rotating it will be relatively easy. I have most of the code already, I need to fix the picking up part a little. I think having something happen if the block is placed and rotated perfectly will be difficult. Peter note: give block wings to avoid having to do physics.<br>
**Stretch Goals**<br>
6. **Trip Wires**: There is a tripwire; if I hit it, an arrow shoots at me<br>
    - **Estimated Challenge - 2:** The collision with a laser triggering something else will be easy. I also think having something shot at me will be easy because we've already done it.<br>
7. **Guards**: Having characters run at me, and when they hit me, I get hurt<br>
    - **Estimated Challenge - 1:** We did this already, so it will be easy. The hard part will be making them look like they're running. I am not sure how I want to fight them yet; maybe I can incorporate them with my tripwire arrows<br>


## Milestones

1. **By 11/19** - Implement movement, jumping, set up area, and attempt mirror/laser system
2. **By 12/5** - Finish mirror/laser system, implement pick-up block, rotate it, and place it to solve a puzzle
3. **By 12/14** - Finished

## Inspirations

List at least 2 inspirations/influences on your project. Provide links, please!
- Portal / Portal 2 - https://www.thinkwithportals.com/
- The Witness - https://store.steampowered.com/app/210970/The_Witness/
- The Talos Principle - https://store.steampowered.com/app/257510/The_Talos_Principle/

## Sources
- Skybox: https://assetstore.unity.com/packages/2d/textures-materials/sky/surreal-skyboxes-254634
- Textures:
    - mirror border: https://www.textures.com/download/gilded-trim-0023/100101
    - bush: https://www.turbosquid.com/FullPreview/738235
    - grass: https://www.sketchuptextureclub.com/textures/nature-elements/vegetation/green-grass/clover-grass-texture-seamless-18207
    - wand: https://freepics.ai/photo/3399/intricate-patterns-of-natural-wood-grain
- Sounds:
    - Background Music: https://zakiro101.itch.io/free-casual-game-music-pack-vol-2
        - Tutorial: 4. The Cafe
        - During Game: 2. Party Tonight
    - Sound Effects: 
        - Mirror Moving: https://pixabay.com/sound-effects/metal-door-creaking-closing-47323/
        - Door Sliding: https://pixabay.com/sound-effects/sliding-sound-103631/
