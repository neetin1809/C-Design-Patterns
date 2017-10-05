using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod_GangOfFour
{


    class Program
    {
        static void Main(string[] args)
        {

            Document[] documents = new Document[2];
            documents[0] = new Resume();
            documents[1] = new Book();
            foreach (Document doc in documents)
            {
                Console.WriteLine("Document is:-"+doc.GetType().Name+"---");
                foreach (Page page in doc.Pages)
                {
                    Console.WriteLine("\t\t" + page.GetType().Name);
                }
            }
            Console.ReadLine();
        }
    }

    public abstract class Page
    { }

    public class IntroductionPage : Page
    { }

    public class SkillsPage : Page
    { }

    public class ExperiencePage : Page
    { }

    public class EducationPage :Page
    { }

    public class SummaryPage :Page
    {}

    public class IndexPage : Page
    { }

    public class BibloGraphyPage: Page
    { }

    public class conslusionPage : Page
    { }

    public class AppendexPage : Page
    { }

    public abstract class Document
    {
        public List<Page> Pages = new List<Page>();

        public Document()
        {
            this.CreatePages();
        }


        public abstract void CreatePages();

    }

    public class Resume:Document
    {

        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    public class Book:Document
    {
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new BibloGraphyPage());
            Pages.Add(new IndexPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new conslusionPage());
            Pages.Add(new AppendexPage());
        }

    }

}
