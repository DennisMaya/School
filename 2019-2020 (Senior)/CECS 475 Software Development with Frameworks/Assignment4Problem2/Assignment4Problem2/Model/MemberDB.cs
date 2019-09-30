using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assignment4Problem2.Model
{
    /// <summary>
    /// A class that uses a text file to store information about the gym members longterm.
    /// </summary>
    class MemberDB : ObservableObject
    {
        /// <summary>
        /// The list of members to be saved.
        /// </summary>
        private ObservableCollection<Member> members;
        /// <summary>
        /// Where the database is stored.
        /// </summary>
        private const string filepath = "C:/Users/mayad/OneDrive/Desktop/members.txt";
        /// <summary>
        /// Creates a new member database.
        /// </summary>
        /// <param name="m">The list to saved from or written to.</param>
        public MemberDB(ObservableCollection<Member> m)
        {
            members = m;
        }
        /// <summary>
        /// Reads the saved text file database into the program's list of members.
        /// </summary>
        /// <returns>The list containing the text file data read in.</returns>
        public ObservableCollection<Member> GetMemberships()
        {
            try
            {
                StreamReader input = new StreamReader(new FileStream(filepath,FileMode.OpenOrCreate, FileAccess.Read));
                string[] lines = System.IO.File.ReadAllLines(@"C:/Users/mayad/OneDrive/Desktop/members.txt");
                string fname;
                string lname;
                string email;
                char[] comma = { ',' };
                foreach (string line in lines)
                {
                    string[] items = line.Split(' ');
                    fname = items[0];
                    lname = items[1];
                    email = items[2].TrimStart(comma); ;

                    members.Add(new MessageMember(fname,lname,email,"Add"));
                }
                input.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid e-mail address format.");
            }
            return members;
        }
        /// <summary>
        /// Saves the program's list of members into the text file database.
        /// </summary>
        public void SaveMemberships()
        {
            StreamWriter output = new StreamWriter(new FileStream(filepath,FileMode.Create, FileAccess.Write));
            foreach (Member member in members)
            {
                output.WriteLine(member.ToString());
            }
            output.Close();
        }
    }
}
