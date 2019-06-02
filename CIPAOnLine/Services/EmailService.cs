using CIPAOnLine.DTO;
using CIPAOnLine.Exceptions;
using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace CIPAOnLine.Services
{
    public class EmailService
    {
        Modelo db = new Modelo();

        public static void Send(object obj)
        {
            EmailDTO email = (EmailDTO)obj;
            try
            {
                EnviaEmail(email.To, email.Bcc, email.Copy, email.Subject, email.Message);
            }
            catch (Exception ex)
            {
                LogEmailsService log = new LogEmailsService();
                log.SaveLogEmail(email, ex);
            }
        }

        public static void EnviaEmail(ICollection<string> recepient, ICollection<string> bcc, ICollection<string> cc, string subject, string body)
        {
            MailMessage mMailMessage = new MailMessage();

            if (!(recepient == null))
            {
                foreach (var recep in recepient)
                {
                    mMailMessage.To.Add(new MailAddress(recep));
                }
            }
            if (bcc != null)
            {
                foreach (var objBcc in bcc)
                {
                    mMailMessage.Bcc.Add(new MailAddress(objBcc));
                }
            }
            if (cc != null)
            {
                foreach (var objBcc in cc)
                {
                    mMailMessage.CC.Add(new MailAddress(objBcc));
                }
            }

            //set the addresses 
            string from = ConfigurationManager.AppSettings["EmailUserName"];
            mMailMessage.From = new MailAddress(from); //IMPORTANT: This must be same as your smtp authentication address.

            //set the content 
            mMailMessage.Subject = subject;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Body = body;
            //send the message 
            using (SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["EmailHost"]))
            {

                //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
                NetworkCredential Credentials = new NetworkCredential(from, ConfigurationManager.AppSettings["EmailPassword"]);
                smtp.Credentials = Credentials;
                smtp.Send(mMailMessage);
            }
        }

        public static string ReplaceParams(string texto, params Tuple<string, string>[] parametros)
        {
            parametros.ToList().ForEach(p =>
            {
                texto = texto.Replace(p.Item1, p.Item2);
            });
            return texto;
        }


        public ICollection<string> GetEmailAddressesAll(int codEleicao)
        {
            Eleicao eleicao = db.Eleicoes.Find(codEleicao);
            if (eleicao == null) throw new EleicaoNaoEncontradaException();

            return eleicao.Funcionarios.Select(x => x.Email).ToList();
        }

        public ICollection<string> GetEmailAddressesCandidatos(int codEleicao)
        {
            Eleicao eleicao = db.Eleicoes.Find(codEleicao);
            if (eleicao == null) throw new EleicaoNaoEncontradaException();

            return eleicao.Candidatos.Select(x => x.Funcionario.Email).ToList();
        }


    }
}