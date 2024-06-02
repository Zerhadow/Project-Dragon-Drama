Naming is split into 4 parts
---------------------------------
1st Part:
"Script"
	- for the main story
"Quest"
	- for a Side-Quest
	- followed by name of side-quest
"Gossip"
	- for dialogue that contains gossip info
"NPC"
	- for NPC dialogue

2nd Part:
"W[]"
	- Defines which week it is in

3rd Part:
"D[]"
	- Defines which day of the week it is in
	- Usually filled in with 1-7 where 6(saturday), & 7(sunday)
	- 0 means can be initiated at any point chosen

4th Part:
"S[]"
	- Follows which scene the player is in
	- For side-quests will define which scene

Commands:
---------------------------------
"BEGIN"
	- Used to start a Branch or Dialogue Node list
	- Followed by "BRANCH" or "DNL"
"END"
	- Used to end a Branch or Dialogue Node List
	- Followed by "BRANCH" or "DNL"
"FLAG"
	- Checks if bool flag has been met then branches
	- Branches using bool T/F