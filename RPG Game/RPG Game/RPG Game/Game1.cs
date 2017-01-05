using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RPG_Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D room1;

        Texture2D room3;
        Texture2D room2;
        Texture2D speech;
        Vector2 speechP = new Vector2(200, 400);
        Texture2D speech2;

        int blackOutTimer =100;
        bool speechB = false;
        bool speechB2 = false;
        bool outAlive = false;
       bool doorAlive = true;
       int timer = 25;
        Vector2 room2P = new Vector2(130, 30);
        Vector2 door2P = new Vector2(300, 340);
        Vector2 cavEP = new Vector2(325, 30);

        Rectangle guyRect;
        Rectangle door2Rect;
        Texture2D toadT;
        Texture2D cavET;
        Texture2D outT;
        Texture2D door2;
        Texture2D guyF;
        Texture2D guyB;
        Texture2D guyL;
        Texture2D guyR;
        Texture2D guyWF1;
        Texture2D guyWF2;
        Texture2D guyWL1;
        Texture2D guyWL2;
        Texture2D guyWR1;
        Texture2D guyWR2;
        Texture2D guyWB1;
        Texture2D guyWB2;
        Vector2 playerP = new Vector2(350, 200);
        Vector2 direction;
        Vector2 toadP= new Vector2(400, 200);
        Rectangle toadR;
        Rectangle cavER;

      //  int timer = 0;
        bool blackOut = false;
        bool roomAlive = true;
        bool pLeft = false;
        bool pRight = false;
        bool pForward = true;
        bool pBack = false;
        bool pWalkingF1 = false;
        bool pWalkingF2 = false;
        bool walkingForward = false;

        bool pWalkingL1 = false;
        bool pWalkingL2 = false;


        bool pWalkingR1 = false;
        bool pWalkingR2 = false;


        bool pWalkingB1 = false;
        bool pWalkingB2 = false;

        KeyboardState keyboard, previousState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            door2 = Content.Load<Texture2D>("Door2");
            room2 = Content.Load<Texture2D>("Room2");
            room3 = Content.Load<Texture2D>("Room3");
            outT = Content.Load<Texture2D>("Out");
            toadT = Content.Load<Texture2D>("Toad");
            speech =  Content.Load<Texture2D>("speech");
            speech2 = Content.Load<Texture2D>("secondTB");
            guyF = Content.Load<Texture2D>("StandingForward");
            guyB  = Content.Load<Texture2D>("StandingBack");
            guyL  = Content.Load<Texture2D>("StandingLeft");
            guyR = Content.Load<Texture2D>("StandingRight");
            guyWF1 = Content.Load<Texture2D>("walkingForward1");
            guyWF2 = Content.Load<Texture2D>("WalkingForward2");
            guyWL1 = Content.Load<Texture2D>("WalkingLeft1");
            guyWR1 = Content.Load<Texture2D>("WalkingRight1");
            guyWB1 = Content.Load<Texture2D>("WalkingBack1");
            cavET = Content.Load<Texture2D>("cavE");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
          
            KeyboardState aCurrentkeyBoardState = Keyboard.GetState();
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            keyboard = Keyboard.GetState();
            // TODO: Add your update logic here
            guyRect = new Rectangle((int)playerP.X, (int)playerP.Y, guyF.Width, guyF.Height);
            cavER = new Rectangle((int)cavEP.X, (int)cavEP.Y, cavET.Width, cavET.Height);
            door2Rect = new Rectangle((int)door2P.X, (int)door2P.Y, door2.Width, door2.Height);
            toadR = new Rectangle((int)toadP.X, (int)toadP.Y, toadT.Width, toadT.Height);
            if (keyboard.IsKeyDown(Keys.A) && previousState.IsKeyUp(Keys.A))
            {

              //  playerP.X -= 1;

                pForward = false;
                pLeft = true;
                pRight = false;
                pBack = false;
                pWalkingF1 = false;

            }

            if (keyboard.IsKeyDown(Keys.S)  && previousState.IsKeyUp(Keys.S))
            {

                //playerP.Y += 1;

                pForward = true;
                pLeft = false;
                pRight = false;
                pBack = false;
                pWalkingF1 = false;
            }

            if (keyboard.IsKeyDown(Keys.W) && previousState.IsKeyUp(Keys.W))
            {

                
                pLeft = false;
                pRight = false;
                pForward = false;
                pBack = true;
                pWalkingF1 = false;
            }


            if (keyboard.IsKeyDown(Keys.D) && previousState.IsKeyUp(Keys.D))
            {
                pRight = true;
                pLeft = false;
                pForward = false;
                pBack = false;
                pWalkingF1 = false;
            }


            //The actual walking part
            if (keyboard.IsKeyDown(Keys.S) )
            {

                playerP.Y += 1;
                pRight = false;
                pLeft = false;
                pForward = false;
                pBack = false;


             //   walkingForward = true;
                  pWalkingF1 = true;
             //     pWalkingF2 = true;

                  // pWalkingF1 = pWalkingF2;
                 //pWalkingF2 = pWalkingF1;
               


            }
            else
            {

             //   walkingForward = false;
                pWalkingF1 = false;
              //  pWalkingF2 = false;


                if (previousState.IsKeyDown(Keys.S))
                {
                    pForward = true;
                }
             

            }


            if (keyboard.IsKeyDown(Keys.A))
            {
                playerP.X -= 1;
                pRight = false;
                pLeft = false;
                pForward = false;
                pBack = false;
                pWalkingF1 = false;
                pWalkingL1 = true;
            
            
            
            }
            else
            {
                pWalkingL1 = false;


                if (previousState.IsKeyDown(Keys.A))
                {
                    pLeft = true;
                }


            }


            if (keyboard.IsKeyDown(Keys.D))
            {
                playerP.X += 1;
                pRight = false;
                pLeft = false;
                pForward = false;
                pBack = false;
                pWalkingF1 = false;
                pWalkingL1 = false;
                pWalkingR1 = true;



            }
            else
            {
                pWalkingR1 = false;


                if (previousState.IsKeyDown(Keys.D))
                {
                    pRight = true;
                }


            }

            if (keyboard.IsKeyDown(Keys.W))
            {
                playerP.Y -= 1;
                pRight = false;
                pLeft = false;
                pForward = false;
                pBack = false;
                pWalkingF1 = false;
                pWalkingL1 = false;
                pWalkingR1 = false;
                pWalkingB1 = true;


            }
            else
            {
                pWalkingB1 = false;


                if (previousState.IsKeyDown(Keys.W))
                {
                    pBack = true;
                }


            }


            if (guyRect.Intersects(door2Rect) && roomAlive == true)
            {

              
                roomAlive = false;

                playerP.Y = 130;
                //pLeft = false;
                //pRight = false;
                //pForward = false;
                //pBack = true;
                //pWalkingF1 = false;
                //  pForward = pBack;
                //if (keyboard.IsKeyDown(Keys.S))
                //{
                //    pBack = true;
                //}

            }

            else if (guyRect.Intersects(door2Rect) && keyboard.IsKeyDown(Keys.S))
            
            {
               // pBack = true;
               outAlive = true;
               doorAlive = false;
               playerP.X = 130;
               playerP.Y = 160;
              // pLeft = false;
              // pRight = false;
              // pForward = false;
              //// pForward = pBack;
              // pWalkingF1 = false;
              
            }

            if (guyRect.Intersects(toadR) && keyboard.IsKeyDown(Keys.R))
            {


                speechB = true;
            //    previousState = keyboard;
                for (int i = 5; i >= 0; i --)
                {
                    timer -= 1;
                }
              


                if (timer <= 0)
                {
                    speechB = false;
                    speechB2 = true;
                }
             
            }

           
                if (guyRect.Intersects(cavER))
                {

                    GraphicsDevice.Clear(Color.Black);




                    blackOut = true;

                    blackOutTimer--;

                }

                if (blackOutTimer <= 0)
                {

                    blackOut = false;
                
                }

                if (keyboard.IsKeyDown(Keys.B))
                {

                    blackOut = false;
                
                }


            if (previousState.IsKeyUp(Keys.R))
            {
                if (keyboard.IsKeyDown(Keys.R))
                {

                    speechB = false;
                
                }
            
            
            }
            

            previousState = keyboard;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            if (blackOut == false)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);


                spriteBatch.Begin();


                spriteBatch.Draw(room3, room2P, Color.White);


                spriteBatch.Draw(toadT, toadP, Color.White);

                if (outAlive == true)
                {
                    spriteBatch.Draw(outT, room2P, Color.White);
                    spriteBatch.Draw(cavET, cavEP, Color.White);

                }


                if (roomAlive == true)
                {
                    spriteBatch.Draw(room2, room2P, Color.White);

                }
                if (doorAlive == true)
                    spriteBatch.Draw(door2, door2P, Color.White);

                if (pForward == true)
                    spriteBatch.Draw(guyF, playerP, Color.White);

                if (pLeft == true)
                {
                    spriteBatch.Draw(guyL, playerP, Color.White);
                }


                if (pRight == true)
                    spriteBatch.Draw(guyR, playerP, Color.White);


                if (pBack == true)
                    spriteBatch.Draw(guyB, playerP, Color.White);





                if (pWalkingF1 == true)
                    spriteBatch.Draw(guyWF1, playerP, Color.White);

                if (pWalkingF2 == true)
                    spriteBatch.Draw(guyWF2, playerP, Color.White);






                if (pWalkingL1 == true)
                    spriteBatch.Draw(guyWL1, playerP, Color.White);





                if (pWalkingR1 == true)
                    spriteBatch.Draw(guyWR1, playerP, Color.White);


                if (pWalkingB1 == true)
                    spriteBatch.Draw(guyWB1, playerP, Color.White);




                if (speechB == true)
                {
                    spriteBatch.Draw(speech, speechP, Color.White);

                }


                if (speechB2 == true)
                {
                    spriteBatch.Draw(speech2, speechP, Color.White);

                }


                spriteBatch.End();

            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
