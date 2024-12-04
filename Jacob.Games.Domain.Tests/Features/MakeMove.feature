Feature: MakeMove

Background: 
    Given the following board
    """
    ┌────────────────────────┐
    │ .  .  .  .  .  .  .  . │
    │ p  p  p  p  p  p  p  p │
    │ .  .  .  .  .  .  .  . │
    │ .  .  .  .  .  .  .  . │
    │ .  .  .  .  .  .  .  . │
    │ .  .  .  .  .  .  .  . │
    │ P  P  P  P  P  P  P  P │
    │ .  .  .  .  .  .  .  . │
    └────────────────────────┘
    """

    Scenario: Move white pawn
        When '6,4' moves to '5,4'
        Then the board should look as follows
        """
        ┌────────────────────────┐
        │ .  .  .  .  .  .  .  . │
        │ p  p  p  p  p  p  p  p │
        │ .  .  .  .  .  .  .  . │
        │ .  .  .  .  .  .  .  . │
        │ .  .  .  .  .  .  .  . │
        │ .  .  .  .  P  .  .  . │
        │ P  P  P  P  .  P  P  P │
        │ .  .  .  .  .  .  .  . │
        └────────────────────────┘
        """

    Scenario: Move black pawn should succeed
        When '1,3' moves to '2,3'
        Then the board should look as follows
        """
        ┌────────────────────────┐
        │ .  .  .  .  .  .  .  . │
        │ p  p  p  .  p  p  p  p │
        │ .  .  .  p  .  .  .  . │
        │ .  .  .  .  .  .  .  . │
        │ .  .  .  .  .  .  .  . │
        │ .  .  .  .  .  .  .  . │
        │ P  P  P  P  P  P  P  P │
        │ .  .  .  .  .  .  .  . │
        └────────────────────────┘
        """

    Scenario: Moving a white pawn backwards should fail
        When '6,4' moves to '7,4'
        Then the board should not have changed

    Scenario: Moving a black pawn backwards should fail
        When '1,3' moves to '0,3'
        Then the board should not have changed