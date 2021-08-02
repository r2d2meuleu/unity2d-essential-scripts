<p align="center"><img src="demo/title.png"></p>

## <center> <b> Inside the project you can find various plug-and-play scripts, </center>

## <center> <b> meaning you just have to drop them on your gameObject to make them work.</center>

<br>

### As of for now, in this project you can find scripts for:

<br>
<details>
<summary>Movement 🦶</summary><br>

<details>
<summary>Topdown Movement</summary>

![dialogue](demo/topdownmov.gif)

</details>
<details>
<summary>Platform Movement with jump (and double jump)</summary>

![dialogue](demo/platmov.gif)

</details>
<details>
<summary>Drag and Shoot Movement</summary>

![dialogue](demo/linerendmov.gif)

</details>
<details>
<summary>Grid based Movement</summary>

![dialogue](demo/gridmov.gif)

</details>
<details>
<summary>Flappy Bird like movement</summary>

![dialogue](demo/flapmov.gif)

</details>
</details>

<br>

<details>
<summary>Dialogues 💬</summary>

    - TypeWriter Effect for text;
    - Multiple choice based dialogue;
    - Conversation between multiple characters;
    - Scriptable object used to easily create dialogues.

![dialogue](demo/dialogue.gif)
![multiple-choice-dialogue](demo/multiple-choice-dialogue-demo.gif)

</details>

<br>

<details>
<summary>Health system 💖</summary>

<details open>
<summary>Zelda like health system</summary>

    - Full/Empty hearths;
    - Dev can decide total amount of hearths;
    - PlayerPref ready.

![health](demo/health.gif)

</details>
<details open>
<summary>Health slider system</summary>

    - Fully customizable slider;
    - Dev can decide total amount of HPs;
    - PlayerPref ready.

![health](demo/HPslider.gif)

</details>
</details>

<br>

<details>
<summary>Quest System ❕</summary>

<details open>
<summary>Quest Manager</summary>

    - Create new quests;
    - Check quests completion.

</details>
<details open>
<summary>Quest Marker</summary>

    - Mark quests a completed via OnTriggerEnter or by pressing a given KeyCode inside its area.

</details>
<details open>
<summary>Quest Object Activator</summary>

    - Activate/Deactivate a given object upon quest completion;
    - Could also implement UnityEvents.

</details>

![quest](demo/quest.gif)

</details>

<br>

<details>
<summary>Platform Spawner ⬜</summary>

    - Spawn a gameObject and move it from point A to B;
    - Useful for games like Flappy Bird or Endless Runners.

![platforms](demo/movinplatfms.gif)

</details>

<br>

<details>
<summary>Audio Managment 🔉</summary>

<details open>
<summary>Audio Slider</summary>

    - Dedicated custom sliders and scripts to manage audio runtimes;
    - Save audio volume inside a PlayerPrefab that will save and use the value on start.

</details>
<details open>
<summary>Audio Toggle</summary>

    - Mute audio of a selected group of sliders;
    - Value is saved in a prefab and will be set as such on start;
    - Customizable KeyCode to quickly mute/unmute audio. 

</details>

![audio](demo/audio.gif)

</details>

<br>

<details>
<summary>Enemy Spawners 🧛‍♂️</summary>

    - Spawn a random object from an array of gameObjects
    - Select a Min/Max numbers of enemies to spawn per callback
    - Select how many enemies can be active at the same time

<details open>
<summary>Spawn gameObjects inside Tilemap</summary>

![spawner](demo/spawnInTilemap.gif)

</details>
<details open>
<summary>Spawn gameObjects inside Area</summary>

![spawner](demo/spawnInArea.gif)

</details>
</details>

<br>

<details>
<summary>Animator Overrider 🦎</summary>

    - Override the animator to change on object appearance runtime
    - Can call the function via scripts and on button click as in the example below
    - Add as many Animator Overriders as you wish and change between them via simple Functions
    - Sample scene provided

![override](demo/animatorOverride.gif)

</details>

<br>

There's more i'm planning to add to the repository, i'll work on it for as much as i have time.<br>
At the moment there are 27 scripts.

<br>

<details>
<summary>Credits 👑</summary>

- This project uses [@PixeyeHQ](https://github.com/PixeyeHQ/InspectorFoldoutGroup) inspector foldout group to make the development cleaner;

- The hearths sprites used in the zelda like hearth system were taken from [NicoleMarieT](https://nicolemariet.itch.io/pixel-heart-animation-32x32-16x16-freebie) on itch.io;

- The font used is taken from [Void](https://arcade.itch.io/heartbit) on itch.io;

- Tilemap asset taken from [Adam Saltman](https://adamatomic.itch.io/jawbreaker) on itch.io;

- Enemy sprite taken from [0x72](https://0x72.itch.io/dungeontileset-ii) on itch.io;

- Button UIs comes from [Sumo Studio](https://sumo-studios.itch.io/pixel-art-buttons);

- Tiny Heroes come from [Free Game Assets](https://free-game-assets.itch.io/free-tiny-hero-sprites-pixel-art);

- Anime background taken from [NoranekoGames](https://noranekogames.itch.io/yumebackground);

- Anime characters from [Sutemo](https://sutemo.itch.io/female-character) customized thanks to [Exuin](https://emily2.itch.io/sutemo) character creator.
</details>
