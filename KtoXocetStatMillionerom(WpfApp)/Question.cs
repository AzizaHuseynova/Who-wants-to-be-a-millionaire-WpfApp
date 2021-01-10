using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtoXocetStatMillionerom_WpfApp_
{
    public class Question
    {
        public string Text { set; get; }
        public string CorrectAnswer { set; get; }
        public string IncorrectAnswer1 { set; get; }
        public string IncorrectAnswer2 { set; get; }
        public string IncorrectAnswer3 { set; get; }
        public int HardLevel { set; get; }

        public override string ToString()
        {
            return $"{Text}";
        }
    }
}
