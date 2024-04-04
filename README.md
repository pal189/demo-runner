**Demo project: runner game**

This is simple runner game example developed for demonstration purpose.

***DISCLAIMER***: The project is by all means not a completed product of commercial level of quality. There is a lot of functionality that can be added or improved.

I. **Application lifecycle**
1. **Dependency Injection (Zenject)**
   
2. Game State Machine (GSM) **loades 'StartUp' scene** and prepares all the services, third-party frameworks there.
This scene has no game logic, which ensures that in the moment of launching the game logic, all the services are ready.
 
3. Game State Machine (GSM) **loads level scene** ('Main"). All the game logic is here.
   
II. **Architecure**
The architecure of this game is based on the following solutuions and patterns.
1. **Dependency Injection (DI)**
The DI is implemented in this project by using Zenject. DI implents DIP (Dependency Inversion Principle). DI makes the modules of the project to depend by interfaces, not by their implementation (concreate classes).

2. **Game State Machine (State pattern)**
GSM manages the game flow by changing game states. It helps to decouple the game flow from the game logic and different game states from each other.
3. **Factories**
Factories are used to create game objects. They implement SRP (Single Responsibility Principle) becuase they separate the responsibility of object creation from other classes.

4. **Services**
As well as factories, the services implement SRP. They separate specific functionality (like Input, asset provisioning, etc.) from other classes.

5. **Compositon over inheritance**
Game enities, like hero, platform, collectable, etc. are not large classes with complex inheritance. Instead of that each their feature is separated from other features in its own class which implements SRP.

So, the game entity becomes a composition of features. It gives flexibility and freedom to change each feature without the risk of accidential change of the other features. 

Technically, game entity is a game object with the set of Monobehaviours (features). This is the easiest way to implement composition provided by Unity. The other advantage of this solution is that it allows to create game entities in the editor, add and remove feaetures from them without touching the code. It give the game designer the ability to experiment with gameplay without help of the programmer.

Note: Exessive usage of expensive Update() and other Unity methods should be avoided in such approach. This can be achieved by using events or reactive programming.

6. **Buff system (Stratagy pattern)**
Buff system implementes OCP (Open-Closed Principle), giving the possibility to add new types of buffs in the future without changing the code of the system as well as the client code.

III. **Frameworks, plugins**
1. Zenject
2. UniRx
3. DOTween
4. UniTask
5. SimpleInout
</remarks>
