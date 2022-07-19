# Bowling Ball Scoring:

Following Design Patterns are in use:

* Factory Design Pattern
* Strategy Design Pattern
* Singleton Design Pattern
* Template Design Pattern

Code modules follow all the SOLID Principles as per my knowledge:

	S : Single Responsibility
	O : Open for extension and close to modification
	L : Liskov Substitution
	I : Interface Segregation
	D : Dependency Inversion

## Problem Statement:

Create a program, which, given a valid sequence of rolls for one line of American Ten-Pin Bowling, produces
the total score for the game. Here are some things that the program does not need to do:
* Does not need to check for valid rolls.
* Does not need to check for correct number of rolls and frames.
* Does not need to not provide scores for intermediate frames.

## Requirements:

How are bowling games scored?

The game consists of 10 frames as shown above. In each frame the player has two opportunities to knock
down 10 pins. The score for the frame is the total number of pins knocked down, plus bonuses for strikes and
spares.

A spare is when the player knocks down all 10 pins in two tries. The bonus for that frame is the number of pins
knocked down by the next roll. So in frame 3 above, the score is 10 (the total number knocked down) plus a
bonus of 5 (the number of pins knocked down on the next roll.)

A strike is when the player knocks down all 10 pins on his first try. The bonus for that frame is the value of the
next two balls rolled.

In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame.
However no more than three balls can be rolled in tenth frame.
 

## Evaluation criteria:

* Design and object modelling
* Solution structure
* Test cases
* Overall solution approach
* Readability and maintainability of code

The solution should assume valid inputs at all times and does not need to include unnecessary validations
trying to prevent bad input data.
	