ECE 264 Final Project 

Get Data Implementation 

•	GetSection1()
-	Reads in all room numbers and their corresponding long description.

•	GetSection2()
-	Reads in all short descriptions of each room.

•	GetSection3()
-	Reads in some, not all, of the adventure exits of each room.

•	GetSection4()
-	Reads in adventure vocab to be stored in a list.
-	Also, this section holds all the verbs to be implemented.

•	GetSection5()
-	Reads in adventure items and keeps track of their state descriptions.

•	GetSection6()
-	Reads in adventure messages to be stored in a dictionary.

•	GetSection7()
-	This section reads in object locations. 

•	SkipSection()
-	Used in order to skip section 8 to proceed with our progress. 

•	GetSection9()
-	Deals with room flags.

Implemented Verbs

•	GET ALL
-	Allows the player to retrieve all the objects in a room with a single statement.

•	NON-VOCAB
-	If a word is not recognized after a verb statement such as “Get Cow” it will return “Can’t Find Cow”
-	Or if a verb statement is used that is unrecognized it will return “Can’t Find that word”

•	GET
-	Allows the user to get an object in the room.

•	DROP
-	Allows the user to drop any object in the room they are in.

•	TALK
-	Whatever the user types after this statement the game will echo it. 

•	UNLOCK
-	Implemented in order to be able to unlock the grate with the keys. 

•	LOCK
-	Implemented in order to lock the grate with the keys. 

•	LIGHT
-	Used in order to light up any pitch black room with the lamp to see the objects in that room.

•	EXTINGUISH
-	Player can turn off the lamp with this Verb.

•	WAVE
-	Implemented for the Fissure room. Wave the rod and the bridge will appear. Wave it again and it will vanish. Bridge wont appear if player does not have rod when they wave. 

•	POUR
-	Player can pour water our of the glass bottle. 

•	EAT 
-	Player can eat the food the get in any room. 

•	DRINK
-	Player can drink from the bottle or the stream. If the bottle is empty, the game will not allow the player to drink from it. 

•	QUIT
-	Quit function in order to leave the game at any point.

•	FIND
-	The game will not give you any further information.

•	INVENTORY
-	Used to view inventory anywhere in the game. It will display all objects the player is currently holding.

•	FILL
-	The player can fill the bottle with the stream. If player does not have the bottle, the game will not let them fill it. 

•	THROW
-	The player can throw the bird at the snake to scare it off. 

•	CURSE WORDS
-	If a select few curse words are used the game will yell at the player. 


Movement

•	Checks to see if player is holding item (100<M<200) and if the player is in the room/has item (200<M<300).

-	If player doesn’t have the necessary item it will print (“You do not have the necessary item”).

•	Most of the movement works except for 300<M<500. Also, all of the special movements do not work either. 

•	Unable to cross bridge at the fissure due to movement table issues.
- Would be able to cross if the group was able to correctly implement movement table.

•	Added: XYZZY, which allows you to jump to room 11 for fast travel.

•	Added: Y2, Which allows the player to jump to room 33. 

Classes

•	Section_1_Descr.cs

•	Section_3_Exit.cs

•	Section_4_Vocab.cs

•	Section_5_Item.cs

•	Section_Actor.cs

•	Section_Container.cs

Problems We Ran Into

The main problem our group had during this project was figuring out how to implement the movement table.
It took us a while to get past the pit.
Then, with a little trial and error we were able to eventually go down the pit and scare the snake away. 
If we were able to figure out the movement table in time we would have been able to implement many more words and actions. 
