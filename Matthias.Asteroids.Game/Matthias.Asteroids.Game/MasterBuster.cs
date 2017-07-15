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
using Matthias.Asteroids.Engine;

namespace Matthias.Asteroids.Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class MasterBuster : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager _grafikVerwaltung;
        SpriteBatch _blattPapier;
        private Spielbereich _spielBereich;

        public MasterBuster()
        {
            _grafikVerwaltung = new GraphicsDeviceManager(this);
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
            _blattPapier = new SpriteBatch(GraphicsDevice);
            InhaltsVerwaltung.LadeContent(Content);
            _spielBereich = new Spielbereich(GraphicsDevice);
            _spielBereich.BeinhaltetBonis.Add(new Schild(new Rectangle(200,300,40,40)));
            _spielBereich.BeinhaltetBonis.Add(new SchussUpgrade(new Rectangle(400,200,40,40)));
            _spielBereich.BeinhaltetSpieler.Add(new Spieler(_spielBereich));
            // TODO: use this.Content to load your game content here
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

            _spielBereich.Aktualisieren(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _blattPapier.Begin();

            _spielBereich.Zeichnen(_blattPapier);

            _blattPapier.End();
            base.Draw(gameTime);
        }
    }
}
