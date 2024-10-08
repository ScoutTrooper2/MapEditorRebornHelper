# Functions
At the moment, the plugin has only one function - adding doors to the game directly through the unity editor.

# Other
I was too lazy to come up with some fancy ideas for implementing compilation through Unity, so everything is done simply through names.
I use this to make buttons-doors instead of pickups, as SCPs can't click on pickups.

# Questions and Answers
Q: Why root_true / parent_true? 
A: Because if you change the parent door to something else, it will break

Q: Why is the event here?
A: Idk, it is good for me.

# Guide

How to use?
1. Place 2 scripts in unity
2. Add Component "DoorScript" to primitive
3. Change settings
4. Compile Door Name
5. Compile Schematic
6. Download Plugin and Install to server.

(Also you can use Preview to look how it be if primitive is Door)

# Very important:
If you change position of Schematic (like mp pos grab and other), Door dont change position.
