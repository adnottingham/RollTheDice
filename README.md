# RollTheDice  v0.6

This Visual Studio Project replicates the board Game "Roll For It".

Four players take turns rolling their 6 dice, trying to match their dice to the three cards.  If they are the first player to match the card with their dice, they get all the points for that card.  The other players can no longer attempt to get that card and a new card is displayed.   Players can "freeze" any of their dice at the end of the turn, but they must designate which card they are frozen to.   At the start of the next turn they may unfreeze any dice and roll them again.   If another player claims a card, all other players are returned their dice that were frozen on that card.   Frozen dice may not be moved to another card without rolling them first.  First player to 40 points wins.   

This is still an early edition with several bugs, but can be played fully.   


Bugs:
    Dice can sometimes be frozen before they are rolled at the start of a turn.   
    Some dice do not appear at the start of a turn, before they are rolled.
    Dice may overlap each other at times.
    Game "continues" even after a player wins.
    
    
Additional Work Needed:
    Clean up code, especially Computer players logic.
    Display better Win Game screen
    Include different skill level/strategies for the computer players
    Better animation for the rolling of the dice
    Slow down the computer player moves
