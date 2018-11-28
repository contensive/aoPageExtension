

using System;
using System.Collections.Generic;
using System.Text;
using Contensive.BaseClasses;

using PageExtension.Models;

namespace Contensive.Addons.PageExtensions {
    namespace Views {
        public class PageClass : AddonBaseClass {
            //
            // ====================================================================================================
            /// <summary>
            /// return a 
            /// </summary>
            /// <param name="cp"></param>
            /// <returns></returns>
            public override object Execute(CPBaseClass cp) {
                try {
                    string extensionName = cp.Doc.GetText("ExtensionName");
                    string extensionType = cp.Doc.GetText("ExtensionType");
                    if (String.IsNullOrWhiteSpace(extensionName)) {
                        if (cp.User.IsAdmin) return "The ExtensionName is blank. To use the Page Extension, set the ExtensionName and select the ExtensionType.";
                        return "";
                    }
                    switch(extensionType.ToLower()) {
                        case "section":
                            //
                            // 
                            //
                            return cp.Content.GetCopy("PageExtension-Section-" + getRootPageId( cp, cp.Doc.PageId , new List<int>() ) + "-" + extensionName);
                        default:
                            return cp.Content.GetCopy("PageExtension-Page-" + cp.Doc.PageId + "-" + extensionName);
                    }
                } catch (Exception ex) {
                    cp.Site.ErrorReport(ex);
                    return "";
                }
            }
            /// <summary>
            /// return the top-level root page of a page id
            /// </summary>
            /// <param name="cp"></param>
            /// <param name="pageId"></param>
            /// <returns></returns>
            public int getRootPageId(CPBaseClass cp, int pageId, List<int> usedIdList)
            {
                if (usedIdList.Contains(pageId)) { return pageId; }
                var Page = PageContentModel.create(cp, pageId);
                if (Page.ParentID == 0) { return pageId; }
                usedIdList.Add(pageId);
                return getRootPageId(cp, Page.ParentID, usedIdList);
            }
        }

    }
}
