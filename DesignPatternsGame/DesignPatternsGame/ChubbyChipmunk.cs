using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DesignPatternsGame
{
    public class ChubbyChipmunk: Hero
    {
        public ChubbyChipmunk()
        {
            Name = "Chubby Chipmunk";
            TotalHP = 100;
            HP = TotalHP;
            Speed = 20;
            MaxDamage = 50;
            MinDamage = 20;
            HitChance = 90;
            Defense = 5;
            img = new BitmapImage(new Uri("pack://application:,,,/Images/chipmunk.png", UriKind.Absolute));
        }

        public override void useSpecial(GameCharacter target)
        {
            throw new NotImplementedException();
        }
    }
}
