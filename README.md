# AngryCat-Unity-Tutorial
<h2> This is a simple unity tutorial game to showcase what you can do in unity in less than an hour </h2>

We’re going to dive into Unity and start building our first 2D game
it is always good to first fill out a GDD (Game Design Document) before beginning a project, this allows you to stay in scope and finish out a project start to end as it is easy to get distracted and start adding features to your game with no end goal in mind.

remember the goal of a personal project is always to learn and feel motivated to tackle bigger projects so finishing smaller ones is key to help you build that confidence.

For smaller projects I recommend the one page design document approach and as you learn more about game dev you can expand over to bigger ones.

[One Page Game Design Document Template]( https://docs.google.com/document/d/1npEvqcMZSp0IX2hWw6Qq0WqJVfmVqS_YOGFWnnwfh-A/edit#).



That being said you will not need one for this tutorial as we will be building stuff together step by step.

 

First lets start off by opening unity hub and clicking on new project, once you’re there select 2D core and give your project a name I gave mine the name giving tree and click create project.

![New 2D Core Project](/Screenshots/1.png)


 

once you open up your project if you look up to the right top corner where the word default is if you change that to 2 by 3 your layout will look something like this

![Layout](/Screenshots/2.jpg)

lets get familiar with our setup

on our top right corner you may say something that says default this above image is showing 2by3 this is the layout that I like for working on unity, remember you can pick any layout you want

 

* scene: the view where all game objects live inside the **scene** you can move, scale, rotate and transform objects in there to arrange the scene of your game however you like.

* game: the view from the perspective of the game’s **main camera**, when you hit the play button, in there you can watch your game go and send inputs from your controller.

* project: this will house all the files for our game, you can use this to drag and drop **assets** into your game like sound bits, sprites, images, and code scripts.

* hierarchy: this contains all of the stuff (**game objects**) that are in the current scene.

* inspector: this is a view of the game object properties, it allows you to see and control game object **components** like a rigid body or a script that is attached to the game object.

<br>
<br>

 <p>now with that out of the way lets talk a bit about our objective.
 we will be making a flappy cat game, there will be some obstacles and the player will have to navigate through them.
</p>


this means we will need a cat game object, an obstacle game object, sprites to go along with those and some code to make the cat fly and some code to detect if the cat collides with the obstacle.
I’ve included some [files you can download](https://drive.google.com/drive/folders/1ykmCrT5zBNVfe6uof3oe8E2ySpplFx_o) to help you build the game but you can always go find your own fun game art and use instead.

 

 
<br>
lets create a game object and call it cat:

 * go to your hierarchy and right click select create empty

 * then click on the game object and go to your inspector pane and change the object name to cat

* click add component in the inspector and pick rendering then add sprite renderer

* drag the png image of your cat into the project pane under assets in unity

* then drag the imported cat image from the project pane into the sprite renderer where it says sprite

now you have a cat that looks something like that in your scene!

![Layout](/Screenshots/3.png)
 
 <br>

a *game object* is what holds the components that represents that entity within your game, you can add scripts to modify its behavior or add a sprite renderer so it can render the image of your cat into the game scene


now the game object is far too big in my screen, its taking up the whole game space, we can scale the object down but I think a better idea is to zoom the camera out, the default 2d camera object that comes with the project is a little too small for my taste.

* click on main camera in project hierarchy

* look at the inspector and find where it says size

* move the slider or input size 20

<br>
it should look something like this

![Layout](/Screenshots/4.png)
 
<p>
now notice if we hit play up top we will see in the game pane just a cat chilling in what seems to be a depressing navy sky, so lets add some code to make the cat do something.
</p>
<br>
our goal is to get the cat to fly in order to do so we need to add a physics component to the cat so its effected by gravity then write some code to get the cat to fly upward when we hit space so we would achieve the play mechanics for our flappy cat.
 <br>

* click on cat game object and head over to inspector pane

* click add component then physics 2d then pick rigid body 2d

<p>now if you hit play again our lovely cat should fall off the screen into the darkest abyss of unity’s game scene

lets add a collider as well so that our cat can interact with objects in the scene like the obstacles we talked about in our design blurb.
</p>

* click on cat game object and head over to inspector pane

* click on add component then physics 2d and pick box collider 2d
<br>

<p>notice that the collider is kind of too big for my cat and slightly off center so I am going to use the scale and offset properties in the collider component in my inspector to fix what the green box look like around my cat and it should look something like this.</p>

![Layout](/Screenshots/5.png)
<br>

I like to leave my players a pixel of forgiveness in my games when they collide with stuff so thats why you see the collider box 2d (green box) isn’t exactly on the outside of my cat it leaves a whole pixel out.

its important to note here if you picked some other shape you can use circle collider 2d or draw free shape collider if you choose to.

 <br>

now we will write our own script that allows us to do stuff with our lovely cat here, the script is typically a component as well that is attached to a game object and it tells the game object or the game what to do when certain events happen i.e. key strokes.

* click on cat game object and head over to inspector pane

* click add new component then new script

* name the script CatScript and click ok

* double click the cat script in the inspector pane to open up visual studio
<br>

you should see something like this 

<br>

![Layout](/Screenshots/6.png)

* start()  is a method that gets called once when the object is first enabled (when the scene starts)

* update() is a method that gets called over and over every frame your game is running

<p> what we’re going to do is essentially reference the game object cat in our script and we will change some of its properties using code, remember you can really control anything like the sprite color, rotation, size and position using code and scripts.</p>
<br>
your code should look something like this.
<br>
<br>
<code>

    public class CatScript : MonoBehaviour
    {
        public Rigidbody2D catRigidBody;
        public float flapStrength;
    
        void Start()
        {
        
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                catRigidBody.velocity = Vector2.up * flapStrength;
            }
        }
    }
</code>
<br>

make sure to save your cs file once you have typed your code in so that unity can compile the changes *very important*

<br>

now lets break this code down

<br>

initially by attaching the script to a game object we gain access to the game object, we can do things like referencing the game object and changing some of its properties shown below:


![Layout](/Screenshots/7.png)

we can change name position tag or layer, but this isn’t what we need, we need access to the rigid body 2d component so that we can make the cat fly, so what we do here is we reference the rigid body in our code and that will open up a slot in our script component to drag the rigid body of the object we want to reference into the field and it will tell unity this is what we’re referencing.

* click on the cat game object and head over the inspector pane

* drag the rigid body into the empty rigid body field in the script component

and it should look like this

![Layout](/Screenshots/8.png)

<br>
now that we have access to the rigid body what we want to do is apply some upward velocity to it so that the cat can fly, and we want to do that inside the *update* function because we want the cat to keep flying during the game not inside *start* because start only happens once.

<br>

now inside update we write something like this:

<br>

    catRigidBody.velocity = Vector2.up * flapStrength;

we’re just referencing the rigid body, and the rigid body has a property of velocity that we are accessing and we’re reassigning that velocity to a new number.

<br>

velocity in unity is a vector in a 3d game its a vector 3 and in a 2d game its a vector 2 it represents 2 points of that direction, so up would be 0,1 point but vector2.up in unity is a short hand for that.

<br>

and then we’re multiplying that by some float to give it some needed oomf.

<br>

now that code alone will just shoot our bird flying up till it disappears if we set the flap strength to anything over 0, so we added an if statement that checks every frame if the player hit they key space and if so the bird will get some upward velocity 

<br> 

notice that when you set the variable flapStrength to a public var and saved your file unity will compile and show that you have a Flap Strength field in your script component in your game object at the inspector pane.

<br>

you can play around with that number to set it to something that feels comfortable, lets start from 15 and work our way down and up.


in your inspector pane for your cat game object it should look something like this 

![Layout](/Screenshots/9.png)

now if we play the game the cat should start to fall and if you hit space it will get some upward velocity

<br> 

![Layout](/Screenshots/10.gif)

<br>

there you go ! your first video game !

just kidding we got a bit more to do.

<br> 

now we’re going to move on to the part where we create the obstacles that the cat is going to fly through.

<p>while we can move our cat forward and build a whole scene for it to navigate I much prefer to approach it in a simpler manner and create an illusion that feels like the cat is flying forward.</p>

<br>

what we’re going to do is we’re going to spawn obstacles (pipes) above and blow the cat, and they will move into the scene from the right and disappear off into the right that way the player feels like they’re moving forward but in reality they’re in place and the pipes are moving.

<br>
 

in your hierarchy pane:

* right click then pick create empty to create a game object and call it pipe

* now right click on pipe and click create empty this will create a child game object we’ll call top pipe

* do the same as the previous step and create another child object and we’ll call that one bottom pipe

* move the pip parent game object and position in at the center of your cat

this will allow us to have two pipes centered around the cat with same reference pivot point so they move along together as one object 

<br>

now lets do the same steps we did to our cat object to have the pipe show some sprite and has a collider as well

* click on bottom pipe game object and add sprite renderer and box collider

* drag and drop your pipe.png into your assets folder in your project pane

* click on bottom pipe game object then expand the sprite renderer drag the pipe sprite from your project folder to the sprite field in the sprite renderer component

* scale the game object so that it looks appropriate size to your cat I’m using 2.7 scale to x and y

for top pipe game object add sprite renderer and box collider:


* add your pipe sprite from project folder to the sprite field in the sprite renderer

* scale by 2.7 x and -2.7 y this will flip the pipe upside down for top position

* lastly position both pipes about 20 - 24 points away from your cat giving enough room top and bottom 

it should look something like this

![Layout](/Screenshots/11.png)

<br>

now if we simply try to move scale or rotate the pipe parent object the two pipes will move, scale and rotate along with the cat as the pivot point, parent objects allow us to have control over several objects and easy reference to them, it also allows unity editor to “anchor” some objects to one parent object in case you want to mass edit stuff.

<br>

now lets move those pipes along with a script:

* click on the parent game object and select add component from the inspector and pick new script

* name the new script pipe move script and hit enter

* double click the new script and open it up in visual studio and add the following code

<br>

<code> 

    public class PipeMoveScript : MonoBehaviour
    {
        public float moveSpeed = 4;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = transform.position + (Vector3.left * moveSpeed);
        }
    }

</code>

<br>

now if you save and let unity compile you will notice that move speed has a default value of 4 on the script component in the inspector this is because we declared it as public and then we assigned default value of 4 to it.
<br>

if we run the game we will notice that the pipes fly by way too fast, and you could turn the move speed down to 0.005 or something to slow the pipes down but that's not the best solution.

<br>

this is because the update runs as fast as many frames your game can run at, in fact if you run your game and look at the game stats tap at the upper right corner of your game pane you will notice that your game is running at like 600 fps and that will vary based on how powerful your machine is so we don't want the players to experience different speeds and difficulties playing the game based on their machine so this needs to be fixed
<br>

luckily the fix is simple you only need to add the time to the formula 
<br>


    transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;


*notice we didn’t need this for velocity this is because physics engine within unity runs on its own ticks vs frames and time*.

<br>

now that you updated your code and saved your move pipes script play the game and see if the speed is smoother.
<br>

now that we made sure all of this works lets drag the pipe parent object and drop it into our project folder and this will create a prefabricated game object for us which we unity folks call a *prefab*.

<br>

a *prefab* is an object blue print that allows you to clone as many of you want of that object and if you edit the blue print all the clones receive that update unless you disconnect that specific clone from the prefab

and it should look like this

![Layout](/Screenshots/12.png)

*notice how the pipe prefab has our two pipes in the project pane and how our object in the hierarchy has turned blue this tells us that this is a prefab*.

<br>

now lets delete our pipe parent object from the scene because we don't need that anymore and we’re going to create a new empty game object and we will call it a pipe spawner and we’ll move that object all the way to the right just outside the camera view.
<br>

we’re going to write some code spawn some pipes, and since we already have code on the prefab to move left the pipes will move on their own as they spawn

<br>

so click on the pipe spawner object and add new component new script name it PipeSpawner and add this code in:

 
<code>

    public class PipeSpawner : MonoBehaviour
    {
        public GameObject pipe;
        public float spawnRate = 2;
        private float timer = 0;
        // Start is called before the first frame update
        void Start()
        {
            SpawnPipe();
        }

        // Update is called once per frame
        void Update()
        {
            if (timer < spawnRate) 
            {
                timer += + Time.deltaTime;
            }
            else
            {
                SpawnPipe();
                timer = 0;
            }

        }

        private void SpawnPipe()
        {
            Instantiate(pipe, transform.position, transform.rotation);
        }
    }

</code>

<br>

lets break this code down (make sure you save your file though)

<br>

first we added a reference to the prefab pipe in our code and this is how unity will know what object we’re talking about when we tell it to spawn and you will need to drag your prefab pipe onto your script component and drop it in the pipe game object field it should look like this

![Layout](/Screenshots/13.png)

<br>

next we will need some timer and some interval to spawn pipes and as you can see its helpful to set some properties to public this helps with fine tuning your game from the editor vs having to recode and save the file and waiting for compile.

<br>

then we will write a simple spawn function all that it does is spawn a pipe with a handy function unity has built in called Instantiate and you can provide that function with a number of arguments, but we will just say spawn a pipe prefab use the same transformation and rotation of the spawner game object and that's all we need really

<br>

then we will have that spawn function called on an interval inside our update method.

<br>

you also notice its being called in start this is called only once when the spawner object is enabled i.e. when the game starts and this is so we can see pipes showing on the screen as soon as the game starts, try removing that line of code and see the difference for yourself.

<br>

you can also play around with the spawn rate number see what happens, I have mine set at 5.

<br>
 

now this seems a little boring that the pipes are just one straight line not very challenging.

lets change the spawner so that it has some random aspect to its positioning, see the following code:

<code>
 
    private void SpawnPipe()
        {
            float lowestPoint = transform.position.y - heightOffset;
            float highestPoint = transform.position.y + heightOffset;

            Instantiate(pipe, new Vector3(transform.position.x,
            Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
</code>   

<br>

we declared a public variable called heightOffset and defaulted this to 10 and we adapted our spawner to use the new points by generating a random value for y in the vector 3 between highest point and lowest point values.

<br>

after you save the file you should play the game and it would look something like this.

![Layout](/Screenshots/14.gif)

<br>

now if you notice in the scene above the pipes are still there, they don't go away after leaving the camera view, this means each pipe game object is taking spot in memory and costing us compute resources so lets write some code that actually takes out these pipes once we don't need them.

<br>

consider the following code:

<code>

    void DestroyPipes()
    {
        if(transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }

    }

</code>

<br>

first declare public float called deadZone in pipemove script and for me I set that to -70 this represents the furthest x point where the pipe leaves the screen completely and we can safely de-spawn it, you can calculate that by moving your cat all the way outside the screen to the left and see its x value and from there you know where its safe to remove the pipe.

<br>

we can add this function to our pipemove script and we make sure to call DestroyPipes() in update method in there to that the pipes get destroyed once they leave the deadZone

<br>

if you save and run your code you should see the pipes disappearing and at the very bottom of your screen there's a console ribbon bar that will display error and log messages it should say “Pipe Deleted” each time a pipe reaches the dead zone and gets destroyed.

<br>

*note there are many ways of achieving same effect, you can set up a collider wall outside the camera view and update the pipe move code to delete the pipe if it collides with that wall, but this method seems simpler for now because we haven’t tackled colliders just yet.*



<h2>lets create some UI for our game:</h2>
<br>

in the hierarchy right click and click on UI then Legacy then Text and add it.

<br>

this will add a parent object called canvas and a child object called text, lets go over to the canvas object first and lets change its properties over at the inspector.

![Layout](/Screenshots/15.png)

* Set UI scale to be scale with screen size and set screen to 1920x1080.

lets go to the text and

* change object name to score
* font size to something nice like 100
* move it to the corner of our screen
* change font color to something visible like white 
* use the upper left scale tool to make the housing box big enough for our text to show
* lets also change text value to 0 and here’s what it should look like.


scaling tool

![Layout](/Screenshots/16.png)

![Layout](/Screenshots/17.png)

<br>

now to control what shows on the UI score thing, we will create a game logic controller of sort to help us manage things around the game from score to lives and so on.

<br>

lets create an empty game object called Logic Manager and attach a new script controller on it.

<br>
in the script lets add the following code:

<br>

<code>

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class LogicManager : MonoBehaviour
    {
        public int playerScore;
        public Text scoreText;

        [ContextMenu("Increase Score")]
        public void addScore()
        {
            playerScore = playerScore + 1;
            scoreText.text = playerScore.ToString();
        }

    }

</code>
<br>

once you save the logic manager code make sure to drag your score game object onto the Score Text field this will tell the logic manager you now have a reference to the score we’re displaying under the canvas

<br>

the context menu allows you to trigger the addScore() function in the editor, so if you click on the logic manager game object and head over to the inspector click the dots over the logic script this will allow you to select add score from the menu that pops up and it gives you a live test to see if your code works and your stuff is hooked up right.

<br>

setting addScore to public allows us to trigger this code from outside the game object.

<br>

it should look like this:

![Layout](/Screenshots/18.gif)
 
<br>

now lets go ahead and add the mechanism which will allow us to detect the cat going inbetween the pipes and add 1 point to our score.

<br>

in the game we have several *colliders* right now their job is to detect *collision* and act as a barrier, but there are another sort of use for colliders, we can use them as *triggers* by turning them into trigger colliders they’re a sort of invisible collider that our player can walk through and then gets detected and some code gets triggered due to that action.

<br>
 

lets first open up our pipe prefab and lets add a box 2d collider in the middle of that prefab.
<br>

* head to your project pane and find the pipe prefab

* double click on that prefab and it should open in the scene pane

* on the hierarchy pane add a child object to pipe called score trigger

* add a component to score trigger 2d box collider

* fix the scale of Y so that it fills the middle of the two pipes vertically

* fix the x scale to 0.5 so its thin

* and click the check box “is trigger”

* add a new script to the score trigger object and  call it ScoreTriggerScript then add the code below

<code>


    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ScoreTriggerScript : MonoBehaviour
    {
        public LogicManager logic;
        // Start is called before the first frame update
        void Start()
        {
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            logic.addScore();
        }
    }

</code>

<br>

in here we are referencing our LogicManager script and creating an object from it, but notice we cannot drag and drop that to the prefab and we cannot drag and drop it to a pipe in the inspector because pipes don't exist till a game start

<br>

so we resort to code to allow us to find that game object reference on start, but before we’re able to do that we need to head back to our scene by hitting the little back arrow left to the word pipe on our inspector pane to exit out of our prefab view

<br>

then we need to click on our logic manager and add a tag to it from the upper right in the inspector and we need to name that tag “Logic” and make sure after we add the tag to actually assign it to the logic manager from the drop down menu for tags and it should look like this.

<br>

![Layout](/Screenshots/19.png)

<br>

now if you saved the ScoreTriggerScript  file and added the tag correctly if you play the game and pass between the pipes you should be awarded a score point and you should see your score go up!

<br>

hooray ! you made it all the way here, there’s just a bit more to go I promise but you’ve almost have a working game now that is fun to play and I am very proud of you !

<br>

lets do coupe of future proofing things before we continue:
lets upgrade our collision detection to handle layers, it will just make sure what it collided with was the actual cat not anything else (this is optional btw)

<br>

* head to the cat game object in hierarchy and click on it

* in the inspector pane in the upper right corner theres layer drop down click on it

* add new layer just like the tag call it cat and then make sure to assign the cat object that layer and make note of the number

* go back to the score trigger logic and add an if statement that checks for the layer before adding the score code should look something like this.

![Layout](/Screenshots/19.png)

<br>

![Layout](/Screenshots/20.png)

<br>

<code> 


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            logic.addScore();
        }
    }

</code>

<br>

and test your changes, you should still be able to score (remember to save your file and assign the cat layer to the cat game object)



<br>
 

lets do one more (optional) future proofing

lets go back to the logic manager and change the add score function to take in a value for what score we want to add, this allows us to change the way we add score if we want to add more features to the game later.

<br>

code should look like this:

<code>

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

</code>

</br>

now addScore() in ScoreTriggerScript should complain simply change that to addScore(1); and that should fix the problem and make our function more versatile now.

<br>
 

now we’re at the home stretch we’re almost done with our game, the only part left to do is the logic that causes us to lose (our poor cat dying due to unsolicited Mario plumbing collision) by either falling off or colliding with a pipe, and maybe some option to retry ! 

<br>

lets create a game object under the parent canvas called game over screen

* right click on game object canvas

* click create empty and name it Game Over Screen

* right click on the game over screen object and add a child UI object of type text from legacy and name it Game Over Text and change its text to say “Game Over Cat !”

* right click on game over screen object and create a UI object of type button from legacy and name it Retry Button

* resize everything so its big enough and readable and change the text on the button to Retry, the text can be found as a child to the button game object

<br>

it should look something like this when you’re done

![Layout](/Screenshots/21.png)

 

now lets head back to our game logic manager script and lets add this bit of code under the add score function:

<br>
<code>

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

</code>
<br>

now that we have that code in there and we saved head to unity hierarchy pane:

* click on the retry button game object 

* scroll down to the inspector to find the On Click event 

* drag the game logic manager object from the hierarchy pane onto the empty field that says “none (object)”

* click on the “No Function” drop down and pick LogicManger then restartGame() function from there

it should look like this:


![Layout](/Screenshots/22.png)


and then like this after you’ve picked restart function:

![Layout](/Screenshots/23.png)

<br>

now test it out and it should restart the game everytime you click on it during play mode!

<br>

it works !? excellent ! lets continue…

<br>

now we don’t want this to be present all the time during play obviously so lets just disable the whole game over screen parent object by heading to the hierarchy pane and unchecking the check mark right next to our game object name like so 


and lets write the logic that sets the game over screen ON when the cat dies

in our logic manager lets set a public var type GameObject called gameOverScreen so we can reference it then add the following function somewhere under our other methods

<br>
<code>

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

</code>
<br>

lets go back to unity drag the game over screen game object into the game over screen field in the logic manager to set the reference there.

now lets head to our cat script to code our collision logic

and our code should look like this:

<code>

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CatScript : MonoBehaviour
    {
        public Rigidbody2D catRigidBody;
        public float flapStrength;
        public LogicManager logic;
        public bool catIsAlive = true;
        // Start is called before the first frame update
        void Start()
        {
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) == true && catIsAlive)
            {
                catRigidBody.velocity = Vector2.up * flapStrength;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            logic.gameOver();
            catIsAlive = false;
        }
    }

</code>
<br>

there are new additions to our CatScript first we are referencing our logic manager using the same way we did in our score trigger script, then we are setting a boolean if our cat is still alive to allow player to lose control over the cat once dead.

<br>

we see this OnCollisionEnter2D method that when it detects a collision with this cat object it will trigger a game over function and sets the cat alive to false which in turn cuts off the control from the player.

<br>

dont forget to save and check your references and play the game and see if it works.

<br>
 

the last step if you want is to build the game, from file drop down click build and run select where you want your build to be compiled to and the game will finish compiling and building and it will run the exe

<br>


*this is it! the game is finished and you made it all the way to the end congratulations on your first unity game*
 

now before we ship this off to steam and make lots of profit and quit our day jobs

<h2> here’s some considerations: </h2>


* you will need some sort of exit button to quit the game if you’re running a build instead of doing ALT+F4

* it would be nice to have a main menu scene that transitions into the game after you hit start

* the input system used is old and while its not the best to use its simple to implement and understand consider moving to newer input manager from unity once you got the hang of things

* the cat doesn't die if they fly off screen or fall down ! maybe consider adding some death colliders above and under to keep the game functioning correctly

 
<br>

<br>

there are plenty of ways to do things some are better than others but here for the sake of simplicity and hitting our goal of creating our first actual game we resorted to simpler methods, I am sure you will come up with brilliant solutions in your own projects and I can’t wait to hear all about it.

 *this has been fun afternoon for me and I hope it was fun for you too, thank you for reading this and trying it out.*