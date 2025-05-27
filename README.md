# Distance Custom Death Messages

With this mod you can make your own custom death messages.

Do note that you'll have to edit the json file yourself to add more messages. When you first open the game with this mod it will generate a json file that looks like this:
```
{
	"KillGrid" : [
		"The laser grid was not cool with {0}",
		"{0} have touched the forbiden grid"
	],
	"SelfTermination" : [
		"{0} pressed the reset button",
		"{0} commited sudoku"
	],
	"LaserOverheated" : [
		"{0} don't know how to drive without wheels",
		"{0} was too hot"
	],
	"Impact" : [
		"{0} kissed a wall",
		"The ground facepalmed {0}"
	],
	"Overheated" : [
		"{0} needs to stop boosting sometimes"
	],
	"AntiTunnelSquish" : [
		"{0} got unitied"
	],
	"StuntCollect" : [
		"{0} looted a x{1} multiplier!"
	],
	"KickNoLevel" : [
		"{0} is too poor to have this level",
		"[FF0000]{0} is sad because he can't load the level[-]"
	],
	"Finished" : [
		"[FFFFFF]{0}[-] [00FF00]f[-][00FFFF]i[-][0000FF]n[-][FF00FF]i[-][FF0000]s[-][FFFF00]h[-][00FF00]e[-][00FFFF]d[-]"
	],
	"NotReady" : [
		"{0} is a little busy, try agains later"
	],
	"Spectate" : [
		"[-]This map is too hard, {0} gave up"
	],
	"TagPointsLead" : [
		"[FFFFFF]{0}[-] is [00FF00]f[-][00FFFF]a[-][0000FF]b[-][FF00FF]u[-][FF0000]l[-][FFFF00]o[-][00FF00]u[-][00FFFF]s[-]!"
	]
}
```

If you want to add your own, make sure to follow the format.
For example, if you want to add a custom messages for when you get killed by a KillGrid you would make an edit like this:
```
	"KillGrid" : [
		"The laser grid was not cool with {0}",
		"{0} have touched the forbiden grid",
		"My custom message!",
		"My other custom message!"
	],
```
The last message in between the square brackets should never have a comma after the quotation mark.

{0} = Your formatted username <br>
{1} = Your stunt multiplier <br>
{2} = Your username (no formatting)

To give a message color use hex values with this formatting:
```
	[FF00FF]Your message here[-]
```