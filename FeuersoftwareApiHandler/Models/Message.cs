namespace FeuersoftwareApiHandler.Models
{
    using System;

    public class Message
    {
        /// <summary>
        /// Für das erstellen einer Message, die bereits von Connect verarbeitet wurde
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageText"></param>
        /// <param name="timeStamp"></param>
        /// <param name="source"></param>
        /// <param name="senderName"></param>
        /// <param name="receiverName"></param>
        /// <param name="createdAt"></param>
        /// <param name="createdBy"></param>
        public Message(
            int id,
            string messageText,
            DateTimeOffset timeStamp,
            string source,
            string senderName,
            string receiverName,
            DateTimeOffset createdAt,
            CreatedByModel createdBy)
        {
            this.Id = id;
            this.MessageText = messageText;
            this.TimeStamp = timeStamp;
            this.Source = source;
            this.SenderName = senderName;
            this.ReceiverName = receiverName;
            this.CreatedAt = createdAt;
            this.CreatedBy = createdBy;
        }

        /// <summary>
        /// Für eine Message, die an die Schnittstelle gesendet werden soll
        /// </summary>
        /// <param name="messageText"></param>
        /// <param name="timeStamp"></param>
        /// <param name="source"></param>
        /// <param name="senderName"></param>
        /// <param name="receiverName"></param>
        public Message(
            string messageText,
            DateTimeOffset timeStamp,
            string source,
            string senderName,
            string receiverName)
        {
            this.Id = 0;
            this.MessageText = messageText;
            this.TimeStamp = timeStamp;
            this.Source = source;
            this.SenderName = senderName;
            this.ReceiverName = receiverName;
            this.CreatedAt = DateTime.Now;
            this.CreatedBy = new CreatedByModel()
            {
                Id = "0",
                Name = "Public API"
            };
        }

        /// <summary>
        /// Die ID der Message in Connect
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Der Text der Message
        /// </summary>
        public string MessageText { get; }

        /// <summary>
        /// Der Zeitstempel der Message
        /// </summary>
        public DateTimeOffset TimeStamp { get; }

        /// <summary>
        /// Die Quelle der Message
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Der Name des Absenders der Message
        /// </summary>
        public string SenderName { get; }

        /// <summary>
        /// Der Name des Empfängers der Nachricht
        /// </summary>
        public string ReceiverName { get; }

        /// <summary>
        /// Der Zeitstempel der Erstellung der Message in Connect
        /// </summary>
        public DateTimeOffset CreatedAt { get; }

        /// <summary>
        /// Der User, der die Nachricht erstellt hat 
        /// </summary>
        public CreatedByModel CreatedBy { get; }
    }
}
