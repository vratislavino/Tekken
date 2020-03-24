using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tekken
{
    public partial class Game : Form
    {
        Fighter fighter = null;
        Fighter opponent = null;
        List<Type> minigames = new List<Type>()
        {
            typeof(Targets),
            typeof(Letters),
            typeof(WaveMatch)
        };

        public Game(Fighter fighter,Fighter opponent)
        {
            this.fighter = fighter;
            this.opponent = opponent;
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.fighterpctbx.BackgroundImage = Image.FromFile(fighter.ImgPath);
            this.opponentpctbx.BackgroundImage = Image.FromFile(opponent.ImgPath);
        }

        private void fightbtn_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Fighter attacker = r.Next(2) == 0 ? fighter : opponent;
            Fighter defender = attacker == fighter ? opponent : fighter;
            Fight(attacker,defender);
        }

        private void Fight(Fighter attacker,Fighter defender)
        {
            if (attacker == fighter)
                StartMiniGame(attacker, defender);
            else
                DealRandomDamage(attacker,defender);
        }

        private void DealRandomDamage(Fighter attacker, Fighter defender)
        {
            
        }
        private void DealDamage(Fighter attacker, Fighter defender,int dmg)
        {

        }

        private void StartMiniGame(Fighter attacker, Fighter defender)
        {
            Random r = new Random();


            IMinigame mg = (IMinigame)Activator.CreateInstance(
               minigames[/*r.Next(minigames.Count)*/2]
                );
            Form f = mg as Form;
            if(f != null) 
            {
                mg.GameEnded += (points) =>
                {
                    DealDamage(attacker,defender,points);
                };
                mg.StartGame();
                f.ShowDialog();
            }
        }
    }
}
