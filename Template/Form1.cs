using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template {
	public partial class Form1 : Form {
		#region Variables
		#region Graphics
		/// <summary>
		/// fx,fy is the size of the form; fx2,fy2 is half that;
		/// so that (fx2, fy2) is the center of the form
		/// </summary>
		public int fx, fy, fx2, fy2;
		/// <summary>
		/// the canvas that holds the back buffer
		/// </summary>
		private Bitmap gi;
		/// <summary>
		/// The graphics for the back buffer that draws on gi
		/// </summary>
		private Graphics gb;
		/// <summary>
		/// The graphics for the front buffer that draws on the form
		/// </summary>
		private Graphics gf;
		/// <summary>
		/// The timer object for setting the heartbeat
		/// </summary>
		private Timer frameTimer = new Timer() { Interval = 1000 / 60 };
		/// <summary>
		/// The start time for frame timings
		/// </summary>
		private DateTime frameTimerStart;
		/// <summary>
		/// The finish time for frame timings
		/// </summary>
		private TimeSpan frameTimerFinish;
		/// <summary>
		/// Total number of frames elapsed since start
		/// </summary>
		private static ulong _tfr = 0; public static ulong tfr { get { return _tfr; } }
		#endregion Graphics
		#region Physics
		/// <summary>
		/// Delta Time, used for slowing down time
		/// </summary>
		public static double dt = 1.0;
		/// <summary>
		/// Gravity, in Sk/Kr2
		/// 
		/// </summary>
		public static double G = 7.2789375790163706e+002;

		#endregion Physics
		#region Game
		/// <summary>
		/// Random Number Generator
		/// </summary>
		public Random rng = new Random();
		/// <summary>
		/// Game State enum
		/// </summary>
		public enum eGS { Title, NewGame, Test }
		/// <summary>
		/// Current Game State
		/// </summary>
		private static eGS _GS = eGS.Test;

		/// <summary>
		/// List of Actors
		/// </summary>
		//public static List<Actor> actors = new List<Actor>();

		#endregion Game

		#endregion Variables
		#region Events
		public Form1() {InitializeComponent();}
		private void Form1_Load(object sender, EventArgs e) {
			fx = Width; fy = Height; fx2 = fx / 2; fy2 = fy / 2;
			gi = new Bitmap(fx, fy); gb = Graphics.FromImage(gi);
			gf = CreateGraphics(); frameTimer.Tick += frameTimer_Tick;


			// Init code here


			frameTimer.Start();
			Calc(); Draw();
		} // Form1_Load
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Escape: Close(); return;

				default: switch(_GS) {
						case eGS.Title: break;
						case eGS.NewGame: break;
						case eGS.Test: break;

						default: break;
					} break; // default: switch(_GS)
			} // switch(e.KeyCode)
		} // Form1_KeyDown
		private void Form1_MouseClick(object sender, MouseEventArgs e) {
			switch(_GS) {
				case eGS.Title: break;
				case eGS.NewGame: break;
				case eGS.Test: break;

				default: break;
			} // switch(_GS)
		} // Form1_MouseClick
		private void Form1_Paint(object sender, PaintEventArgs e) { gf.DrawImage(gi, 0, 0); }
		void frameTimer_Tick(object sender, EventArgs e) { Calc(); Draw(); _tfr++; }

		#endregion Events
		#region Calc
		public void Calc() {
			frameTimerStart = DateTime.Now;
			gb.Clear(Color.Black);

			switch(_GS) {
				case eGS.Title: break;
				case eGS.NewGame: break;
				case eGS.Test: break;

				default: break;
			} // switch(_GS)

		} // Calc

		#endregion Calc
		#region Draw
		public void Draw() {
			switch(_GS) {
				case eGS.Title: break;
				case eGS.NewGame: break;
				case eGS.Test: break;

				default: break;
			} // switch(_GS)


			// Time and draw the fps counter
			frameTimerFinish = DateTime.Now - frameTimerStart;
			gb.DrawString(frameTimerFinish.TotalMilliseconds.ToString() + "ms", Font, Brushes.White, 0, 0);
			gb.DrawString((1000 / frameTimerFinish.TotalMilliseconds).ToString() + " FPS", Font, Brushes.White, 0, 16);
			// Swap the buffer
			gf.DrawImage(gi, 0, 0);
		} // Draw

		#endregion Draw
		#region Methods

		#endregion Methods

	} // Class Form1
} // Namespace Template
