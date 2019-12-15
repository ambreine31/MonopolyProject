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
        RollDiceAndMove(Random generator){ ..}
```
This function generates the dice numbers and uses the sum of the dice to move the player position forward.
It also calls specific instructions for some boxes on the gameboard. For example, 30 is *Go to Jail* and some boxes indicated by *| ? |* are mystery boxes that let you pick a Chance Card (generated randomly). Here is an example of the function that is called to send a Player to jail:

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
        public void BuyProperty(List<Property> properties){...}
```

This function works in several steps:

- First it checks if current player position is on a box corresponding to a Property
- If yes, it then checks the property's Owner status
  - If Owner is null it asks the player if he wants to buy the current property and adjusts money/ownership status accordingly
  - If Owner is the current player he can choose to add a house or hotel to his property which adds to the total value
  - If Owner is an opposing player a tax is calculated (10% of total property price) which the current player has to pay and the property owner receives
  
### Design Patterns
#### Singleton
![singleton_pattern_uml_diagram](https://user-images.githubusercontent.com/58735251/70866285-0d64ef80-1f68-11ea-8fc8-043c75be7ec4.jpg)

The Monopoly Gameboard was made using a singleton design pattern so that only a single instance of the board could exist at a time.
This works thanks to the GetInstance function:

```c#
        public static GameBoard GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new GameBoard();
                return instance;
            }
        }
```
This function allows for a GameBoard to be constructed only in the event that an instance does not already exist.
I tested this pattern using a counter that incremented whenever a new instance of the gameboard was called and made sure that the counter value stayed at 1 even when a second gameboard was called in the main. This is useful because it makes sure that any future references to the gameboard lead to the instance created.
As recommended from a video (https://www.youtube.com/watch?v=LypTOnfkfvA) I made my GameBoard class a *sealed* class because it prevents any inheritance of the GameBoard, as it is not permitted in the singleton design pattern.

#### Iterator
![500px-Iterator_UML_class_diagram svg](https://user-images.githubusercontent.com/58735251/70866293-1e156580-1f68-11ea-865a-a8952bae018b.png)

I decided to use an iterator design pattern to traverse all of the participants in the game.
For this I had to create several different structures:
- First of all my collections item, the **Player** class, containing the player attributes, constructor and functions
- The aggregate interface **IPlayerAggregate** an interface used to create an iterator object
- The concrete aggregate class **PlayerCollection** which contains an ArrayList of players and implements the IPlayerAggregate interface (returns a concrete iterator)
- The iterator interface **IPlayerIterator** an interface created to access and traverse an aggregate object
- The concrete iterator class **PlayerIterator** which implements the iterator interface and contains all of the functions to cycle through every element of a player collection

In the main() this is how we use the iterator function:
```c#
        PlayerCollection collection = new PlayerCollection();
        ...
        PlayerIterator iterator = collection.CreateIterator();
        for (Player item = iterator.First(); !iterator.IsDone; item = iterator.Next()){      
                ...
        }
```
A player collection is initialized with the corresponding players. A player iterator is then created for this collection. Finally, the iterator is used in a for loop to traverse each of the Players one at a time using the above implemented functions.

#### Decorator
![400px-Decorator_UML_class_diagram svg](https://user-images.githubusercontent.com/58735251/70866297-27063700-1f68-11ea-9911-9896fc401b77.png)

The decorator design pattern was used as a way of extending the functionality of the Property class without altering the existing structure. The functionality that I wanted to add was increasing the total price of the property when the player adds a house or hotel to his property.
For this I implemented the decorator pattern uml:
- **IProperty** is the component, an interface that defines a property
- **Property** is the concrete component, that implements IProperty
- **PropertyDecorator** is the decorator, it encloses the IProperty component in an object to add design methods to it
```c#
    public abstract class PropertyDecorator:IProperty
    {
        private IProperty prop;

        public PropertyDecorator(IProperty Prop)
        {
            prop = Prop;
        }
        ...
        public abstract double SetTotalPrice();
    }
```
As we can see this is acheived by having the IProperty enclosed in the constructor of PropertyDecorator. We then added the abstract method SetTotalPrice() which is what will be used to change the price according to the houses or hotels added.
- **HouseDecorator** and **HotelDecorator** are both concrete decorators extended from the PropertyDecorator. They implement the SetTotalPrice() methods and add value to the total price of the property when called.

I chose this design pattern because i wanted a way to be able to increase the price of each house or hotel added on top of the property price and this was a technique that allowed me to pile on the houses and hotels at will. 


Special thanks:
- Kudvenkat design pattern tutorials on youtube
- exceptionnotfound.net design pattern examples
