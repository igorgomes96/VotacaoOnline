using CIPAOnLine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIPAOnLine.Services
{
    public class TemplatesEmailsService
    {
        Modelo db = new Modelo();

        public ICollection<TemplateEmail> GetTemplates()
        {
            return db.Templates.ToList();
        }

        public TemplateEmail GetTemplate(int id)
        {
            return db.Templates.Find(id);
        }

        public TemplateEmail PostTemplate(TemplateEmail template)
        {
            TemplateEmail t = db.Templates.Add(template);
            db.SaveChanges();
            return t;
        }

        public void PutTemplate(TemplateEmail template)
        {
            db.Entry(template).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public TemplateEmail DeleteTemplate(int id)
        {
            TemplateEmail t = db.Templates.Find(id);
            if (t == null)
                return null;

            t = db.Templates.Remove(t);
            db.SaveChanges();
            return t;
        }

    }
}