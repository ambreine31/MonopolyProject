MonopolyProject

# MONOPOLY 
## Implementing the iterator, singleton and decorator design patterns

### Game functionalities 
#### The Gameboard
After testing a few different options, I decided the most practical way of displaying the gamebard would be to lay out the entire circuit horizontally. 

![gameboard2](https://user-images.githubusercontent.com/58735251/70862655-42a91780-1f3f-11ea-92cd-f32da26c6bbd.png)

This made it easy to display such things as the letters A and B of the players moving along the board, or mark which properties they own.
#### The Properties
The property class is defined by the following attributes:
```c#
        private int box_num;
        private string name;
        private double propertyprice;
        private double totalprice;
        private Player owner;
```
I based the property locations, names and price on the following monopoly board:

![monopoly](https://user-images.githubusercontent.com/58735251/70861266-dffa5080-1f2b-11ea-915c-fb54bacba80c.PNG)

The total price was added as an attribute because the overall value of the property increases when the player adds houses or hotels to the property. The total sum of all of these costs is then used to calculate the higher tax price for an opposing player that lands on this property.
The Owner attribute corresponds to the Player that owns said property.

#### The Players
The players initialized at the start of the game are all contained in a Player Collection, with which we iterate through all of the players for each round of the game. 
A Player has the following attributes:

```c#
        private int position;
        private string token;
        private double money;
        private bool injail;
        private int time;
```
At each point in the game we have his current position on the board, the letter (A,B,C,D) corresponding to his token, the amount of money he has, his jail status (in or out), and a time counter that allows him to be released from jail after three rounds.

This class contains most of the gameplay functions:
```c#
        RollDiceAndMove(Random generator)
```
This function generates the dice numbers and uses the sum of the dice to move the player position forward.
It also calls specific instructions for some boxes on the gameboard. For example, 30 is *Go to Jail* and some boxes indicated by *| ? |* are mystery boxes that let you pick a Chance Card (generated randomely). Here is an example of the function that is called to send a Player to jail:

```c#
         public void GoToJail()
        {
            this.position = 10;
            this.injail = true;
            Console.WriteLine("You've been sent to jail!");
            Console.WriteLine();
        }
```

Another interesting function is the Loop function:
```c#
        public int Loop(int index)
        {
            if (index >= 40)
            {
                index = index - 40;

                Console.WriteLine("You passed START, collect $200");
                this.money = this.money + 200;
                Console.WriteLine("Your current balance is $" + this.money);
                Console.ReadKey();
            }
            return index;
        }
```

This function is called when finding the future position of the player:
```c#
        this.position = Loop(this.position + sum_dice);
```
If adding the sum of the dice leads to a number that is off the limits of the gameboard, the Loop function sends the position back to the beginning of the board. In Monopoly, crossing the START box lets you collect a sum of money, which is also done thanks to this function.

The last important function of this class is:
```c#
        public void BuyProperty(List<Property> properties)
```

This function works in several steps:

- first it checks if current player position is on a box corresponding to a Property
- if yes, it then checks the property's Owner status
  - if Owner is null it asks the player if he wants to buy the current property and adjusts money/ownership status accordingly
  - if Owner is the current player he can choose to add a house or hotel to his property which adds to the total value
  - if Owner is an opposing player a tax is calculated (10% of total property price) which the current player has to pay and the property owner receives
  
### Design Patterns
#### Singleton


#### Iterator

#### Decorator





