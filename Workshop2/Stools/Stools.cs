using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Stools
{
    public class Stools
    {
    //    public class Stool
    //    {
    //        public Stool(string[] stringArray)
    //        {
    //            var x = int.Parse(stringArray[0]);
    //            this.X = x;
    //            var y = int.Parse(stringArray[1]);
    //            this.Y = y;
    //            var z = int.Parse(stringArray[2]);
    //            this.Z = z;
    //        }
            
    //        public int X { get; set; }
    //        public int Y { get; set; }
    //        public int Z { get; set; }
    //    }

    //    static int Maxhight(int usedStools, int topStool, char heigth)
    //    {
    //        if (usedStools == (1 << topStool))
    //        {
    //            if (heigth == 'x')
    //            {
    //                return stools[topStool].X;
    //            }
    //            if (heigth == 'y')
    //            {
    //                return stools[topStool].Y;
    //            }
    //            return stools[topStool].Z;
    //        }

    //        int fromStools = usedStools ^ (1 << topStool);



    //        int sideH;
    //        int sideX;
    //        int sideY;
    //        switch (heigth)
    //        {
    //            case 'x':
    //                sideH = stools[topStool].X;
    //                sideX = stools[topStool].Y;
    //                sideY = stools[topStool].Z;
    //                break;
    //            case 'y':
    //                sideH = stools[topStool].Y;
    //                sideX = stools[topStool].X;
    //                sideY = stools[topStool].Z;
    //                break;
    //            default:
    //                sideH = stools[topStool].Z;
    //                sideX = stools[topStool].X;
    //                sideY = stools[topStool].Y;
    //                break;
    //        }



    //        for (int i = 0; i < n; i++)
    //        {
    //            if ((fromStools & 1) == 1)
    //            {
    //                Maxhight(fromStools, i, 'x');
    //                Maxhight(fromStools, i, 'y');
    //                Maxhight(fromStools, i, 'z');
    //            }
    //        }
    //    }

        static void Main()
        {
    //        string stringNumberOfStools = Console.ReadLine();
    //        int numberOfStools = int.Parse(stringNumberOfStools);

    //        List<Stool> stoolsArray = new List<Stool>();

    //        char[] splitter = new[] {' '};
    //        for (int i = 0; i < numberOfStools; i++)
    //        {
    //            var currentStool = Console.ReadLine();
    //            var stringArray = currentStool.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
    //            Stool thisStool = new Stool(stringArray);
    //            stoolsArray.Add(thisStool);
    //        }


        }
    }
}
