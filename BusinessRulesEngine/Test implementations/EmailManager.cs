using BusinessRulesEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Test_implementations
{

    /* Class to simulate an implementation of iEmailManager, 
     * logs sent messages and exposes them in a way we can get at 
     * for testing.
     */

    public class EmailManager : iEmailManager
    {

        List<String> messages;

        //Property to let us get at the sent messages for testing
        public List<string> Messages { get => messages; set => messages = value; }

        public void SendEmail(iPerson person, string message)
        {
            messages.Add(person.EmailAddress + message);
        }

        public EmailManager()
        {
            Messages = new List<string>();
        }
    }
}
