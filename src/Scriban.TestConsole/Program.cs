using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            text = @"{{&nbsp;<span blah=""blu>p""\r\nbing=""go"">'Block &nbsp;<br> 1'" + "\r\n" + @"|string.downcase}}";
            //text = @"{{&nbsp;'Block 1'}}";
            //text = @"{{'nbsp'}}";

            text = @"{{
x 
= 1;
y=
2<br/>
x+y
}}
";

            var lexerOptions = new Scriban.Parsing.LexerOptions() { IgnoreHtmlNoise = true };
            var template = Scriban.Template.Parse(text, lexerOptions: lexerOptions);
            var errors = template.Messages.Select(x => x.Message).ToList();

            string res = "";
            if (!template.HasErrors)
            {
                var context = new Scriban.TemplateContext();
                res = template.Render(context);
            }
            else
            {
                foreach (var error in errors)
                {
                    res += error + "\r\n";
                }
            }

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
