using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Constants
{
    public static class GlobalRoles
    {
        [Display(Name = "مدیر")]
        public const string Admin = "Admin";
        [Display(Name = "کاربر")]
        public const string User = "User";

        //---------------------------------------------------------------Plan

        [Display(Name = "طرح")]
        public const string Plan = "Plan";
        [Display(Name = "ایجاد طرح")]
        public const string PlanCreate = "PlanCreate";
        [Display(Name = "لیست طرح")]
        public const string PlanRead = "PlanRead";
        [Display(Name = "ویرایش طرح")]
        public const string PlanUpdate = "PlanUpdate";
        [Display(Name = "حذف طرح")]
        public const string PlanDelete = "PlanDelete";

        //---------------------------------------------------------------Project

        [Display(Name = "طرح")]
        public const string Project = "Project";
        [Display(Name = "ایجاد طرح")]
        public const string ProjectCreate = "ProjectCreate";
        [Display(Name = "لیست طرح")]
        public const string ProjectRead = "ProjectRead";
        [Display(Name = "ویرایش طرح")]
        public const string ProjectUpdate = "ProjectUpdate";
        [Display(Name = "حذف طرح")]
        public const string ProjectDelete = "ProjectDelete";

        //---------------------------------------------------------------Contract

        [Display(Name = "طرح")]
        public const string Contract = "Contract";
        [Display(Name = "ایجاد طرح")]
        public const string ContractCreate = "ContractCreate";
        [Display(Name = "لیست طرح")]
        public const string ContractRead = "ContractRead";
        [Display(Name = "ویرایش طرح")]
        public const string ContractUpdate = "ContractUpdate";
        [Display(Name = "حذف طرح")]
        public const string ContractDelete = "ContractDelete";

        //---------------------------------------------------------------Organization

        [Display(Name = "واحدهای سازمانی")]
        public const string Organization = "Organization";
        [Display(Name = "ایجاد واحدهای سازمانی")]
        public const string OrganizationCreate = "OrganizationCreate";
        [Display(Name = "لیست واحدهای سازمانی")]
        public const string OrganizationRead = "OrganizationRead";
        [Display(Name = "ویرایش واحدهای سازمانی")]
        public const string OrganizationUpdate = "OrganizationUpdate";
        [Display(Name = "حذف واحدهای سازمانی")]
        public const string OrganizationDelete = "OrganizationDelete";



        [Display(Name = "گروه واحدها")]
        public const string OrganizationType = "OrganizationType";
        [Display(Name = "ایجاد گروه واحدها")]
        public const string OrganizationTypeCreate = "OrganizationTypeCreate";
        [Display(Name = "لیست گروه واحدها")]
        public const string OrganizationTypeRead = "OrganizationTypeRead";
        [Display(Name = "ویرایش گروه واحدها")]
        public const string OrganizationTypeUpdate = "OrganizationTypeUpdate";
        [Display(Name = "حذف گروه واحدها")]
        public const string OrganizationTypeDelete = "OrganizationTypeDelete";



        [Display(Name = "اسناد واحدهای سازمانی")]
        public const string OrganizationDocument = "OrganizationDocument";
        [Display(Name = "ایجاد اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentCreate = "OrganizationDocumentCreate";
        [Display(Name = "لیست اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentRead = "OrganizationDocumentRead";
        [Display(Name = "ویرایش اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentUpdate = "OrganizationDocumentUpdate";
        [Display(Name = "حذف اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentDelete = "OrganizationDocumentDelete";



        [Display(Name = "اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentForm = "OrganizationDocumentForm";
        [Display(Name = "ایجاد اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentFormCreate = "OrganizationDocumentCreate";
        [Display(Name = "لیست اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentFormRead = "OrganizationDocumentFormRead";
        [Display(Name = "ویرایش اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentFormUpdate = "OrganizationDocumentFormUpdate";
        [Display(Name = "حذف اسناد واحدهای سازمانی")]
        public const string OrganizationDocumentFormDelete = "OrganizationDocumentFormDelete";


        //---------------------------------------------------------------Lab

        [Display(Name = "آزمایشگاه")]
        public const string LabSection = "LabSection";
        [Display(Name = "ایجاد آزمایشگاه")]
        public const string LabSectionCreate = "LabSectionCreate";
        [Display(Name = "لیست آزمایشگاه")]
        public const string LabSectionRead = "LabSectionRead";
        [Display(Name = "ویرایش آزمایشگاه")]
        public const string LabSectionUpdate = "LabSectionUpdate";
        [Display(Name = "حذف آزمایشگاه")]
        public const string LabSectionDelete = "LabSectionDelete";



        [Display(Name = "سیستم")]
        public const string LabSystem = "Users";
        [Display(Name = "ایجاد سیستم")]
        public const string LabSystemCreate = "LabSystemCreate";
        [Display(Name = "لیست سیستم")]
        public const string LabSystemRead = "LabSystemRead";
        [Display(Name = "ویرایش سیستم")]
        public const string LabSystemUpdate = "LabSystemUpdate";
        [Display(Name = "حذف سیستم")]
        public const string LabSystemDelete = "LabSystemDelete";



        //---------------------------------------------------------------Document

        [Display(Name = "اسناد")]
        public const string Document = "Document";
        [Display(Name = "ایجاد سند")]
        public const string DocumentCreate = "DocumentCreate";
        [Display(Name = "لیست سند")]
        public const string DocumentRead = "DocumentRead";
        [Display(Name = "ویرایش سند")]
        public const string DocumentUpdate = "DocumentUpdate";
        [Display(Name = "حذف سند")]
        public const string DocumentDelete = "DocumentDelete";


        [Display(Name = "مالکین سند")]
        public const string DocumentOwner = "DocumentOwner";
        [Display(Name = "ایجاد مالک سند")]
        public const string DocumentOwnerCreate = "DocumentOwnerCreate";
        [Display(Name = "لیست مالک سند")]
        public const string DocumentOwnerRead = "DocumentOwnerRead";
        [Display(Name = "ویرایش مالک سند")]
        public const string DocumentOwnerUpdate = "DocumentOwnerUpdate";
        [Display(Name = "حذف مالک سند")]
        public const string DocumentOwnerDelete = "DocumentOwnerDelete";


        [Display(Name = "انواع سند")]
        public const string DocumentType = "DocumentType";
        [Display(Name = "ایجاد انواع سند")]
        public const string DocumentTypeCreate = "DocumentTypeCreate";
        [Display(Name = "لیست انواع سند")]
        public const string DocumentTypeRead = "DocumentTypeRead";
        [Display(Name = "ویرایش انواع سند")]
        public const string DocumentTypeUpdate = "DocumentTypeUpdate";
        [Display(Name = "حذف انواع سند")]
        public const string DocumentTypeDelete = "DocumentTypeDelete";


        [Display(Name = "اسناد مصوب")]
        public const string DocumentFinal = "DocumentType";
        [Display(Name = "لیست اسناد مصوب")]
        public const string DocumentFinalRead = "DocumentTypeRead";


        [Display(Name = "سابقه اسناد")]
        public const string DocumentLog = "DocumentLog";
        [Display(Name = "لیست سابقه اسناد")]
        public const string DocumentLogRead = "DocumentLogRead";


        [Display(Name = "سابقه فرم")]
        public const string DocumentFormLog = "DocumentFormLog";
        [Display(Name = "لیست سابقه فرم")]
        public const string DocumentFormLogRead = "DocumentFormLogRead";


        [Display(Name = "سابقه فرم سند")]
        public const string DocumentFormFinal = "DocumentFormFinal";
        [Display(Name = "لیست سابقه فرم سند")]
        public const string DocumentFormFinalRead = "DocumentFormFinalRead";


        //---------------------------------------------------------------Equipment

        [Display(Name = "تجهیزات")]
        public const string Equipment = "Equipment";
        [Display(Name = "ایجاد تجهیزات")]
        public const string EquipmentCreate = "EquipmentCreate";
        [Display(Name = "لیست تجهیزات")]
        public const string EquipmentRead = "EquipmentRead";
        [Display(Name = "ویرایش تجهیزات")]
        public const string EquipmentUpdate = "EquipmentUpdate";
        [Display(Name = "حذف تجهیزات")]
        public const string EquipmentDelete = "EquipmentDelete";


        //---------------------------------------------------------------Users

        [Display(Name = "کاربران")]
        public const string Users = "Users";
        [Display(Name = "ایجاد کاربران")]
        public const string UserCreate = "UserCreate";
        [Display(Name = "لیست کاربران")]
        public const string UserRead = "UserRead";
        [Display(Name = "ویرایش کاربران")]
        public const string UserUpdate = "UserUpdate";
        [Display(Name = "حذف کاربران")]
        public const string UserDelete = "UserDelete";


        [Display(Name = "مجوزها")]
        public const string Permission = "Permission";
        [Display(Name = "ایجاد مجوزها")]
        public const string PermissionCreate = "PermissionCreate";
        [Display(Name = "لیست مجوزها")]
        public const string PermissionRead = "PermissionRead";
        [Display(Name = "ویرایش مجوزها")]
        public const string PermissionUpdate = "PermissionUpdate";
        [Display(Name = "حذف مجوزها")]
        public const string PermissionDelete = "PermissionDelete";


        [Display(Name = "گروه دسترسی")]
        public const string Group = "Group";
        [Display(Name = "ایجاد گروه دسترسی")]
        public const string GroupCreate = "GroupCreate";
        [Display(Name = "لیست گروه دسترسی")]
        public const string GroupRead = "GroupRead";
        [Display(Name = "ویرایش گروه دسترسی")]
        public const string GroupUpdate = "GroupUpdate";
        [Display(Name = "حذف گروه دسترسی")]
        public const string GroupDelete = "GroupDelete";



        //---------------------------------------------------------------Form

        [Display(Name = "فرم")]
        public const string Form = "Users";
        [Display(Name = "ایجاد فرم")]
        public const string FormCreate = "FormCreate";
        [Display(Name = "لیست فرم")]
        public const string FormRead = "FormRead";
        [Display(Name = "ویرایش فرم")]
        public const string FormUpdate = "FormUpdate";
        [Display(Name = "حذف فرم")]
        public const string FormDelete = "FormDelete";

        //---------------------------------------------------------------Settings

        [Display(Name = "پروفایل")]
        public const string Profile = "Profile";
        [Display(Name = "ویرایش پروفایل")]
        public const string ProfileUpdate = "ProfileUpdate";

        [Display(Name = "امضا")]
        public const string UserSignature = "UserSignature";
        [Display(Name = "ویرایش پروفایل")]
        public const string UserSignatureUpdate = "UserSignatureUpdate";

    }
}
