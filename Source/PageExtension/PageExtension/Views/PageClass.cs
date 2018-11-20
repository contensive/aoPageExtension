

using System;
using System.Collections.Generic;
using System.Text;
using Contensive.BaseClasses;

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
                    if (String.IsNullOrWhiteSpace(extensionName)) {
                        if (cp.User.IsAdmin) return "The ExtensionName is blank. To use the Page Extension, set the ExtensionName and select the ExtensionType.";
                        return "";
                    }
                    return cp.Content.GetCopy("PageExtension-Page-" + cp.Doc.PageId + "-" + extensionName);
                } catch (Exception ex) {
                    cp.Site.ErrorReport(ex);
                    return "";
                }
            }
        }
    }
}
