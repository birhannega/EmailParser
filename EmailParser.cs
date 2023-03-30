using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using Newtonsoft.Json;
using System.Globalization;
using MimeKit.Text;

namespace EmailParser
{
    public static class EmailParser
    {
        // Generate an unqiue email file name based on date time
        static string _generateFileName(int sequence)
        {
            DateTime currentDateTime = DateTime.Now;
            return string.Format("{0}-{1:000}-{2:000}.eml", currentDateTime.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")), currentDateTime.Millisecond, sequence);
        }
        public static void ParseEmail()
        {
            // create an ImapClient instance
            using (var client = new ImapClient())
            {
                // connect to the IMAP server and authenticate
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate("hirebirhan@gmail.com", "tjuvdjclwozgrjiz");

                var items = MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId;
                // set the date range for messages to fetch
                DateTime cutoff = DateTime.Now.AddMinutes(-10);
                var query = SearchQuery.SentSince(cutoff);
                client.Inbox.Open(FolderAccess.ReadOnly);

                // search for all messages
                var results = client.Inbox.Search(SearchQuery.All.And(SearchQuery.SentSince(cutoff)));
                var messages = client.Inbox.Fetch(results, items);

                // retrieve and process each message
                foreach (var message in messages)
                {
                    MimeMessage mimeMessage = client.Inbox.GetMessage(message.UniqueId);
                    string Sender = mimeMessage.From.Mailboxes.Single().Address;
                    string Subject = mimeMessage.Subject;

                    var replyDto = new EmailReplyDto
                    {
                        Sender = mimeMessage.From.Mailboxes.Single().Address,
                        Subject = mimeMessage.Subject,
                    };


                    // check if the message has attachments
                    if (mimeMessage.Attachments.Count() > 0)
                    {
                        Console.WriteLine("Subject: {0}", mimeMessage.Subject);

                        // process the attachments
                        foreach (var attachment in mimeMessage.Attachments)
                        {
                            try
                            {
                                // read the attachment into a string
                                string json = string.Empty;
                                using (var stream = new MemoryStream())
                                {
                                    var part = (MimePart)attachment;
                                    part.Content.DecodeTo(stream);
                                    stream.Seek(0, SeekOrigin.Begin);
                                    using (var reader = new StreamReader(stream))
                                    {
                                        json = reader.ReadToEnd();
                                    }
                                }

                                // deserialize the JSON into an object
                                VesselReportDto emailData = JsonConvert.DeserializeObject<VesselReportDto>(json);

                                // process the email data as needed
                                SaveToDB(emailData);
                                SendReply(replyDto, "Reply Message");
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                    }
                }

                // disconnect from the server
                client.Disconnect(true);
            }
        }


        public static void SaveToDB(VesselReportDto report)
        {
            Console.WriteLine("Save to Db");
            Console.WriteLine("report_recipient: {0}", report.report_recipient);
        }
        public static void SendReply(EmailReplyDto replyDto, string message)
        {
            Console.WriteLine("Send Reply");
            Console.WriteLine("Replying to: {0}", replyDto.Sender);
            Console.WriteLine("Message: {0}", message);
        }
    }
}
