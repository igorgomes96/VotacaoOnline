using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o usuário: ");
            string userName = Console.ReadLine();
            string dDomain = ConfigurationManager.ConnectionStrings["DomainUrl"].ConnectionString;
            string domainAndUsername = dDomain + @"\" + userName;
            string LDAP = ConfigurationManager.ConnectionStrings["LDAPUrl"].ConnectionString;
            DirectoryEntry de = new DirectoryEntry(LDAP);
            DirectorySearcher search = new DirectorySearcher(LDAP);
            search.Filter = "(SAMAccountName=" + userName + ")";

            // create results objects from search object  

            SearchResult result = search.FindOne();

            if (result != null)
            {
                // user exists, cycle through LDAP fields (cn, telephonenumber etc.)  

                ResultPropertyCollection fields = result.Properties;

                foreach (String ldapField in fields.PropertyNames)
                {
                    // cycle through objects in each field e.g. group membership  
                    // (for many fields there will only be one object such as name)  

                    foreach (Object myCollection in fields[ldapField])
                        Console.WriteLine(String.Format("{0,-20} : {1}",
                                      ldapField, myCollection.ToString()));
                }
            }

            else
            {
                // user does not exist  
                Console.WriteLine("User not found!");
            }
            Console.ReadKey();
        }
    }
}
