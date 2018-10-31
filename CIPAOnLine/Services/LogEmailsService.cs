using CIPAOnLine.DTO;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Services
{
    public class LogEmailsService
    {
        private Modelo db = new Modelo();

        public LogEmail SaveLogEmail(EmailDTO email, Exception ex)
        {

            string to = "";
            foreach (string t in email.To)
            {
                to += t + ";";
            }
            LogEmail log = new LogEmail
            {
                Para = to,
                Assunto = email.Subject,
                Erro = ex.Message
            };
            db.LogEmails.Add(log);
            db.SaveChanges();
            return log;
        }
    }
}