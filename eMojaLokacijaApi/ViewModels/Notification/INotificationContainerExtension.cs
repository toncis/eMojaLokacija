using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMojaLokacijaApi.Api.Models
{
    /// <summary>
    /// Simpler addition of Notifications to NotificationContainer
    /// </summary>
    interface INotificationContainerExtension
    {
        void AddError(string errorMessage);
        void AddError(string errorMessage, string identifier);

        void AddSuccess(string successMessage);
        void AddWarning(string warningMessage);
    }
}
