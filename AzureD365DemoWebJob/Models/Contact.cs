using System;
using System.ComponentModel;

namespace AzureD365DemoWebJob
{
    public class Contact
    {
        /// <summary>
        /// Date de naissance
        /// </summary>
        public DateTime? birthdate { get; set; }

        /// <summary>
        /// Clé primaire
        /// </summary>
        public Guid? contactid { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string description { get; set; }

        /// <summary>
        /// Courrier électronique
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string emailaddress1 { get; set; }

        /// <summary>
        /// Prénom du contact
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string firstname { get; set; }

        /// <summary>
        /// Sexe
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string gendercode { get; set; }

        /// <summary>
        /// Fonction
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string jobtitle { get; set; }

        /// <summary>
        /// Nom du contact
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string lastname { get; set; }

        /// <summary>
        /// Téléphone mobile
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string mobilephone { get; set; }               

        /// <summary>
        /// Téléphone professionel
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string telephone1 { get; set; }

        /// <summary>
        /// Téléphone personnel
        /// </summary>
        [DefaultValue(Constants.MissingPropertyValue)]
        public string telephone2 { get; set; }        
    }
}