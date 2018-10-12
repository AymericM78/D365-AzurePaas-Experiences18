// =====================================================================
//  This file has been generated with a tool : DO NOT EDIT IT
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//   14/09/2018  Aymeric M - Senior Consultant
// =====================================================================

#region  == Using == 
using System;

#endregion

namespace AzureD365DemoWebJob
{
    /// <summary>
    /// Metadata definition for Contact
    /// Personne liée à une division, telle qu'un client, un fournisseur ou un collègue.
    /// 
    /// Warning : This file has been generated with a tool : DO NOT EDIT IT
    /// </summary>
    public class CrmContact
    {
        public const string EntityLogicalName = "contact";
        public const int EntityTypeCode = 2;

        public static class Fields
        {
            #region System Attributes

            /// <summary>
            /// Identificateur unique de l'adresse 1.
            /// Type : Uniqueidentifier
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string Address1_AddressId = "address1_addressid";

            /// <summary>
            /// Tapez la ville de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_City = "address1_city";

            /// <summary>
            /// Affiche l'adresse principale complète.
            /// Type : Memo
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string Address1_Composite = "address1_composite";

            /// <summary>
            /// Tapez le pays ou la région de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Country = "address1_country";

            /// <summary>
            /// Tapez la région de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_County = "address1_county";

            /// <summary>
            /// Tapez le numéro de télécopie associé à l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Fax = "address1_fax";

            /// <summary>
            /// Tapez la latitude de l'adresse principale à utiliser dans les cartes et les autres applications.
            /// Type : Double
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Latitude = "address1_latitude";

            /// <summary>
            /// Tapez la première ligne de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Line1 = "address1_line1";

            /// <summary>
            /// Tapez la deuxième ligne de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Line2 = "address1_line2";

            /// <summary>
            /// Tapez la troisième ligne de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Line3 = "address1_line3";

            /// <summary>
            /// Tapez la longitude de l'adresse principale à utiliser dans les cartes et les autres applications.
            /// Type : Double
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Longitude = "address1_longitude";

            /// <summary>
            /// Tapez un nom descriptif pour l'adresse principale, comme Siège social de l'entreprise.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Name = "address1_name";

            /// <summary>
            /// Tapez le code postal de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_PostalCode = "address1_postalcode";

            /// <summary>
            /// Tapez le numéro de boîte postale de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_PostOfficeBox = "address1_postofficebox";

            /// <summary>
            /// Tapez le nom du contact principal pour l’adresse principale du compte.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_PrimaryContactName = "address1_primarycontactname";

            /// <summary>
            /// Tapez l'état ou la province de l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_StateOrProvince = "address1_stateorprovince";

            /// <summary>
            /// Tapez le numéro de téléphone associé à l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Telephone1 = "address1_telephone1";

            /// <summary>
            /// Tapez un deuxième numéro de téléphone associé à l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Telephone2 = "address1_telephone2";

            /// <summary>
            /// Tapez un troisième numéro de téléphone associé à l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_Telephone3 = "address1_telephone3";

            /// <summary>
            /// Tapez la zone UPS de l'adresse principale pour vous assurer que les frais de livraison sont calculés correctement et que les livraisons sont effectuées rapidement si elles sont prises en charge par UPS.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address1_UPSZone = "address1_upszone";

            /// <summary>
            /// Sélectionnez le fuseau horaire, ou décalage UTC, pour cette adresse pour que les autres utilisateurs puissent y faire référence s'ils contactent quelqu'un à cette adresse.
            /// Type : Integer
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string Address1_UTCOffset = "address1_utcoffset";

            /// <summary>
            /// Identificateur unique de l'adresse 2.
            /// Type : Uniqueidentifier
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string Address2_AddressId = "address2_addressid";

            /// <summary>
            /// Tapez la ville de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_City = "address2_city";

            /// <summary>
            /// Affiche l'adresse secondaire complète.
            /// Type : Memo
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string Address2_Composite = "address2_composite";

            /// <summary>
            /// Tapez le pays ou la région de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Country = "address2_country";

            /// <summary>
            /// Tapez la région de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_County = "address2_county";

            /// <summary>
            /// Tapez le numéro de télécopie associé à l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Fax = "address2_fax";

            /// <summary>
            /// Tapez la latitude de l'adresse secondaire à utiliser dans les cartes et les autres applications.
            /// Type : Double
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Latitude = "address2_latitude";

            /// <summary>
            /// Tapez la première ligne de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Line1 = "address2_line1";

            /// <summary>
            /// Tapez la deuxième ligne de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Line2 = "address2_line2";

            /// <summary>
            /// Tapez la troisième ligne de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Line3 = "address2_line3";

            /// <summary>
            /// Tapez la longitude de l'adresse secondaire à utiliser dans les cartes et les autres applications.
            /// Type : Double
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Longitude = "address2_longitude";

            /// <summary>
            /// Tapez un nom descriptif pour l'adresse secondaire, comme Siège social de l'entreprise.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Name = "address2_name";

            /// <summary>
            /// Tapez le code postal de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_PostalCode = "address2_postalcode";

            /// <summary>
            /// Tapez le numéro de boîte postale de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_PostOfficeBox = "address2_postofficebox";

            /// <summary>
            /// Tapez le nom du contact principal pour l’adresse secondaire du compte.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_PrimaryContactName = "address2_primarycontactname";

            /// <summary>
            /// Tapez l'état ou la province de l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_StateOrProvince = "address2_stateorprovince";

            /// <summary>
            /// Tapez le numéro de téléphone associé à l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Telephone1 = "address2_telephone1";

            /// <summary>
            /// Tapez un deuxième numéro de téléphone associé à l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Telephone2 = "address2_telephone2";

            /// <summary>
            /// Tapez un troisième numéro de téléphone associé à l'adresse secondaire.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_Telephone3 = "address2_telephone3";

            /// <summary>
            /// Tapez la zone UPS de l'adresse secondaire pour vous assurer que les frais de livraison sont calculés correctement et que les livraisons sont effectuées rapidement si elles sont prises en charge par UPS.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address2_UPSZone = "address2_upszone";

            /// <summary>
            /// Sélectionnez le fuseau horaire, ou décalage UTC, pour cette adresse pour que les autres utilisateurs puissent y faire référence s'ils contactent quelqu'un à cette adresse.
            /// Type : Integer
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string Address2_UTCOffset = "address2_utcoffset";

            /// <summary>
            /// Identificateur unique de l'adresse 3.
            /// Type : Uniqueidentifier
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string Address3_AddressId = "address3_addressid";

            /// <summary>
            /// Tapez la ville de la 3e adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_City = "address3_city";

            /// <summary>
            /// Affiche la troisième adresse complète.
            /// Type : Memo
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string Address3_Composite = "address3_composite";

            /// <summary>
            /// pays ou région de la 3e adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Country = "address3_country";

            /// <summary>
            /// Tapez la commune de la troisième adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_County = "address3_county";

            /// <summary>
            /// Tapez le numéro de télécopie associé à la troisième adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Fax = "address3_fax";

            /// <summary>
            /// Tapez la latitude de la troisième adresse à utiliser dans les cartes et les autres applications.
            /// Type : Double
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Latitude = "address3_latitude";

            /// <summary>
            /// première ligne de la 3e adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Line1 = "address3_line1";

            /// <summary>
            /// deuxième ligne de la 3e adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Line2 = "address3_line2";

            /// <summary>
            /// troisième ligne de la 3e adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Line3 = "address3_line3";

            /// <summary>
            /// Tapez la longitude de la troisième adresse à utiliser dans les cartes et les autres applications.
            /// Type : Double
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Longitude = "address3_longitude";

            /// <summary>
            /// Tapez un nom descriptif pour la troisième adresse, comme Siège social de l'entreprise.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Name = "address3_name";

            /// <summary>
            /// code postal de la 3e adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_PostalCode = "address3_postalcode";

            /// <summary>
            /// numéro de boîte postale de la 3e adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_PostOfficeBox = "address3_postofficebox";

            /// <summary>
            /// Tapez le nom du contact principal pour la troisième adresse du compte.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_PrimaryContactName = "address3_primarycontactname";

            /// <summary>
            /// département ou province de la troisième adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_StateOrProvince = "address3_stateorprovince";

            /// <summary>
            /// Tapez le numéro de téléphone principal associé à la troisième adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Telephone1 = "address3_telephone1";

            /// <summary>
            /// Tapez un deuxième numéro de téléphone associé à la troisième adresse.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Telephone2 = "address3_telephone2";

            /// <summary>
            /// Tapez un troisième numéro de téléphone associé à l'adresse principale.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_Telephone3 = "address3_telephone3";

            /// <summary>
            /// Tapez la zone UPS de la troisième adresse pour vous assurer que les frais de livraison sont calculés correctement et que les livraisons sont effectuées rapidement si elles sont prises en charge par UPS.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Address3_UPSZone = "address3_upszone";

            /// <summary>
            /// Sélectionnez le fuseau horaire, ou décalage UTC, pour cette adresse pour que les autres utilisateurs puissent y faire référence s'ils contactent quelqu'un à cette adresse.
            /// Type : Integer
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string Address3_UTCOffset = "address3_utcoffset";

            /// <summary>
            /// Utilisation par le système uniquement.
            /// Type : Money
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string Aging30 = "aging30";

            /// <summary>
            /// Utilisation par le système uniquement.
            /// Type : Money
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string Aging60 = "aging60";

            /// <summary>
            /// Utilisation par le système uniquement.
            /// Type : Money
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string Aging90 = "aging90";

            /// <summary>
            /// Entrez la date d'anniversaire d'entrée en service ou de mariage du contact pour l'utiliser dans les programmes de cadeaux aux clients ou les autres communications.
            /// Type : DateTime
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Anniversary = "anniversary";

            /// <summary>
            /// Tapez le revenu annuel du contact pour l'utiliser dans le profilage et l'analyse financière.
            /// Type : Money
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string AnnualIncome = "annualincome";

            /// <summary>
            /// Tapez le nom de l'assistant du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string AssistantName = "assistantname";

            /// <summary>
            /// Tapez le numéro de téléphone de l'assistant du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string AssistantPhone = "assistantphone";

            /// <summary>
            /// Entrez la date d'anniversaire du contact pour l'utiliser dans les programmes de cadeaux aux clients ou les autres communications.
            /// Type : DateTime
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string BirthDate = "birthdate";

            /// <summary>
            /// Tapez un deuxième numéro de téléphone professionnel pour ce contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Business2 = "business2";

            /// <summary>
            /// Tapez un numéro de téléphone de rappel pour ce contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Callback = "callback";

            /// <summary>
            /// Tapez les noms des enfants du contact pour référence dans les communications et les programmes clients.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string ChildrensNames = "childrensnames";

            /// <summary>
            /// Tapez le numéro de téléphone de la société du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Company = "company";

            /// <summary>
            /// Identificateur unique du contact.
            /// Type : Uniqueidentifier
            /// Validity :  Read | Create | AdvancedFind 
            /// </summary>
            public const string ContactId = "contactid";

            /// <summary>
            /// Affiche la date et l'heure de la création de l'enregistrement. Celles-ci sont affichées dans le fuseau horaire sélectionné dans les options de Microsoft Dynamics 365.
            /// Type : DateTime
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string CreatedOn = "createdon";

            /// <summary>
            /// Tapez la limite de crédit du contact pour référence quand vous abordez des problèmes de facturation et de comptabilité avec le client.
            /// Type : Money
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string CreditLimit = "creditlimit";

            /// <summary>
            /// Indiquez si le contact fait l'objet d'une suspension de crédit pour référence quand vous abordez des problèmes de facturation et de comptabilité avec le client.
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string CreditOnHold = "creditonhold";

            /// <summary>
            /// Tapez le service ou la division dans laquelle le contact travaille dans l'entreprise ou la société mère.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Department = "department";

            /// <summary>
            /// Entrez des informations supplémentaires pour décrire le contact, par exemple un extrait du site Web de la société.
            /// Type : Memo
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Description = "description";

            /// <summary>
            /// Indiquez si le contact accepte les envois en nombre via les campagnes marketing ou les campagnes rapides. Si Ne pas autoriser est sélectionné, le contact peut être ajouté aux listes marketing, mais est exclu du courrier électronique.
            /// Type : Boolean
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string DoNotBulkEMail = "donotbulkemail";

            /// <summary>
            /// Indiquez si le contact accepte le courrier postal en nombre via les campagnes marketing ou les campagnes rapides. Si Ne pas autoriser est sélectionné, le contact peut être ajouté aux listes marketing, mais est exclu des lettres.
            /// Type : Boolean
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string DoNotBulkPostalMail = "donotbulkpostalmail";

            /// <summary>
            /// Indiquez si le contact autorise le courrier direct envoyé depuis Microsoft Dynamics 365. Si Ne pas autoriser est sélectionné, Microsoft Dynamics 365 n'envoie pas le courrier électronique.
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string DoNotEMail = "donotemail";

            /// <summary>
            /// Indiquez si le contact autorise les télécopies. Si Ne pas autoriser est sélectionné, le contact peut être exclu des activités de télécopie distribuées dans les campagnes marketing.
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string DoNotFax = "donotfax";

            /// <summary>
            /// Indiquez si le contact accepte les appels téléphoniques. Si Ne pas autoriser est sélectionné, le contact peut être exclu des activités d'appel téléphonique distribuées dans les campagnes marketing.
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string DoNotPhone = "donotphone";

            /// <summary>
            /// Indiquez si le contact autorise le courrier direct. Si Ne pas autoriser est sélectionné, le contact peut être exclu des activités de lettre distribuées dans les campagnes marketing.
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string DoNotPostalMail = "donotpostalmail";

            /// <summary>
            /// Indiquez si le contact accepte les documents marketing, tels que des brochures ou des catalogues. Les contacts qui refusent de recevoir les publicités peuvent être exclus des initiatives marketing.
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string DoNotSendMM = "donotsendmm";

            /// <summary>
            /// Tapez l'adresse de messagerie principale pour le contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string EMailAddress1 = "emailaddress1";

            /// <summary>
            /// Tapez l'adresse de messagerie secondaire pour le contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string EMailAddress2 = "emailaddress2";

            /// <summary>
            /// Tapez une autre adresse de messagerie pour le contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string EMailAddress3 = "emailaddress3";

            /// <summary>
            /// Tapez le numéro ou l'identificateur d'employé du contact pour référence dans les commandes, les incidents de service ou les autres communications avec l'organisation du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string EmployeeId = "employeeid";

            /// <summary>
            /// Utilisation interne uniquement.
            /// Type : Uniqueidentifier
            /// Validity :  Read 
            /// </summary>
            public const string EntityImageId = "entityimageid";

            /// <summary>
            /// Affiche le taux de conversion de la devise de l'enregistrement. Le taux de change permet de convertir tous les champs d'argent de l'enregistrement de la devise locale en devise par défaut du système.
            /// Type : Decimal
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string ExchangeRate = "exchangerate";

            /// <summary>
            /// Identificateur d'utilisateur externe.
            /// Type : String
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string ExternalUserIdentifier = "externaluseridentifier";

            /// <summary>
            /// Tapez le numéro de télécopie du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Fax = "fax";

            /// <summary>
            /// Tapez le prénom du contact pour vous assurer que le contact est mentionné correctement dans les appels de télévente, le courrier électronique et les campagnes marketing.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string FirstName = "firstname";

            /// <summary>
            /// Informations indiquant si le suivi de l'activité de courrier électronique telle que les ouvertures, les affichages de pièce jointe et les clics sur les liens doit être autorisé pour les courriers électroniques envoyés au contact.
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string FollowEmail = "followemail";

            /// <summary>
            /// Tapez l'URL du site FTP du contact pour permettre aux utilisateurs d'accéder aux données et de partager les documents.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string FtpSiteUrl = "ftpsiteurl";

            /// <summary>
            /// Combine et affiche le nom et le prénom du contact pour que le nom complet puisse être affiché dans les vues et les rapports.
            /// Type : String
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string FullName = "fullname";

            /// <summary>
            /// Tapez le numéro de passeport ou un autre numéro gouvernemental pour le contact à utiliser dans les documents ou les rapports.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string GovernmentId = "governmentid";

            /// <summary>
            /// Tapez un deuxième numéro de téléphone personnel pour ce contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Home2 = "home2";

            /// <summary>
            /// Identificateur unique de l'importation ou de la migration de données ayant généré cet enregistrement.
            /// Type : Integer
            /// Validity :  Read | Create | AdvancedFind 
            /// </summary>
            public const string ImportSequenceNumber = "importsequencenumber";

            /// <summary>
            /// Information indiquant si le contact a été créé automatiquement lors de la promotion d’un courrier électronique ou d’un rendez-vous.
            /// Type : Boolean
            /// Validity : 
            /// </summary>
            public const string IsAutoCreate = "isautocreate";

            /// <summary>
            /// Indiquez si le contact existe dans une comptabilité distincte ou un autre système, tel que Microsoft Dynamics GP ou une autre base de données ERP, à utiliser dans les processus d'intégration.
            /// Type : Boolean
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string IsBackofficeCustomer = "isbackofficecustomer";

            /// <summary>
            /// IsPrivate
            /// Type : Boolean
            /// Validity : 
            /// </summary>
            public const string IsPrivate = "isprivate";

            /// <summary>
            /// Tapez la fonction du contact pour vous assurer que le contact est mentionné correctement dans les appels commerciaux, le courrier électronique et les campagnes marketing.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string JobTitle = "jobtitle";

            /// <summary>
            /// Tapez le nom du contact pour vous assurer que le contact est mentionné correctement dans les appels de télévente, le courrier électronique et les campagnes marketing.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string LastName = "lastname";

            /// <summary>
            /// Contient l'horodatage de la dernière durée de suspension.
            /// Type : DateTime
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string LastOnHoldTime = "lastonholdtime";

            /// <summary>
            /// Affiche la date de la dernière inclusion du contact à une campagne marketing ou une campagne rapide.
            /// Type : DateTime
            /// Validity :  Read | Update | AdvancedFind 
            /// </summary>
            public const string LastUsedInCampaign = "lastusedincampaign";

            /// <summary>
            /// Tapez le nom du directeur du contact à utiliser dans les problèmes réaffectés ou les autres communications de suivi avec le contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string ManagerName = "managername";

            /// <summary>
            /// Tapez le numéro de téléphone du directeur du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string ManagerPhone = "managerphone";

            /// <summary>
            /// Indique si uniquement pour marketing
            /// Type : Boolean
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string MarketingOnly = "marketingonly";

            /// <summary>
            /// Indique si le compte a été fusionné avec un contact principal.
            /// Type : Boolean
            /// Validity :  Read 
            /// </summary>
            public const string Merged = "merged";

            /// <summary>
            /// Tapez le deuxième prénom ou l'initiale du contact pour vous assurer que le contact est mentionné correctement.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string MiddleName = "middlename";

            /// <summary>
            /// Tapez le numéro de téléphone mobile du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string MobilePhone = "mobilephone";

            /// <summary>
            /// Affiche la date et l'heure de la dernière mise à jour de l'enregistrement. La date et l'heure sont affichées selon le fuseau horaire sélectionné dans les options de Microsoft Dynamics 365.
            /// Type : DateTime
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string ModifiedOn = "modifiedon";

            /// <summary>
            /// Tapez le surnom du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string NickName = "nickname";

            /// <summary>
            /// Tapez le nombre d'enfants du contact pour référence dans les appels téléphoniques et toute autre communication de suivi.
            /// Type : Integer
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string NumberOfChildren = "numberofchildren";

            /// <summary>
            /// Affiche la durée, en minutes, de la suspension de l'enregistrement.
            /// Type : Integer
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string OnHoldTime = "onholdtime";

            /// <summary>
            /// Date et heure de la migration de l'enregistrement.
            /// Type : DateTime
            /// Validity :  Read | Create | AdvancedFind 
            /// </summary>
            public const string OverriddenCreatedOn = "overriddencreatedon";

            /// <summary>
            /// Tapez le numéro de radiomessagerie du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Pager = "pager";

            /// <summary>
            /// Indique si le contact participe aux règles de workflow.
            /// Type : Boolean
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string ParticipatesInWorkflow = "participatesinworkflow";

            /// <summary>
            /// Affiche l'ID du processus.
            /// Type : Uniqueidentifier
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string ProcessId = "processid";

            /// <summary>
            /// Tapez la salutation du contact pour vous assurer que le contact est mentionné correctement dans les appels de télévente, les messages électroniques et les campagnes marketing.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Salutation = "salutation";

            /// <summary>
            /// Tapez le nom du conjoint(e)/partenaire du contact pour référence lors des appels, événements ou autres communications avec le contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string SpousesName = "spousesname";

            /// <summary>
            /// Affiche l'ID de la phase.
            /// Type : Uniqueidentifier
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string StageId = "stageid";

            #region Statut
            /// <summary>
            /// Indique si le contact est actif ou inactif. Les contacts inactifs sont en lecture seule et ne peuvent pas être modifiés avant d'être réactivés.
            /// Type : State
            /// </summary>
            public const string StateCode = "statecode";

            public class StateCodeValues
            {

                /// <summary>
                /// Actif
                /// </summary>
                public const int Option1_Actif = 0;

                /// <summary>
                /// Inactif
                /// </summary>
                public const int Option2_Inactif = 1;

            }
            #endregion Statut

            #region Raison du statut
            /// <summary>
            /// Sélectionnez le statut du contact.
            /// Type : Status
            /// </summary>
            public const string StatusCode = "statuscode";

            public class StatusCodeValues
            {

                /// <summary>
                /// Actif
                /// </summary>
                public const int Option1_Actif = 1;

                /// <summary>
                /// Inactif
                /// </summary>
                public const int Option2_Inactif = 2;

            }
            #endregion Raison du statut

            /// <summary>
            /// Utilisation interne uniquement.
            /// Type : Uniqueidentifier
            /// Validity :  Create 
            /// </summary>
            public const string SubscriptionId = "subscriptionid";

            /// <summary>
            /// Tapez le suffixe utilisé dans le nom du contact, comme Junior ou Senior, pour vous assurer que le contact est mentionné correctement dans les appels de télévente, le courrier électronique et les campagnes marketing.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Suffix = "suffix";

            /// <summary>
            /// Tapez le numéro de téléphone principal pour ce contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Telephone1 = "telephone1";

            /// <summary>
            /// Tapez un deuxième numéro de téléphone pour ce contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Telephone2 = "telephone2";

            /// <summary>
            /// Tapez un troisième numéro de téléphone pour ce contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string Telephone3 = "telephone3";

            /// <summary>
            /// Temps total que je consacre aux courriers électroniques (lecture et écriture) et aux réunions pour l'enregistrement de contact.
            /// Type : String
            /// Validity :  Read 
            /// </summary>
            public const string TimeSpentByMeOnEmailAndMeetings = "timespentbymeonemailandmeetings";

            /// <summary>
            /// Utilisation interne uniquement.
            /// Type : Integer
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string TimeZoneRuleVersionNumber = "timezoneruleversionnumber";

            /// <summary>
            /// Utilisation interne uniquement.
            /// Type : String
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string TraversedPath = "traversedpath";

            /// <summary>
            /// Code de fuseau horaire utilisé à la création de l’enregistrement.
            /// Type : Integer
            /// Validity :  Read | Create | Update 
            /// </summary>
            public const string UTCConversionTimeZoneCode = "utcconversiontimezonecode";

            /// <summary>
            /// Tapez l'URL du blog ou du site Web personnel ou professionnel du contact.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string WebSiteUrl = "websiteurl";

            /// <summary>
            /// Tapez l'orthographe phonétique du prénom du contact si le nom est indiqué en japonais pour vous assurer que le nom est prononcé correctement dans les appels téléphoniques et toute autre communication.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string YomiFirstName = "yomifirstname";

            /// <summary>
            /// Affiche le prénom et le nom Yomi combinés du contact pour que le nom phonétique complet puisse être affiché dans les vues et les rapports.
            /// Type : String
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string YomiFullName = "yomifullname";

            /// <summary>
            /// Tapez l'orthographe phonétique du nom du contact si le nom est indiqué en japonais pour vous assurer que le nom est prononcé correctement dans les appels téléphoniques et toute autre communication.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string YomiLastName = "yomilastname";

            /// <summary>
            /// Tapez l'orthographe phonétique du deuxième prénom du contact si le nom est indiqué en japonais pour vous assurer que le nom est prononcé correctement dans les appels téléphoniques et toute autre communication.
            /// Type : String
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string YomiMiddleName = "yomimiddlename";

            #endregion System Attributes
        }

        public static class Lookups
        {

            /// <summary>
            /// Identificateur unique du compte auquel le contact est associé.
            /// Type : Lookup
            /// Validity :  Read 
            /// </summary>
            public const string AccountId = "accountid";

            /// <summary>
            /// Affiche le créateur de l'enregistrement.
            /// Type : Lookup
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string CreatedBy = "createdby";

            /// <summary>
            /// Affiche la partie externe qui a créé l'enregistrement.
            /// Type : Lookup
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string CreatedByExternalParty = "createdbyexternalparty";

            /// <summary>
            /// Affiche l'utilisateur qui a créé l'enregistrement pour un autre utilisateur.
            /// Type : Lookup
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string CreatedOnBehalfBy = "createdonbehalfby";

            /// <summary>
            /// Choisissez les tarifs par défaut associés au contact pour vous assurer que les prix exacts du produit sont appliqués à ce client dans les opportunités de vente, les devis et les commandes.
            /// Type : Lookup
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string DefaultPriceLevelId = "defaultpricelevelid";

            /// <summary>
            /// Identificateur unique du contact principal pour la fusion.
            /// Type : Lookup
            /// Validity :  Read 
            /// </summary>
            public const string MasterId = "masterid";

            /// <summary>
            /// Affiche la personne à l'origine de la dernière mise à jour de l'enregistrement.
            /// Type : Lookup
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string ModifiedBy = "modifiedby";

            /// <summary>
            /// Affiche la partie externe qui a modifié l'enregistrement.
            /// Type : Lookup
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string ModifiedByExternalParty = "modifiedbyexternalparty";

            /// <summary>
            /// Affiche la personne à l'origine de la dernière mise à jour de l'enregistrement à la place d'un autre utilisateur.
            /// Type : Lookup
            /// Validity :  Read | AdvancedFind 
            /// </summary>
            public const string ModifiedOnBehalfBy = "modifiedonbehalfby";

            /// <summary>
            /// Affiche le prospect à partir duquel le contact a été créé si le contact a été créé par conversion d'un prospect dans Microsoft Dynamics 365. Permet d'établir un lien entre le contact et les données du prospect initial en vue d'une utilisation dans la génération de rapports et d'analyses.
            /// Type : Lookup
            /// Validity :  Read | Create | AdvancedFind 
            /// </summary>
            public const string OriginatingLeadId = "originatingleadid";

            /// <summary>
            /// Entrez l'utilisateur ou l'équipe affectée à la gestion de l'enregistrement. Ce champ est mis à jour à chaque fois que l'enregistrement est attribué à un utilisateur différent.
            /// Type : Owner
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string OwnerId = "ownerid";

            /// <summary>
            /// Identificateur unique de la division propriétaire du contact.
            /// Type : Lookup
            /// Validity :  Read 
            /// </summary>
            public const string OwningBusinessUnit = "owningbusinessunit";

            /// <summary>
            /// Identificateur unique de l’équipe propriétaire du contact.
            /// Type : Lookup
            /// Validity :  Read 
            /// </summary>
            public const string OwningTeam = "owningteam";

            /// <summary>
            /// Identificateur unique de l’utilisateur propriétaire du contact.
            /// Type : Lookup
            /// Validity :  Read 
            /// </summary>
            public const string OwningUser = "owninguser";

            /// <summary>
            /// Identificateur unique du contact parent.
            /// Type : Lookup
            /// Validity :  Read 
            /// </summary>
            public const string ParentContactId = "parentcontactid";

            /// <summary>
            /// Sélectionnez le compte parent ou le contact parent du contact pour fournir un lien rapide vers les détails supplémentaires, comme les informations financières, les activités et les opportunités.
            /// Type : Customer
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string ParentCustomerId = "parentcustomerid";

            /// <summary>
            /// Choisissez l'équipement ou l'installation de service préférée du contact pour vous assurer que les services sont planifiés correctement pour le client.
            /// Type : Lookup
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string PreferredEquipmentId = "preferredequipmentid";

            /// <summary>
            /// Choisissez le service préféré du contact pour vous assurer que les services sont planifiés correctement pour le client.
            /// Type : Lookup
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string PreferredServiceId = "preferredserviceid";

            /// <summary>
            /// Choisissez le conseiller du service clientèle préféré ou habituel pour référence lorsque vous planifiez des activités de service pour le contact.
            /// Type : Lookup
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string PreferredSystemUserId = "preferredsystemuserid";

            /// <summary>
            /// Choisissez le contrat de niveau de service (contrat SLA) que vous voulez appliquer à l'enregistrement de contact.
            /// Type : Lookup
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string SLAId = "slaid";

            /// <summary>
            /// Dernier contrat SLA ayant été appliqué à cet incident. Ce champ est destiné à une utilisation interne uniquement.
            /// Type : Lookup
            /// Validity :  Read 
            /// </summary>
            public const string SLAInvokedId = "slainvokedid";

            /// <summary>
            /// Choisissez la devise locale pour l'enregistrement pour vous assurer que les budgets sont validés dans la devise correcte.
            /// Type : Lookup
            /// Validity :  Read | Create | Update | AdvancedFind 
            /// </summary>
            public const string TransactionCurrencyId = "transactioncurrencyid";

        }

        public static class OptionSets
        {

            #region Rôle
            /// <summary>
            /// Sélectionnez le rôle du contact dans la société ou le processus de vente, tel que décisionnaire, employé ou influenceur.
            /// Type : Picklist
            /// </summary>
            public const string AccountRoleCode = "accountrolecode";

            public class AccountRoleCodeValues
            {

                /// <summary>
                /// Décisionnaire
                /// </summary>
                public const int Option1_Decisionnaire = 1;

                /// <summary>
                /// Employé
                /// </summary>
                public const int Option2_Employe = 2;

                /// <summary>
                /// Influenceur
                /// </summary>
                public const int Option3_Influenceur = 3;

            }
            #endregion Rôle

            #region Adresse 1 : Type d'adresse
            /// <summary>
            /// Sélectionnez le type d’adresse principale.
            /// Type : Picklist
            /// </summary>
            public const string Address1_AddressTypeCode = "address1_addresstypecode";

            public class Address1_AddressTypeCodeValues
            {

                /// <summary>
                /// Facturation
                /// </summary>
                public const int Option1_Facturation = 1;

                /// <summary>
                /// Expédition
                /// </summary>
                public const int Option2_Expedition = 2;

                /// <summary>
                /// Principale
                /// </summary>
                public const int Option3_Principale = 3;

                /// <summary>
                /// Autre
                /// </summary>
                public const int Option4_Autre = 4;

            }
            #endregion Adresse 1 : Type d'adresse

            #region Adresse 1 : Conditions de transport
            /// <summary>
            /// Sélectionnez les conditions de transport pour l'adresse principale pour vous assurer du traitement correct des bons de livraison.
            /// Type : Picklist
            /// </summary>
            public const string Address1_FreightTermsCode = "address1_freighttermscode";

            public class Address1_FreightTermsCodeValues
            {

                /// <summary>
                /// FAB
                /// </summary>
                public const int Option1_FAB = 1;

                /// <summary>
                /// Sans supplément
                /// </summary>
                public const int Option2_SansSupplement = 2;

                /// <summary>
                /// 1
                /// </summary>
                public const int Option3_1 = 100000000;

            }
            #endregion Adresse 1 : Conditions de transport

            #region Adresse 1 : Mode de livraison
            /// <summary>
            /// Sélectionnez un mode de livraison pour les livraisons envoyées à cette adresse.
            /// Type : Picklist
            /// </summary>
            public const string Address1_ShippingMethodCode = "address1_shippingmethodcode";

            public class Address1_ShippingMethodCodeValues
            {

                /// <summary>
                /// Aérien
                /// </summary>
                public const int Option1_Aerien = 1;

                /// <summary>
                /// DHL
                /// </summary>
                public const int Option2_DHL = 2;

                /// <summary>
                /// FedEx
                /// </summary>
                public const int Option3_FedEx = 3;

                /// <summary>
                /// UPS
                /// </summary>
                public const int Option4_UPS = 4;

                /// <summary>
                /// Courrier postal
                /// </summary>
                public const int Option5_CourrierPostal = 5;

                /// <summary>
                /// Plein chargement
                /// </summary>
                public const int Option6_PleinChargement = 6;

                /// <summary>
                /// Collecte
                /// </summary>
                public const int Option7_Collecte = 7;

            }
            #endregion Adresse 1 : Mode de livraison

            #region Adresse 2 : Type d'adresse
            /// <summary>
            /// Sélectionnez le type d’adresse secondaire.
            /// Type : Picklist
            /// </summary>
            public const string Address2_AddressTypeCode = "address2_addresstypecode";

            public class Address2_AddressTypeCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Adresse 2 : Type d'adresse

            #region Adresse 2 : Conditions de transport
            /// <summary>
            /// Sélectionnez les conditions de transport pour l'adresse secondaire pour vous assurer du traitement correct des bons de livraison.
            /// Type : Picklist
            /// </summary>
            public const string Address2_FreightTermsCode = "address2_freighttermscode";

            public class Address2_FreightTermsCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Adresse 2 : Conditions de transport

            #region Adresse 2 : Mode de livraison
            /// <summary>
            /// Sélectionnez un mode de livraison pour les livraisons envoyées à cette adresse.
            /// Type : Picklist
            /// </summary>
            public const string Address2_ShippingMethodCode = "address2_shippingmethodcode";

            public class Address2_ShippingMethodCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

                /// <summary>
                /// 1
                /// </summary>
                public const int Option2_1 = 100000000;

            }
            #endregion Adresse 2 : Mode de livraison

            #region Adresse 3 : type d'adresse
            /// <summary>
            /// Sélectionnez le troisième type d’adresse.
            /// Type : Picklist
            /// </summary>
            public const string Address3_AddressTypeCode = "address3_addresstypecode";

            public class Address3_AddressTypeCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Adresse 3 : type d'adresse

            #region Adresse 3 : conditions de transport
            /// <summary>
            /// Sélectionnez les conditions de transport pour la troisième adresse afin de vous assurer du traitement correct des bons de livraison.
            /// Type : Picklist
            /// </summary>
            public const string Address3_FreightTermsCode = "address3_freighttermscode";

            public class Address3_FreightTermsCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Adresse 3 : conditions de transport

            #region Adresse 3 : mode de livraison
            /// <summary>
            /// Sélectionnez un mode de livraison pour les livraisons envoyées à cette adresse.
            /// Type : Picklist
            /// </summary>
            public const string Address3_ShippingMethodCode = "address3_shippingmethodcode";

            public class Address3_ShippingMethodCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Adresse 3 : mode de livraison

            #region Taille du client
            /// <summary>
            /// Sélectionnez la taille de la société du contact à des fins de génération de rapports et de segmentation.
            /// Type : Picklist
            /// </summary>
            public const string CustomerSizeCode = "customersizecode";

            public class CustomerSizeCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

                /// <summary>
                /// 1
                /// </summary>
                public const int Option2_1 = 100000000;

            }
            #endregion Taille du client

            #region Type de relation
            /// <summary>
            /// Sélectionnez la catégorie qui décrit le mieux la relation entre le contact et votre organisation.
            /// Type : Picklist
            /// </summary>
            public const string CustomerTypeCode = "customertypecode";

            public class CustomerTypeCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Type de relation

            #region Formation
            /// <summary>
            /// Sélectionnez le niveau de formation le plus élevé du contact à utiliser dans la segmentation marketing et l'analyse démographique.
            /// Type : Picklist
            /// </summary>
            public const string EducationCode = "educationcode";

            public class EducationCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Formation

            #region État civil
            /// <summary>
            /// Sélectionnez l'état civil du contact pour référence dans les appels téléphoniques et toute autre communication de suivi.
            /// Type : Picklist
            /// </summary>
            public const string FamilyStatusCode = "familystatuscode";

            public class FamilyStatusCodeValues
            {

                /// <summary>
                /// Célibataire
                /// </summary>
                public const int Option1_Celibataire = 1;

                /// <summary>
                /// Marié(e)
                /// </summary>
                public const int Option2_Mariee = 2;

                /// <summary>
                /// Divorcé(e)
                /// </summary>
                public const int Option3_Divorcee = 3;

                /// <summary>
                /// Veuf(ve)
                /// </summary>
                public const int Option4_Veufve = 4;

            }
            #endregion État civil

            #region Sexe
            /// <summary>
            /// Sélectionnez le sexe du contact pour vous assurer que le contact est mentionné correctement dans les appels de télévente, le courrier électronique et les campagnes marketing.
            /// Type : Picklist
            /// </summary>
            public const string GenderCode = "gendercode";

            public class GenderCodeValues
            {

                /// <summary>
                /// Homme
                /// </summary>
                public const int Option1_Homme = 1;

                /// <summary>
                /// Femme
                /// </summary>
                public const int Option2_Femme = 2;

            }
            #endregion Sexe

            #region A des enfants
            /// <summary>
            /// Indiquez si le contact a des enfants pour référence dans les appels téléphoniques et toute autre communication de suivi.
            /// Type : Picklist
            /// </summary>
            public const string HasChildrenCode = "haschildrencode";

            public class HasChildrenCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion A des enfants

            #region Source du prospect
            /// <summary>
            /// Sélectionnez la principale source marketing qui a redirigé le contact vers votre organisation.
            /// Type : Picklist
            /// </summary>
            public const string LeadSourceCode = "leadsourcecode";

            public class LeadSourceCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

                /// <summary>
                /// 1
                /// </summary>
                public const int Option2_1 = 100000000;

            }
            #endregion Source du prospect

            #region Conditions de paiement
            /// <summary>
            /// Sélectionnez les conditions de paiement pour indiquer quand le client doit payer le montant total.
            /// Type : Picklist
            /// </summary>
            public const string PaymentTermsCode = "paymenttermscode";

            public class PaymentTermsCodeValues
            {

                /// <summary>
                /// Net 30J
                /// </summary>
                public const int Option1_Net30J = 1;

                /// <summary>
                /// 2% 10j, net 30j
                /// </summary>
                public const int Option2_210jNet30j = 2;

                /// <summary>
                /// Net 45J
                /// </summary>
                public const int Option3_Net45J = 3;

                /// <summary>
                /// Net 60J
                /// </summary>
                public const int Option4_Net60J = 4;

            }
            #endregion Conditions de paiement

            #region Jour privilégié
            /// <summary>
            /// Sélectionnez le jour préféré de la semaine pour les rendez-vous de service.
            /// Type : Picklist
            /// </summary>
            public const string PreferredAppointmentDayCode = "preferredappointmentdaycode";

            public class PreferredAppointmentDayCodeValues
            {

                /// <summary>
                /// Dimanche
                /// </summary>
                public const int Option1_Dimanche = 0;

                /// <summary>
                /// Lundi
                /// </summary>
                public const int Option2_Lundi = 1;

                /// <summary>
                /// Mardi
                /// </summary>
                public const int Option3_Mardi = 2;

                /// <summary>
                /// Mercredi
                /// </summary>
                public const int Option4_Mercredi = 3;

                /// <summary>
                /// Jeudi
                /// </summary>
                public const int Option5_Jeudi = 4;

                /// <summary>
                /// Vendredi
                /// </summary>
                public const int Option6_Vendredi = 5;

                /// <summary>
                /// Samedi
                /// </summary>
                public const int Option7_Samedi = 6;

            }
            #endregion Jour privilégié

            #region Heure privilégiée
            /// <summary>
            /// Sélectionnez l'heure préférée de la semaine pour les rendez-vous de service.
            /// Type : Picklist
            /// </summary>
            public const string PreferredAppointmentTimeCode = "preferredappointmenttimecode";

            public class PreferredAppointmentTimeCodeValues
            {

                /// <summary>
                /// Matin
                /// </summary>
                public const int Option1_Matin = 1;

                /// <summary>
                /// Après-midi
                /// </summary>
                public const int Option2_Apresmidi = 2;

                /// <summary>
                /// Soir
                /// </summary>
                public const int Option3_Soir = 3;

            }
            #endregion Heure privilégiée

            #region Mode de communication privilégié
            /// <summary>
            /// Sélectionnez la méthode de contact préférée.
            /// Type : Picklist
            /// </summary>
            public const string PreferredContactMethodCode = "preferredcontactmethodcode";

            public class PreferredContactMethodCodeValues
            {

                /// <summary>
                /// Sans préférence
                /// </summary>
                public const int Option1_SansPreference = 1;

                /// <summary>
                /// Courrier électronique
                /// </summary>
                public const int Option2_CourrierElectronique = 2;

                /// <summary>
                /// Téléphone
                /// </summary>
                public const int Option3_Telephone = 3;

                /// <summary>
                /// Télécopie
                /// </summary>
                public const int Option4_Telecopie = 4;

                /// <summary>
                /// Courrier postal
                /// </summary>
                public const int Option5_CourrierPostal = 5;

                /// <summary>
                /// Sans préférence
                /// </summary>
                public const int Option6_SansPreference = 803750000;

            }
            #endregion Mode de communication privilégié
            
            #region Mode de livraison
            /// <summary>
            /// Sélectionnez un mode de livraison pour les livraisons envoyées à cette adresse.
            /// Type : Picklist
            /// </summary>
            public const string ShippingMethodCode = "shippingmethodcode";

            public class ShippingMethodCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Mode de livraison

            #region Statut
            /// <summary>
            /// Indique si le contact est actif ou inactif. Les contacts inactifs sont en lecture seule et ne peuvent pas être modifiés avant d'être réactivés.
            /// Type : State
            /// </summary>
            public const string StateCode = "statecode";

            public class StateCodeValues
            {

                /// <summary>
                /// Actif
                /// </summary>
                public const int Option1_Actif = 0;

                /// <summary>
                /// Inactif
                /// </summary>
                public const int Option2_Inactif = 1;

            }
            #endregion Statut

            #region Raison du statut
            /// <summary>
            /// Sélectionnez le statut du contact.
            /// Type : Status
            /// </summary>
            public const string StatusCode = "statuscode";

            public class StatusCodeValues
            {

                /// <summary>
                /// Actif
                /// </summary>
                public const int Option1_Actif = 1;

                /// <summary>
                /// Inactif
                /// </summary>
                public const int Option2_Inactif = 2;

            }
            #endregion Raison du statut

            #region Secteur de vente
            /// <summary>
            /// Sélectionnez une région ou un territoire pour le contact, à utiliser dans la segmentation et les analyses.
            /// Type : Picklist
            /// </summary>
            public const string TerritoryCode = "territorycode";

            public class TerritoryCodeValues
            {

                /// <summary>
                /// Valeur par défaut
                /// </summary>
                public const int Option1_ValeurParDefaut = 1;

            }
            #endregion Secteur de vente

        }

        public static class MultiSelectOptionSets
        {
        }
    }
}
