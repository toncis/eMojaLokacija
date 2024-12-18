using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace eMojaLokacijaApi.Api.Models
{
    /// <summary>
    /// WebAPI - Model - API response base view model.
    /// </summary>
    // [Serializable]
    // [DataContract]
    public class ResponseBaseVm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBaseVm"/> class.
        /// </summary>
        public ResponseBaseVm()
        {
            this.NotificationContainer = new NotificationContainer();
        }

        /// <summary>
        /// Gets or sets the notification container.
        /// </summary>
        /// <value>
        /// The notification container.
        /// </value>
        // [DataMember]
        public NotificationContainer NotificationContainer { get; set; }

        /// <summary>
        /// Gets the ResponseBaseVm with notification error.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>The ResponseBaseVm object with error message.</returns>
        public static ResponseBaseVm BaseVmError(string errorMessage)
        {
            var retValue = new ResponseBaseVm();
            retValue.NotificationContainer.AddError(errorMessage);
            return retValue;
        }

        /// <summary>
        /// Gets the BaseVM with notification warning.
        /// </summary>
        /// <param name="warningMessage">The warning message.</param>
        /// <returns>The BaseVM object with warning message.</returns>
        public static ResponseBaseVm BaseVmWarning(string warningMessage)
        {
            var retValue = new ResponseBaseVm();
            retValue.NotificationContainer.AddWarning(warningMessage);
            return retValue;
        }

        /// <summary>
        /// Gets the BaseVM with notification success.
        /// </summary>
        /// <param name="successMessage">The success message.</param>
        /// <returns>The BaseVM object with success message.</returns>
        public static ResponseBaseVm BaseVmSuccess(string successMessage)
        {
            var retValue = new ResponseBaseVm();
            retValue.NotificationContainer.AddSuccess(successMessage);
            return retValue;
        }
    }

    /// <summary>
    /// WebAPI - Model - Base view model extensions.
    /// </summary>
    public static class ResponseBaseVmExtensions
    {
        /// <summary>
        /// Sets the notification warning.
        /// </summary>
        /// <param name="vm">The this.</param>
        /// <param name="warningMessage">The warning message.</param>
        public static void SetWarning(this ResponseBaseVm vm, string warningMessage)
        {
            vm.NotificationContainer.AddWarning(warningMessage);
        }
        /// <summary>
        /// Sets the notification error.
        /// </summary>
        /// <param name="vm">The this.</param>
        /// <param name="errorMessage">The error message.</param>
        public static void SetError(this ResponseBaseVm vm, string errorMessage)
        {
            vm.NotificationContainer.AddError(errorMessage);
        }
    }
}
