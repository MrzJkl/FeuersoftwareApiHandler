using System;
using System.Collections.Generic;
using System.Text;

namespace FeuersoftwareApiHandler.Models
{
    /// <summary>
    /// Eine Nachricht an die Connect-Benutzer
    /// </summary>
    public class News
    {
        /// <summary>
        /// Der Konstruktor für eine Nachricht mit allen benötigten Parametern.
        /// </summary>
        /// <param name="title">Der Titel der Nachricht</param>
        /// <param name="content">Der Inhalt der Nachricht</param>
        /// <param name="start">Der Startzeitpunkt der Nachricht</param>
        /// <param name="end">Der Endzeitpunkt der Nachricht</param>
        public News(string title, string content, DateTimeOffset start, DateTimeOffset end)
        {
            this.Id = 0;
            this.Title = title;
            this.Content = content;
            this.Start = start;
            this.End = end;
            this.Groups = new List<string>();
            this.MailingLists = new List<string>();
            this.CreatedBy = "ApiUser";
            this.Site = "API";
        }

        /// <summary>
        /// Die ID der Nachricht von Connect
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Der Titel der Nachricht
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Der Inhalt der Nachricht
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Der Name des Erstellers
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Der Startzeitpunkt
        /// </summary>
        public DateTimeOffset Start { get; set; }

        /// <summary>
        /// Der Endzeitpunkt
        /// </summary>
        public DateTimeOffset End { get; set; }

        /// <summary>
        /// Die Gruppen, für die die Nachricht bestimmt ist (eingeschränkte Sichtbarkeit)
        /// </summary>
        public IEnumerable<string> Groups { get; set; }

        /// <summary>
        /// Der Standort, zu dem die Nachricht gehört
        /// </summary>
        public string Site { get; set; }

        /// <summary>
        /// Die Mailverteiler, an die die Nachricht zusätzlich versendet werden soll
        /// </summary>
        public IEnumerable<string> MailingLists { get; set; }
    }
}
