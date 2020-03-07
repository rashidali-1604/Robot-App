# Robot-App
A console application in .net core to move robot using commands in text file.
It contains zero to many (in this case 3) journeys. Here's the first one:

1 1 E
RFRFRFRF
1 1 E

Each one starts with the initial coordinates of the robot (1,1) and the direction it is pointing in (E). The directions are as follows:

N = North
E = East
S = South
W = West

Following the starting conditions are a list of commands:

RFRFRFRF

Each character is a command, either to turn (L = left, R = right) or to move forwards (F).

Finally the journey ends with another set of coordinates and a direction. This is the expected position and orientation of your robot at the end of the journey. 
Your program should check that it ends at the specified coordinates and facing in the given direction.

The challenge is to parse the input file, set the start position of your robot, then have it execute the instructions and check its final postion with the expected position.

- If the final position and expected position match then output "SUCCESS" followed by the coordinates and direction, for example: "SUCCESS 1 1 E"

- If the final position and expected position do not match then output "FAILURE" followed by the actual final coordinates and direction, for example: "FAILURE 1 1 E"

It should take the filename as an argument i.e. RobotApp.exe Sample.txt. It should handle invalid inputs gracefully.

Sample2.txt starts with a number of lines of the form "O 1 2" these denote obstacles at specific coordinates. 
Obstacles are declared at the top of the file before any journeys, any obstacles declared elsewhere in the file should be ignored.

Adjust your program so that any journey in a file with obstacles checks at each step that it has not collided with the obstacle. 
If it does then the output should be "CRASHED" followed by the coordinates, for example "CRASHED 1 1"

Write your code as though it was for a real project: make it maintainable, readable and clean. 
You may write unit tests and use a test framework of your choosing. 
You may use any of the LanguageExt nuget packages if you want although this is not mandatory.
Please do not use any other nuget packages.
