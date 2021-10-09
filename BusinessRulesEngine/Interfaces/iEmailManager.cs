using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRulesEngine.Interfaces
{
    /* Interface to a component to manage the sending of emails.
     * In a full system we'd also want an Email object and interface so
     * we can specify the subject as well as the body but for this test
     * that's overkill. We'd also have to think about whether it's appropriate
     * to return something, but since most email failures happen asynchronously
     * there's not a huge amount we can do with the information anyway.
     */

    public interface iEmailManager
    {
        void SendEmail(iPerson person, String message);
    }
}
