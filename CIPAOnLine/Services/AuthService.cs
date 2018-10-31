using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.Configuration;
using CIPAOnLine.Models;

namespace CIPAOnLine.Services
{
    public class AuthService
    {
        public Usuario GetUserAD(string userName)
        {
            userName = userName.Trim().ToLower();
            string dDomain = ConfigurationManager.ConnectionStrings["DomainUrl"].ConnectionString;
            string domainAndUsername = dDomain + @"\" + userName;
            string LDAP = ConfigurationManager.ConnectionStrings["LDAPUrl"].ConnectionString;
            DirectoryEntry de = new DirectoryEntry(LDAP);
            DirectorySearcher search = new DirectorySearcher(LDAP);
            search.Filter = "(SAMAccountName=" + userName + ")";

            // create results objects from search object
            SearchResult searchResult = search.FindOne();

            if (searchResult == null) return null;

            string nomeUser = searchResult.Properties.Contains("displayname") ? searchResult.Properties["displayname"][0].ToString() : null;
            string matricula = searchResult.Properties.Contains("codmatricula") ? string.Concat(searchResult.Properties["codmatricula"][0].ToString().SkipWhile(c => c == '0')) : null;
            string cargo = searchResult.Properties.Contains("department") ? searchResult.Properties["department"][0].ToString() : null;
            string email = searchResult.Properties.Contains("mail") ? searchResult.Properties["mail"][0].ToString() : null;


            return new Usuario
            {
                Login = userName,
                MatriculaFuncionario = matricula,
                Nome = nomeUser
            };

            //return new Usuario
            //{
            //    Login = userName,
            //    MatriculaFuncionario = matricula,
            //    Nome = nomeUser,
            //    Funcionario = new Funcionario
            //    {
            //        MatriculaFuncionario = matricula,
            //        Email = email,
            //        Nome = nomeUser,
            //        Cargo = cargo,
            //        Login = userName
            //    }
            //};
        }


        public SearchResult GetUserAD(string userName, string passWord)
        {
            userName = userName.Trim().ToLower();
            string dDomain = ConfigurationManager.ConnectionStrings["DomainUrl"].ConnectionString;
            string domainAndUsername = dDomain + @"\" + userName;
            string LDAP = ConfigurationManager.ConnectionStrings["LDAPUrl"].ConnectionString;
            DirectoryEntry entry = new DirectoryEntry(LDAP, domainAndUsername, passWord);
            try
            {
                Object NativeObject = entry.NativeObject;

                DirectorySearcher directorySearcher = new DirectorySearcher(entry);
                directorySearcher.Filter = "(SAMAccountName=" + userName + ")";
                SearchResult searchResult = directorySearcher.FindOne();

                return searchResult;
            }
            catch
            {
                return null;
            }
        }

        public bool AuthenticateUserOnAD(SearchResult searchResult)
        {
            bool usuarioValido;
            try
            {
                if ((Int32)searchResult.Properties["userAccountControl"][0] == 512
                   || (Int32)searchResult.Properties["userAccountControl"][0] == 66048
                   || (Int32)searchResult.Properties["userAccountControl"][0] == 544
                   || (Int32)searchResult.Properties["userAccountControl"][0] == 66080
                   || (Int32)searchResult.Properties["userAccountControl"][0] == 262656
                    || (Int32)searchResult.Properties["userAccountControl"][0] == 262688
                    || (Int32)searchResult.Properties["userAccountControl"][0] == 328192
                    || (Int32)searchResult.Properties["userAccountControl"][0] == 328224)
                {
                    usuarioValido = true;
                }
                else
                {
                    usuarioValido = false;
                }
            }
            catch
            {
                usuarioValido = false;
            }
            return usuarioValido;
        }
    }
}