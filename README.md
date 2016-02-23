# Air Traffic Control

This application was built as a tool for a study of visual contrast upon human performance on Air Traffic Control based tasks. The app is basically a test to see how well the participants react to certain tasks with different visual constrasts ( black / white predominant ).

### Geek stuff I used:
  * [Unity3D](https://unity3d.com/) - Windows desktop app build
  * [NGUI](https://www.assetstore.unity3d.com/en/#!/content/2413)
  * [iTween](http://itween.pixelplacement.com/index.php)
  * [Parse](https://github.com/ParsePlatform/parse-server)

Target = airplane &
Waypoint = airport

### Tasks:
  * Instruct target to: Climb, Maintain & Descend
  * Direct target to waypoint X
  * Click on target
  * Target - Target conflict
  * Target - Border conflict
 

### Program Flow:
**First 5 minutes (300 seconds):**
The program begins with n=3 targets. Every 30 seconds add another target on the screen. First 
task comes up after 5 seconds. Time in between tasks is 15 seconds. Tasks are randomly 
selected. If after 10 seconds the task is not resolved it becomes a mistake. One conflict will 
appear after 150 seconds. Conflicts have priority (from the moment they appear tasks 
measurement pauses). Conflicts last on the screen for 5 seconds. Hand in/Hand off (aircraft at 
the border) have second priority and last for 5 seconds.

**Minutes 5 to 10 (300 – 600 seconds):**
On the screen there will be between 10 and 13 targets. Every 30 seconds another target is 
added. Time in between tasks is 10 seconds. If after 10 seconds the task is not resolved it 
becomes a mistake. Maximum number of targets on screen is 20. Tasks are randomly selected. 
A number of 3 conflicts will appear during this period of time: the first after 350 seconds, the 
second after 470 seconds and the last after 550 seconds. Conflicts have priority (from the 
moment they appear tasks measurement pauses). Conflicts last on the screen for 5 seconds. 
Hand in/Hand off (aircraft at the border) have second priority and last for 5 seconds.

**Last 5 minutes (600 – 900 seconds):**
On screen targets between 17 and 20. Time in between tasks is 10 seconds. If after 10 seconds 
the task is not resolved it becomes a mistake. Tasks are randomly selected. A number of 3 
conflicts will appear during this period of time: the first after 650 seconds, the second after 700 
seconds and the last after 850 seconds. Conflicts have priority (from the moment they appear 
tasks measurement pauses). Conflicts last on the screen for 5 seconds. Hand in/Hand off 
(aircraft at the border) have second priority and last for 5 seconds.

![alt text](http://i.imgur.com/kQOT16e.png "White Predominant test")

---
My thoughts on my first freelance project?
```sh
Debug.LogError("Please end my suffering");
```

