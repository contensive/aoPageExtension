
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using Contensive.BaseClasses;

namespace PageExtension {
    namespace Models {
        public class PageContentModel : baseModel {
            //
            //====================================================================================================
            //-- const
            //------ set content name
            public const string contentName = "page content";
            //------ set to tablename for the primary content (used for cache names)
            public const string contentTableName = "ccPageContent";
            //
            //====================================================================================================
            // -- instance properties
           
            public bool AllowBrief { get; set; }
            public bool AllowChildListDisplay { get; set; }
            public bool AllowFeedback { get; set; }
            public bool AllowHitNotification { get; set; }
            public bool AllowInChildLists { get; set; }
            public bool AllowInMenus { get; set; }
            public bool AllowLastModifiedFooter { get; set; }
            public bool AllowMessageFooter { get; set; }
            public bool AllowMetaContentNoFollow { get; set; }
            public bool AllowMoreInfo { get; set; }
            public bool AllowReturnLinkDisplay { get; set; }
            public bool AllowReviewedFooter { get; set; }
            public bool AllowSeeAlso { get; set; }
            public int ArchiveParentID { get; set; }
            public bool BlockContent { get; set; }
            public bool BlockPage { get; set; }
            public int BlockSourceID { get; set; }
            public string BriefFilename { get; set; }
            public string ChildListInstanceOptions { get; set; }
            public int ChildListSortMethodID { get; set; }
            public bool ChildPagesFound { get; set; }
            public int Clicks { get; set; }
            public int ContactMemberID { get; set; }
            public int ContentCategoryID { get; set; }
            public int ContentPadding { get; set; }
            public string Copyfilename { get; set; }
            public string CustomBlockMessage { get; set; }
            public DateTime DateArchive { get; set; }
            public DateTime DateExpires { get; set; }
            public DateTime DateReviewed { get; set; }
            public string Headline { get; set; }
            public string ImageFilename { get; set; }
            public bool IsSecure { get; set; }
            public string JSEndBody { get; set; }
            public string JSFilename { get; set; }
            public string JSHead { get; set; }
            public string JSOnLoad { get; set; }
            public string Link { get; set; }
            public string LinkAlias { get; set; }
            public string LinkLabel { get; set; }
            public string MenuHeadline { get; set; }
            public string PageLink { get; set; }
            public int ParentID { get; set; }
            public string ParentListName { get; set; }
            public DateTime PubDate { get; set; }
            public int RegistrationGroupID { get; set; }
            public int ReviewedBy { get; set; }
            public int TemplateID { get; set; }
            public int TriggerAddGroupID { get; set; }
            public int TriggerConditionGroupID { get; set; }
            public int TriggerConditionID { get; set; }
            public int TriggerRemoveGroupID { get; set; }
            public int TriggerSendSystemEmailID { get; set; }
            public int Viewings { get; set; }



            //
            //====================================================================================================
            public static PageContentModel @add(CPBaseClass cp) {
                return @add<PageContentModel>(cp);
            }
            //
            //====================================================================================================
            public static PageContentModel create(CPBaseClass cp, int recordId) {
                return create<PageContentModel>(cp, recordId);
            }
            //
            //====================================================================================================
            public static PageContentModel create(CPBaseClass cp, string recordGuid) {
                return create<PageContentModel>(cp, recordGuid);
            }
            //
            //====================================================================================================
            public static List<PageContentModel> createByName(CPBaseClass cp, string recordName) {
                return createByName<PageContentModel>(cp, recordName);
            }
            //
            //====================================================================================================
            public new void save(CPBaseClass cp) {
                base.save<PageContentModel>(cp);
            }
            //
            //====================================================================================================
            public static void delete(CPBaseClass cp, int recordId) {
                delete<PageContentModel>(cp, recordId);
            }
            //
            //====================================================================================================
            public static void delete(CPBaseClass cp, string ccGuid) {
                delete<PageContentModel>(cp, ccGuid);
            }
            //
            //====================================================================================================
            public static List<PageContentModel> createList(CPBaseClass cp, string sqlCriteria, string sqlOrderBy = "id") {
                return createList<PageContentModel>(cp, sqlCriteria, sqlOrderBy);
            }
            //
            //====================================================================================================
            public static string getRecordName(CPBaseClass cp, int recordId) {
                return baseModel.getRecordName<PageContentModel>(cp, recordId);
            }
            //
            //====================================================================================================
            public static string getRecordName(CPBaseClass cp, string ccGuid) {
                return baseModel.getRecordName<PageContentModel>(cp, ccGuid);
            }
            //
            //====================================================================================================
            public static int getRecordId(CPBaseClass cp, string ccGuid) {
                return baseModel.getRecordId<PageContentModel>(cp, ccGuid);
            }

            //
            //====================================================================================================
            //
            public PageContentModel Clone(CPBaseClass cp) {
                PageContentModel result = (PageContentModel)this.Clone();
                result.id = cp.Content.AddRecord(contentName);
                result.ccguid = cp.Utils.CreateGuid();
                result.save<PageContentModel>(cp);
                return result;
            }
            //
            //====================================================================================================
            //
            public object Clone() {
                return this.MemberwiseClone();
            }
        }
    }
}
