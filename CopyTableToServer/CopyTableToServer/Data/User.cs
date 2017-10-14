using System;
using System.Diagnostics.Contracts;

namespace CopyTableToServer.Data
{
    public partial class User : IEquatable<User>
    {
        #region PublicMethods

        public void UpdateFrom(User updateFrom)
        {
            Contract.Requires(updateFrom != null);

            Lnk_User = updateFrom.Lnk_User;
            Lnk_Entity = updateFrom.Lnk_Entity;
            User_Code = updateFrom.User_Code;
            User_Name = updateFrom.User_Name;
            User_Pass = updateFrom.User_Pass;
            User_Level = updateFrom.User_Level;
            User_Group = updateFrom.User_Group;
            Net_Name = updateFrom.Net_Name;
            SQL_Name = updateFrom.SQL_Name;
            SQL_Pass = updateFrom.SQL_Pass;
            EMail_Server = updateFrom.EMail_Server;
            EMail_Name = updateFrom.EMail_Name;
            EMail_Address = updateFrom.EMail_Address;
            EMail_Signature = updateFrom.EMail_Signature;
            User_Signature = updateFrom.User_Signature;
            User_Sig_FileName = updateFrom.User_Sig_FileName;
            User_FullName = updateFrom.User_FullName;
            User_Title = updateFrom.User_Title;
            User_Phone = updateFrom.User_Phone;
            User_DeptPhone = updateFrom.User_DeptPhone;
            User_DeptFax = updateFrom.User_DeptFax;
            User_JFunc = updateFrom.User_JFunc;
            User_Depts = updateFrom.User_Depts;
            User_IsConsult = updateFrom.User_IsConsult;
            User_IsContractor = updateFrom.User_IsContractor;
            User_IsOpsCons = updateFrom.User_IsOpsCons;
            User_IsTester = updateFrom.User_IsTester;
            User_IsMerger = updateFrom.User_IsMerger;
            User_PLDefault = updateFrom.User_PLDefault;
            User_Location = updateFrom.User_Location;
            User_DefCompany = updateFrom.User_DefCompany;
            User_ViewCompanies = updateFrom.User_ViewCompanies;
            User_EditCompanies = updateFrom.User_EditCompanies;
            User_IsActive = updateFrom.User_IsActive;
            User_UseSpeller = updateFrom.User_UseSpeller;
        }

        #endregion

        #region Implementation of IEquatable<User>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(User other)
        {
            if (other == null)
            {
                Console.Write("Null: ");
                return false;
            }
            if (Lnk_User != other.Lnk_User)
            {
                Console.Write("Lnk_User: ");
                return false;
            }
            if (Lnk_Entity != other.Lnk_Entity)
            {
                Console.Write("Lnk_Entity: ");
                return false;
            }
            if (User_Code != other.User_Code)
            {
                Console.Write("User_Code: ");
                return false;
            }
            if (User_Name != other.User_Name)
            {
                Console.Write("User_Name: ");
                return false;
            }
            if (User_Pass != other.User_Pass)
            {
                Console.Write("User_Pass: ");
                return false;
            }
            if (User_Level != other.User_Level)
            {
                Console.Write("User_Level: ");
                return false;
            }
            if (User_Group != other.User_Group)
            {
                Console.Write("User_Group: ");
                return false;
            }
            if (Net_Name != other.Net_Name)
            {
                Console.Write("Net_Name: ");
                return false;
            }
            if (SQL_Name != other.SQL_Name)
            {
                Console.Write("SQL_Name: ");
                return false;
            }
            if (SQL_Pass != other.SQL_Pass)
            {
                Console.Write("SQL_Pass: ");
                return false;
            }
            //if (EMail_Server != other.EMail_Server)
            //{
            //    Console.Write("EMail_Server: ");
            //    return false;
            //}
            if (EMail_Name != other.EMail_Name)
            {
                Console.Write("EMail_Name: ");
                return false;
            }
            if (EMail_Address != other.EMail_Address)
            {
                Console.Write("EMail_Address: ");
                return false;
            }
            if (EMail_Signature != other.EMail_Signature)
            {
                Console.Write("EMail_Signature: ");
                return false;
            }
            //if (User_Signature != other.User_Signature)
            //{
            //    Console.Write("User_Signature: ");
            //    return false;
            //}
            if (User_Sig_FileName != other.User_Sig_FileName)
            {
                Console.Write("User_Sig_FileName: ");
                return false;
            }
            if (User_FullName != other.User_FullName)
            {
                Console.Write("User_FullName: ");
                return false;
            }
            if (User_Title != other.User_Title)
            {
                Console.Write("User_Title: ");
                return false;
            }
            if (User_Phone != other.User_Phone)
            {
                Console.Write("User_Phone: ");
                return false;
            }
            if (User_DeptPhone != other.User_DeptPhone)
            {
                Console.Write("User_DeptPhone: ");
                return false;
            }
            if (User_DeptFax != other.User_DeptFax)
            {
                Console.Write("User_DeptFax: ");
                return false;
            }
            if (User_JFunc != other.User_JFunc)
            {
                Console.Write("User_JFunc: ");
                return false;
            }
            if (User_Depts != other.User_Depts)
            {
                Console.Write("User_Depts: ");
                return false;
            }
            if (User_IsConsult != other.User_IsConsult)
            {
                Console.Write("User_IsConsult: ");
                return false;
            }
            if (User_IsContractor != other.User_IsContractor)
            {
                Console.Write("User_IsContractor: ");
                return false;
            }
            if (User_IsOpsCons != other.User_IsOpsCons)
            {
                Console.Write("User_IsOpsCons: ");
                return false;
            }
            if (User_IsTester != other.User_IsTester)
            {
                Console.Write("User_IsTester: ");
                return false;
            }
            if (User_IsMerger != other.User_IsMerger)
            {
                Console.Write("User_IsMerger: ");
                return false;
            }
            if (User_PLDefault != other.User_PLDefault)
            {
                Console.Write("User_PLDefault: ");
                return false;
            }
            if (User_Location != other.User_Location)
            {
                Console.Write("User_Location: ");
                return false;
            }
            if (User_DefCompany != other.User_DefCompany)
            {
                Console.Write("User_DefCompany: ");
                return false;
            }
            if (User_ViewCompanies != other.User_ViewCompanies)
            {
                Console.Write("User_ViewCompanies: ");
                return false;
            }
            if (User_EditCompanies != other.User_EditCompanies)
            {
                Console.Write("User_EditCompanies: ");
                return false;
            }
            if (User_IsActive != other.User_IsActive)
            {
                Console.Write("User_IsActive: ");
                return false;
            }
            if (User_UseSpeller != other.User_UseSpeller)
            {
                Console.Write("User_UseSpeller: ");
                return false;
            }
            return true;
        }

        #endregion
    }
}
